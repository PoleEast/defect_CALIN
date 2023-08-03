using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PCI_DMC;
using PCI_DMC_ERR;
namespace defect_CALIN
{
    public partial class Form1 : Form
    {
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void startbtn_Click_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0, lMask = 0x1;
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
                    dmc04pi_init();
                    txtSlaveNum.Text = gNodeNum.ToString();
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
                    timerIO.Enabled = true;


                }
            }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

    }
}
