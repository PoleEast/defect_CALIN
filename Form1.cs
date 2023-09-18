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
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using defect_CALIN.src;
using defect_CALIN.Controls;

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
        bool emgSTOP = false;
        uint u32_val;
        int nodeSpeed=0;
        bool[,] repeatv;
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

        Dictionary<string, bool> repeatState = new Dictionary<string, bool>();
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
            richText_message.Text += "初始化完成";
            ///////usb   ccd//////////////////////
            Zoom = 4.0;
            Init.CameraInit(ref cmbCameraID);
            //startbtn_Click(sender, e);
            richText_message.Text = "相機初始化完成";
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0, lMask = 0x1, p = 0;
            uint DeviceType = 0, IdentityObject = 0;

            //開啟軸卡
            rc = CPCI_DMC.CS_DMC_01_open(ref existcard);    //existcard會填入卡的數量,rc為錯誤檢測
            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
                txtcardnum.Text = existcard.ToString();
            txtslavenum.Text = "0";
            CmbCardNo.Items.Clear();
            richText_message.Text += "found DMC-NET card";
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
            richText_message.Text += "抓取控制卡元件中";
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

                    repeatv = new bool[cmb04PInode.Items.Count, 2];

                    timer4PI.Enabled = true;
                    /////io_active////////////////////
                    ushort nodeid, SlotID = 0, Enable;
                    nodeid = 9;
                    Enable = 1;
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, Enable);
                    for (i = 1; i <= 4; i++)
                    {
                        /* A2F Servo Power ON/Power OFF */
                        rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, i, 0, 1);//on
                    }
                    Control_enabled(true);
                    btnAllStop.Enabled = true;
                    richText_message.Text = "抓取控制元件完成";
                }
            }
        }
        private void Control_enabled(bool state)
        {
            System.Windows.Forms.Button[] buttonsToEnable = { btnPmove, btnNmove, btnRepeat, bntResetPos };

            foreach (System.Windows.Forms.Button button in buttonsToEnable)
            {
                button.Enabled = state;
            }
        }
        private void Movef(ushort nodeid,bool direction)
        {
            int m_StrVel = 0, m_MaxVel=0;
            double m_Tacc = 0.5, m_Tdec = 0.5;
            int m_Dist=0;
            try
            {
                m_MaxVel = Int32.Parse(txtMaxVel.Text);
                m_Dist = Int32.Parse(cboDIST.Text) >= 1500 ? 1500 : Int32.Parse(cboDIST.Text);
                richText_message.Text = "馬達旋轉中";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //太重最大速限250
            if ((nodeid == 2))
            {
                if (m_MaxVel > 250) m_MaxVel = 250;
            }
            ///////////////////////////

            if (direction)
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            else
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
        }
        private void btnPmove_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            Movef(nodeid, true);
        }

        private void btnNmove_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            Movef(nodeid, false);
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            timer_repeat.Enabled = true;
            btnPmove.Enabled = false;
            btnNmove.Enabled = false;
            repeatv[int.Parse(cmb04PInode.Text), 0] = true;
        }

        private void btnAllStop_Click(object sender, EventArgs e)
        {
            timer_repeat.Stop();
            Array.Clear(repeatv,0,repeatv.Length);
            for (ushort nodeid = 1; nodeid <= 4; nodeid++)
            {
                stop(nodeid);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            stop(nodeid);
        }
        private void stop(ushort nodeid)
        {
            rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
            repeatv[(int)nodeid, 0] = false;
            richText_message.Text = "nodeid"+nodeid.ToString()+"停止";
            DelayThreadSleep(100);//不可減少
        }

        //抓取節點資訊
        private void timer4PI_Tick(object sender, EventArgs e)
        {
            //Motion status
            int cmd = 0;
            uint  err = 0;

            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            //Status
            rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, 0, ref cmd);             //Command
            if (rc == 0)
            {
                txtcommand.Text = cmd.ToString();
            }

            rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref nodeSpeed);       //Speed
            if (rc == 0)
            {
                txtspeed.Text = nodeSpeed.ToString();
                if (nodeSpeed != 0)
                {
                    Control_enabled(false);
                    lbworking.ForeColor = Color.Green;
                }
                else
                {
                    lbworking.ForeColor = Color.Red;
                    Control_enabled(true);
                }
            }
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
            if (videoDeviceIdx < 0)
            {
                MessageBox.Show("No found camera");
                btnCameraConnect.Enabled = false;
                return;
            }
            else
            {
                btnCameraConnect.Enabled = true;
            }
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
        //更新影像
        private void timer_Inspect_Tick(object sender, EventArgs e)
        {
            ccdbmp = camera.GetBitmap();

            ptbbefore.Image = ccdbmp;
        }

        private void timer_repeat_Tick(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            for (int i = 0; i <= repeatv.GetLength(0); i++)
            {
                if (repeatv[i, 0])
                {
                    rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref nodeSpeed);
                    if (nodeSpeed == 0)
                    {
                        Movef(nodeid, repeatv[i, 1]);
                        repeatv[i, 1] = !repeatv[i, 1];
                    }
                }
            }
        }

        private void bntResetPos_Click(object sender, EventArgs e)
        {
            ushort nodeid = ushort.Parse(cmb04PInode.Text);
            btnhomef(nodeid);
        }


        private void btnhomef(ushort nodeid)
        {

            ////////home////////////////
            int m_StrVel = 0, m_MaxVel = 1000;
            if (nodeid == 2) m_MaxVel = 250;
            double m_Tacc = 0.5, m_Tdec = 0.5;
            int m_Dist = 35500;
            richText_message.Text = "nodeid" + nodeid.ToString() + "復歸中";

            if (emgSTOP == false)
            {
                if (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
                { //快速倒退
                    rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                }
            }
            while (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
            {
                DelayThreadSleep(50);
                if (emgSTOP == true) return;
            }
            ///////原點stop//////
            rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
            DelayThreadSleep(100);//不可減少
            if (emgSTOP == false)
            {
                // 前進
                m_Dist = 500;
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                ushort MC_done = 2;
                while (MC_done != 0) //move
                {
                    DelayThreadSleep(50);
                    rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
                }
            }
            if (emgSTOP == false)
            {

                //慢速倒退
                m_MaxVel = 100;
                rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0 - m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                while (Get_Servo_ORG_status(nodeid) == false)    ///Get Servo DI status//未在原點
                {
                    DelayThreadSleep(50);
                    if (emgSTOP == true) return;
                }

                ///////原點stop//////
                rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);

                ////////////////////
                CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
                CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
            }
            richText_message.Text = "nodeid" + nodeid.ToString() + "復歸完成";
        }
        private bool Get_Servo_ORG_status(ushort nodeid)
        {
            bool ORG = false;
            //Get Servo DI status
            rc = CPCI_DMC.CS_DMC_01_set_monitor(gCardNo, nodeid, 0, 39); //Read DI
            Thread.Sleep(20);
            rc = CPCI_DMC.CS_DMC_01_get_monitor(gCardNo, nodeid, 0, ref u32_val);

            if ((nodeid == 1) | (nodeid == 2) | (nodeid == 3))
            {
                //ORG  
                ORG = ((u32_val & 0x0010) != 0) ? false : true;
            }
            if (nodeid == 4)
            {
                //ORG 
                ORG = ((u32_val & 0x0010) != 0) ? true : false;
            }
            return ORG;
        }
        //close Application
        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            System.Windows.Forms.Application.Exit();
        }

        private void btnSaveimg_Click(object sender, EventArgs e)
        {
            {
                string EditPath = "C:\\Users\\a1525\\Desktop\\Code\\Python\\T_Poject\\defate_CALIN\\img"; // 圖片的本地路徑
                try
                {
                    Bitmap image = new Bitmap(ccdbmp);
                    string numericFormat = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileName = $"image_{numericFormat}.jpg"; // 使用适当的文件名生成规则
                    string filePath = Path.Combine(EditPath, fileName);
                    image.Save(filePath);
                    ptbafter.Image = image;
                    richText_message.Text = "圖片儲存完成";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("save fail" + ex);
                }
            }
        }


        private void btnCameraConnect_Click(object sender, EventArgs e)
        {
            if (btnCameraConnect.Text == "Camera On" && btnCameraConnect.Enabled)
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

                    ptbbefore.Width = (int)(ImgWidth / Zoom);
                    ptbbefore.Height = (int)(ImgHeight / Zoom);

                    ////UI  
                    timer_Inspect.Enabled = true; //開攝影機即啟動Timer

                    S_ROI = new Rectangle(750, 480, 435, 80);
                    btnCameraConnect.Text = "Camera Off";
                    btnSaveimg.Enabled = true;
                    richText_message.Text = "相機開啟成功";
                }
            }
            else
            {
                camera.Stop();
                timer_Inspect.Enabled = false; //關攝影機即停止Timer
                ptbbefore.Image = null;
                btnSaveimg.Enabled = false;
                btnCameraConnect.Text = "Camera On";
                richText_message.Text = "相機關閉";
            }
        }

        private async void btnHE_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(ptbafter.Image);
            var bitmapHE=await Img_Processing.ImageEH(bitmap);
            richText_message.Text += "HE完成";
            ptbafter.Image = bitmapHE;
        }

        private void lbxCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResolutionIdx = lbxCam.SelectedIndex;

        }
        private void ptbafter_ImageChanged(object sender, EventArgs e)
        {
            if (ptbafter.Image != null)
                btnHE.Enabled=true;
        }
        private void DelayThreadSleep(int time)
        {
            for (int i = 0; i < (time / 5); i++)
            {
                Thread.Sleep(5);
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnexit_Click(sender, e);
        }
        //private void Cmdreset(ushort nodeid)
        //{
        //    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
        //    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        //}
    }
}
