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

namespace defect_CALIN
{

    public partial class Form1 : Form
    {
        ///////usb camera//////
        Rectangle S_ROI, T_ROI;
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        //camera//

        public int videoDeviceIdx = -1;
        public int ResolutionIdx = 1;//  1~18

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

                    DMCtimer.Enabled = true;
                    /////io_active////////////////////
                    ushort nodeid, SlotID = 0, Enable;
                    nodeid = 9;
                    Enable = 1;
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, Enable);


                }
            }
        }

        private void cmbCameraID_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoDeviceIdx = cmbCameraID.SelectedIndex;
            if (videoDeviceIdx != -1)
            {
                UsbCamera.VideoFormat[] formats = UsbCamera.GetVideoFormat(videoDeviceIdx);
                cmbCameraID.Items.Clear();
                foreach (UsbCamera.VideoFormat elme in formats)
                {
                    long ttt = 10000000 / elme.TimePerFrame;
                    Size aa = elme.Size;
                    string SubType = elme.SubType;
                    framerate = Convert.ToInt32(ttt);
                    ImgWidth = aa.Width;
                    ImgHeight = aa.Height;

                    string deviceDATA = SubType + ttt + "fps" + ImgWidth + "x" + ImgHeight;
                    cmbCameraID.Items.Add(deviceDATA);
                }
            }
        }

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

            if (!btnCameraConnect.Enabled)
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

                    pictureBox.Width = (int)(ImgWidth / Zoom);
                    pictureBox.Height = (int)(ImgHeight / Zoom);
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
        //private void Cmdreset(ushort nodeid)
        //{
        //    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
        //    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        //}
    }
}
