using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;


using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.IO;//////WinFileOperate
using System.Diagnostics;///檢查執行中的程式///
using System.Runtime.InteropServices;//使用DllImport

//Camera & Parameter

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

using GitHub.secile.Video;

using PCI_DMC;
using PCI_DMC_ERR;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AForge.Math.Geometry;

namespace defect_CALIN
{

    public partial class Form1 : Form
    {
        Rectangle S_ROI, T_ROI;
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool emgSTOP=false;
        bool stop = false;
        bool svon = false;
        //camera//

        public int videoDeviceIdx = -1;
        public int ResolutionIdx = 1;//  1~18

        Bitmap ccdbmp;

        public double Zoom;
        public int ZoomType;
        public int framerate = 0;
        public int ImgWidth = 0;
        public int ImgHeight = 0;
        UsbCamera camera;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ////////檢查執行中的程式//////
            try
            {
                Process[] process2 = Process.GetProcessesByName("cm100");///檢查執行中的程式
                if (process2.Length >= 2)  // 重複開啟
                {
                    MessageBox.Show("重複開啟程式！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Application.Exit();
                    Environment.Exit(Environment.ExitCode);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //////////讀設定/////////////
            Init.Read_INI_Set();

            ///////usb   ccd//////////////////////
            Zoom = 4.0;
            Init.CameraInit(ref cmbCameraID);
            //startbtn_Click(sender, e);
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0, lMask = 0x1,p=0;
            uint DeviceType = 0, IdentityObject = 0;

            //開啟軸卡
            rc = CPCI_DMC.CS_DMC_01_open(ref existcard);    //existcard會填入卡的數量,rc為錯誤檢測
            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
                txtcardnum.Text = existcard.ToString();
            txtslavenum.Text = "0";
            CmbCardNo.Items.Clear();

            //初始化軸卡
            for (i = 0; i < existcard; i++)     //進行軸卡初始化
            {
                rc = CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                gCardNoList[i] = card_no;

                CmbCardNo.Items.Insert(i, card_no);

                rc = CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                if (rc != 0)
                    MessageBox.Show("Can't boot PCI_DMC Master Card!");

                rc = CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
                if (existcard != 0)
                {
                    CmbCardNo.SelectedIndex = 0;
                    gCardNo = gCardNoList[0];
                }
            }

            //建立通訊
            gNodeNum = 0;
            txtslavenum.Text = "0";
            timer4PI.Enabled = false;
            for (i = 0; i < 4; i++)
                SlaveTable[i] = 0;
            rc = CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);
            rc = CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);
            rc = CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);

            if (SlaveTable[0] == 0)
                MessageBox.Show("CardNo: " + gCardNo.ToString() + " No slave found!");
            else
            {
                for (i = 0; i < 32; i++)
                {
                    if ((SlaveTable[0] & lMask) != 0)
                    {
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        gNodeNum++;
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, (ushort)(i + 1), (ushort)0, ref DeviceType, ref IdentityObject);
                        if (rc != 0)
                        {
                            MessageBox.Show("get_devicetype failed - code=" + rc);
                        }
                        else
                        {
                            switch (DeviceType)
                            {
                                case 0x14100191:			//Remote Module 04PI
                                    cmb04PInode.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);//設定脈波介面模組輸入相位模式
                                    p++;
                                    break;
                                case 0x04020192:			//DRIVER Servo A2 series
                                    cmbDRIVERnode.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x04130191:			//Remote Module I/O
                                    cmbIOnode.Items.Add(i + 1);
                                    p++;
                                    break;

                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("No  A2  04PI DEVICE Found!");
                }
                else
                {
                    Init.dmc04pi_init(ref gCardNo);
                    txtslavenum.Text = gNodeNum.ToString();
                    cmb04PInode.Enabled = true;
                    cmbDRIVERnode.Enabled = true;
                    cmbIOnode.Enabled = true;

                    cmb04PInode.SelectedIndex = 0;
                    cmbDRIVERnode.SelectedIndex = 0;
                    cmbIOnode.SelectedIndex = 0;

                    timer4PI.Enabled = true;
                    DMCtimer.Enabled = true;
                    /////io_active////////////////////
                    ushort nodeid, SlotID = 0, Enable;
                    nodeid = 9;
                    Enable = 1;
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, Enable);


                }
            }
        }

        private void Pmovef(ushort nodeid)
        {
            int m_StrVel = 0, m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = 0.5, m_Tdec = 0.5;
            int m_Dist = Int32.Parse(cboDIST.Text);
            //太重最大速限250
            if ((nodeid == 2))
            {
                if (m_MaxVel > 250) m_MaxVel = 250;
            }
            ////////////////

            if (emgSTOP == false)
            {
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
        }
        private void Nmovef(ushort nodeid)
        {
            int m_StrVel = 0, m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = 0.5, m_Tdec = 0.5;
            int m_Dist = Int32.Parse(cboDIST.Text);
            //太重最大速限250
            if ((nodeid == 2))
            {
                if (m_MaxVel > 250) m_MaxVel = 250;
            }
            ///////////////////////////

            if (emgSTOP == false)
            {
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
        }
        private void btnPmove_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            Pmovef(nodeid);
        }

        private void btnNmove_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            Nmovef(nodeid);
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            stop = false;
            btnStop.Enabled = true;
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void btnSvon_Click(object sender, EventArgs e)
        {
            if (svon == false)
            {
                for (ushort i = 1; i <= 4; i++)
                {
                    btnSvon.Text = "Svon OFF";
                    /* A2F Servo Power ON/Power OFF */
                    rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, i, 0, 1);//on
                }
                svon = true;
            }
            else
            {
                for (ushort i = 1; i <= 4; i++)
                {
                    btnSvon.Text = "Svon ON";
                    /* A2F Servo Power ON/Power OFF */
                    rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, i, 0, 1);//on
                }
                svon = false;
            }
        }
        private void timer4PI_Tick(object sender, EventArgs e)
        {

            //Motion status
            int cmd = 0, spd = 0;
            ushort MC_done = 0;
            uint MC_status = 0, err = 0;

            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            //Status
            rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, 0, ref cmd);             //Command
            if (rc == 0)
            {
                txtcommand.Text = cmd.ToString();
            }

            rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref spd);       //Speed
            if (rc == 0)
            {
                txtspeed.Text = spd.ToString();
            }
            //rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
            //if (rc == 0)
            //{
            //    txtmotion.Text = MC_done.ToString();
            //}
            //rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, 0, ref MC_status);     //Motion status
            //if (rc == 0)
            //{
            //    txtIO.Text = MC_status.ToString("X2");
            //}
            rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, 0, ref err);          //Error
            if (rc == 0)
            {
                txtERR.Text = err.ToString("X");
            }
            ////Get Servo DI status
            //bool ORG = Get_Servo_ORG_status(nodeid);
            //txtIOsts3.BackColor = ORG ? System.Drawing.Color.Lime : System.Drawing.Color.Red;

            ////DO Status
            //rc = CPCI_DMC.CS_DMC_01_set_monitor(gCardNo, nodeid, 0, 40); //Read DO
            //Thread.Sleep(20);
            //rc = CPCI_DMC.CS_DMC_01_get_monitor(gCardNo, nodeid, 0, ref u32_val);
            //txtDO1.BackColor = ((u32_val & 0x0001) != 0) ? System.Drawing.Color.Red : System.Drawing.Color.Lime;

            ////  4軸位置
            //rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, 1, 0, ref pos_1);
            //rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, 2, 0, ref pos_2);
            //rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, 3, 0, ref pos_3);
            //rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, 4, 0, ref pos_4);

            //txtPOS1.Text = pos_1.ToString();
            //txtPOS2.Text = pos_2.ToString();
            //txtPOS3.Text = pos_3.ToString();
            //txtPOS4.Text = pos_4.ToString();

        }
        private void cmbCameraID_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoDeviceIdx = cmbCameraID.SelectedIndex;
            if (videoDeviceIdx != -1)
            {
                UsbCamera.VideoFormat[] formats = UsbCamera.GetVideoFormat(videoDeviceIdx);
                lbxCam.Items.Clear();
                foreach (UsbCamera.VideoFormat elme in formats)
                {
                    long ttt = 10000000 / elme.TimePerFrame;
                    Size aa = elme.Size;
                    string SubType = elme.SubType;
                    framerate = Convert.ToInt32(ttt);
                    ImgWidth = aa.Width;
                    ImgHeight = aa.Height;

                    string deviceDATA = SubType + ttt + "fps" + ImgWidth + "x" + ImgHeight;
                    lbxCam.Items.Add(deviceDATA);
                }
            }
        }
        private void timer_Inspect_Tick(object sender, EventArgs e)
        {
            ccdbmp = camera.GetBitmap();

            pictureBox.Image = ccdbmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 0;
            bool direction = false;
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref speed);
                if (speed == 0)
                {
                    if (direction)
                    {
                        Pmovef(nodeid);
                        direction = false;
                    }
                    else
                    {
                        Nmovef(nodeid);
                        direction = true;
                    }
                }
            
        }

        private void bntResetPos_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            //btnHOMEf(nodeid);
        }
        //private void btnHOMEf(ushort nodeid)
        //{

        //    ////////home////////////////
        //    int m_StrVel = 0, m_MaxVel = 1000;
        //    if (nodeid == 2) m_MaxVel = 250;
        //    double m_Tacc = 0.5, m_Tdec = 0.5;
        //    int m_Dist = 0;
        //    ///現在位置 //正向移動
        //    int CurrentPOS = 0;
        //    if (nodeid == 1)
        //        CurrentPOS = pos_1;
        //    if (nodeid == 2)
        //        CurrentPOS = pos_2;
        //    if (nodeid == 3)
        //        CurrentPOS = pos_3;
        //    if (nodeid == 4)
        //        CurrentPOS = pos_4;
        //    if (CurrentPOS < 0)  //正向移動
        //        if (emgSTOP == false)
        //        {
        //            // 前進
        //            m_Dist = -CurrentPOS;
        //            rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
        //            ushort MC_done = 2;
        //            while (MC_done != 0) //move
        //            {
        //                DelayThreadSleep(50);
        //                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
        //            }
        //        }
        //    ///////////////

        //    m_Dist = 35500;

        //    if (emgSTOP == false)
        //    {
        //        if (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
        //        { //快速倒退
        //            rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
        //        }
        //    }
        //    while (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
        //    {
        //        DelayThreadSleep(50);
        //        if (emgSTOP == true) return;
        //    }
        //    ///////原點stop//////
        //    rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        //    DelayThreadSleep(100);//不可減少
        //    if (emgSTOP == false)
        //    {
        //        // 前進
        //        m_Dist = 500;
        //        rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
        //        ushort MC_done = 2;
        //        while (MC_done != 0) //move
        //        {
        //            DelayThreadSleep(50);
        //            rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
        //        }
        //    }
        //    if (emgSTOP == false)
        //    {

        //        //慢速倒退
        //        m_MaxVel = 100;
        //        rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
        //        while (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
        //        {
        //            DelayThreadSleep(50);
        //            if (emgSTOP == true) return;
        //        }

        //        ///////原點stop//////
        //        rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);

        //        ////////////////////
        //        CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
        //        CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        //    }
        //    btnHOME.BackColor = SystemColors.Control;

        //}

        //close Application
        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }
        private void btnCameraConnect_Click(object sender, EventArgs e)
        {
            //// Check if a camera is connected
            if (videoDeviceIdx < 0)
            {
                MessageBox.Show("No found camera");
                btnCameraConnect.Enabled = false;
                return;
            }
            else
                btnCameraConnect.Enabled = true;

            if (btnCameraConnect.Enabled)
            {
                if (videoDeviceIdx != -1)
                {
                    UsbCamera.VideoFormat[] formats = UsbCamera.GetVideoFormat(videoDeviceIdx);

                    long ttt = 10000000 / formats[ResolutionIdx].TimePerFrame;
                    Size fmtSize = formats[ResolutionIdx].Size;
                    string SubType = formats[ResolutionIdx].SubType;
                    framerate = Convert.ToInt32(ttt);
                    ImgWidth = fmtSize.Width;
                    ImgHeight = fmtSize.Height;

                    txtCamState.Text = SubType + ttt + "fps" + ImgWidth + "x" + ImgHeight;

                    //// create usb camera and start.
                    camera = new UsbCamera(videoDeviceIdx, formats[ResolutionIdx]);
                    camera.Start();

                    //pictureBox.Width = (int)(ImgWidth / Zoom);
                    //pictureBox.Height = (int)(ImgHeight / Zoom);
                    pictureBox.Width = (int)(ImgWidth );
                    pictureBox.Height = (int)(ImgHeight);
                    //pictureBox1.Width = (int)(ImgWidth / Zoom);
                    //pictureBox1.Height = (int)(ImgHeight / Zoom);
                    //pictureBox4.Width = (int)(ImgWidth / Zoom);
                    //pictureBox4.Height = (int)(ImgHeight / Zoom);


                    ////UI  
                    timer_Inspect.Enabled = true; //開攝影機即啟動Timer

                    S_ROI = new Rectangle(750, 480, 435, 80);
                }
            }
            else
            {
                camera.Stop();
                timer_Inspect.Enabled = false; //關攝影機即停止Timer
            }

        }
        private void lbxCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResolutionIdx = lbxCam.SelectedIndex;
        }
        //private void Cmdreset(ushort nodeid)
        //{
        //    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
        //    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        //}
    }
}
