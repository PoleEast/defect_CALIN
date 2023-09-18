using defect_CALIN.Controls;

namespace defect_CALIN
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.txtcardnum = new System.Windows.Forms.TextBox();
            this.txtslavenum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb04PInode = new System.Windows.Forms.ComboBox();
            this.cmbDRIVERnode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIOnode = new System.Windows.Forms.ComboBox();
            this.btnCameraConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCameraID = new System.Windows.Forms.ComboBox();
            this.txtCamState = new System.Windows.Forms.TextBox();
            this.ptbbefore = new System.Windows.Forms.PictureBox();
            this.timer_Inspect = new System.Windows.Forms.Timer(this.components);
            this.richText_message = new System.Windows.Forms.RichTextBox();
            this.btnPmove = new System.Windows.Forms.Button();
            this.btnNmove = new System.Windows.Forms.Button();
            this.cboDIST = new System.Windows.Forms.TextBox();
            this.txtMaxVel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnAllStop = new System.Windows.Forms.Button();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.txtcommand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbxCam = new System.Windows.Forms.ListBox();
            this.timer4PI = new System.Windows.Forms.Timer(this.components);
            this.timer_repeat = new System.Windows.Forms.Timer(this.components);
            this.bntResetPos = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSaveimg = new System.Windows.Forms.Button();
            this.lbworking = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnHE = new System.Windows.Forms.Button();
            this.ptbyolo = new System.Windows.Forms.PictureBox();
            this.ptbafter = new PictureEvent();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ptbbefore)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbyolo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbafter)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(44, 23);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(147, 80);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnexit.Location = new System.Drawing.Point(44, 464);
            this.btnexit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(147, 80);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Card num:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Card No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(24, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Slave num:";
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(127, 78);
            this.CmbCardNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(136, 27);
            this.CmbCardNo.TabIndex = 6;
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(127, 15);
            this.txtcardnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.ReadOnly = true;
            this.txtcardnum.Size = new System.Drawing.Size(136, 27);
            this.txtcardnum.TabIndex = 7;
            // 
            // txtslavenum
            // 
            this.txtslavenum.Location = new System.Drawing.Point(127, 138);
            this.txtslavenum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtslavenum.Name = "txtslavenum";
            this.txtslavenum.ReadOnly = true;
            this.txtslavenum.Size = new System.Drawing.Size(136, 27);
            this.txtslavenum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "04pi Node ID";
            // 
            // cmb04PInode
            // 
            this.cmb04PInode.FormattingEnabled = true;
            this.cmb04PInode.Location = new System.Drawing.Point(127, 187);
            this.cmb04PInode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb04PInode.Name = "cmb04PInode";
            this.cmb04PInode.Size = new System.Drawing.Size(136, 27);
            this.cmb04PInode.TabIndex = 10;
            // 
            // cmbDRIVERnode
            // 
            this.cmbDRIVERnode.FormattingEnabled = true;
            this.cmbDRIVERnode.Location = new System.Drawing.Point(127, 242);
            this.cmbDRIVERnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDRIVERnode.Name = "cmbDRIVERnode";
            this.cmbDRIVERnode.Size = new System.Drawing.Size(136, 27);
            this.cmbDRIVERnode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "motor num";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "I/O Node ID";
            // 
            // cmbIOnode
            // 
            this.cmbIOnode.FormattingEnabled = true;
            this.cmbIOnode.Location = new System.Drawing.Point(127, 293);
            this.cmbIOnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbIOnode.Name = "cmbIOnode";
            this.cmbIOnode.Size = new System.Drawing.Size(136, 27);
            this.cmbIOnode.TabIndex = 14;
            // 
            // btnCameraConnect
            // 
            this.btnCameraConnect.Enabled = false;
            this.btnCameraConnect.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCameraConnect.Location = new System.Drawing.Point(44, 336);
            this.btnCameraConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCameraConnect.Name = "btnCameraConnect";
            this.btnCameraConnect.Size = new System.Drawing.Size(147, 80);
            this.btnCameraConnect.TabIndex = 15;
            this.btnCameraConnect.Text = "Camera On";
            this.btnCameraConnect.UseVisualStyleBackColor = true;
            this.btnCameraConnect.Click += new System.EventHandler(this.btnCameraConnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(611, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Camera ID";
            // 
            // cmbCameraID
            // 
            this.cmbCameraID.FormattingEnabled = true;
            this.cmbCameraID.Location = new System.Drawing.Point(714, 309);
            this.cmbCameraID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCameraID.Name = "cmbCameraID";
            this.cmbCameraID.Size = new System.Drawing.Size(136, 27);
            this.cmbCameraID.TabIndex = 17;
            this.cmbCameraID.SelectedIndexChanged += new System.EventHandler(this.cmbCameraID_SelectedIndexChanged);
            // 
            // txtCamState
            // 
            this.txtCamState.Location = new System.Drawing.Point(44, 422);
            this.txtCamState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCamState.Name = "txtCamState";
            this.txtCamState.ReadOnly = true;
            this.txtCamState.Size = new System.Drawing.Size(147, 27);
            this.txtCamState.TabIndex = 18;
            // 
            // ptbbefore
            // 
            this.ptbbefore.Location = new System.Drawing.Point(20, 17);
            this.ptbbefore.Name = "ptbbefore";
            this.ptbbefore.Size = new System.Drawing.Size(400, 218);
            this.ptbbefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbbefore.TabIndex = 19;
            this.ptbbefore.TabStop = false;
            // 
            // timer_Inspect
            // 
            this.timer_Inspect.Tick += new System.EventHandler(this.timer_Inspect_Tick);
            // 
            // richText_message
            // 
            this.richText_message.Location = new System.Drawing.Point(44, 183);
            this.richText_message.Name = "richText_message";
            this.richText_message.Size = new System.Drawing.Size(147, 132);
            this.richText_message.TabIndex = 21;
            this.richText_message.Text = "";
            // 
            // btnPmove
            // 
            this.btnPmove.Enabled = false;
            this.btnPmove.Location = new System.Drawing.Point(6, 6);
            this.btnPmove.Name = "btnPmove";
            this.btnPmove.Size = new System.Drawing.Size(122, 33);
            this.btnPmove.TabIndex = 22;
            this.btnPmove.Text = "clockwise";
            this.btnPmove.UseVisualStyleBackColor = true;
            this.btnPmove.Click += new System.EventHandler(this.btnPmove_Click);
            // 
            // btnNmove
            // 
            this.btnNmove.Enabled = false;
            this.btnNmove.Location = new System.Drawing.Point(6, 45);
            this.btnNmove.Name = "btnNmove";
            this.btnNmove.Size = new System.Drawing.Size(122, 33);
            this.btnNmove.TabIndex = 23;
            this.btnNmove.Text = "anti-clockwise";
            this.btnNmove.UseVisualStyleBackColor = true;
            this.btnNmove.Click += new System.EventHandler(this.btnNmove_Click);
            // 
            // cboDIST
            // 
            this.cboDIST.Location = new System.Drawing.Point(384, 253);
            this.cboDIST.Name = "cboDIST";
            this.cboDIST.Size = new System.Drawing.Size(100, 27);
            this.cboDIST.TabIndex = 24;
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(384, 220);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(100, 27);
            this.txtMaxVel.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(277, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "motor speed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(340, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 19);
            this.label9.TabIndex = 27;
            this.label9.Text = "dist:";
            // 
            // btnRepeat
            // 
            this.btnRepeat.Enabled = false;
            this.btnRepeat.Location = new System.Drawing.Point(6, 82);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(122, 33);
            this.btnRepeat.TabIndex = 28;
            this.btnRepeat.Text = "repeat";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnAllStop
            // 
            this.btnAllStop.Enabled = false;
            this.btnAllStop.Location = new System.Drawing.Point(550, 15);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(147, 33);
            this.btnAllStop.TabIndex = 29;
            this.btnAllStop.Text = "All Stop";
            this.btnAllStop.UseVisualStyleBackColor = true;
            this.btnAllStop.Click += new System.EventHandler(this.btnAllStop_Click);
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(369, 109);
            this.txtERR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(136, 27);
            this.txtERR.TabIndex = 32;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(369, 62);
            this.txtspeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(136, 27);
            this.txtspeed.TabIndex = 33;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(369, 15);
            this.txtcommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(136, 27);
            this.txtcommand.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(280, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 19);
            this.label10.TabIndex = 35;
            this.label10.Text = "Command";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(309, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 19);
            this.label14.TabIndex = 36;
            this.label14.Text = "Speed";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(318, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 37;
            this.label12.Text = "Error";
            // 
            // lbxCam
            // 
            this.lbxCam.FormattingEnabled = true;
            this.lbxCam.ItemHeight = 19;
            this.lbxCam.Location = new System.Drawing.Point(664, 348);
            this.lbxCam.Name = "lbxCam";
            this.lbxCam.Size = new System.Drawing.Size(183, 80);
            this.lbxCam.TabIndex = 38;
            this.lbxCam.SelectedIndexChanged += new System.EventHandler(this.lbxCam_SelectedIndexChanged);
            // 
            // timer4PI
            // 
            this.timer4PI.Tick += new System.EventHandler(this.timer4PI_Tick);
            // 
            // timer_repeat
            // 
            this.timer_repeat.Interval = 500;
            this.timer_repeat.Tick += new System.EventHandler(this.timer_repeat_Tick);
            // 
            // bntResetPos
            // 
            this.bntResetPos.Enabled = false;
            this.bntResetPos.Location = new System.Drawing.Point(6, 162);
            this.bntResetPos.Name = "bntResetPos";
            this.bntResetPos.Size = new System.Drawing.Size(122, 33);
            this.bntResetPos.TabIndex = 39;
            this.bntResetPos.Text = " Reset Pos";
            this.bntResetPos.UseVisualStyleBackColor = true;
            this.bntResetPos.Click += new System.EventHandler(this.bntResetPos_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(6, 123);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(122, 33);
            this.btnStop.TabIndex = 40;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(305, 298);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 240);
            this.tabControl1.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPmove);
            this.tabPage1.Controls.Add(this.btnNmove);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Controls.Add(this.btnRepeat);
            this.tabPage1.Controls.Add(this.bntResetPos);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "04pi Node";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSaveimg
            // 
            this.btnSaveimg.Enabled = false;
            this.btnSaveimg.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSaveimg.Location = new System.Drawing.Point(890, 427);
            this.btnSaveimg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveimg.Name = "btnSaveimg";
            this.btnSaveimg.Size = new System.Drawing.Size(147, 80);
            this.btnSaveimg.TabIndex = 43;
            this.btnSaveimg.Text = "Save img";
            this.btnSaveimg.UseVisualStyleBackColor = true;
            this.btnSaveimg.Click += new System.EventHandler(this.btnSaveimg_Click);
            // 
            // lbworking
            // 
            this.lbworking.AutoSize = true;
            this.lbworking.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbworking.ForeColor = System.Drawing.Color.Red;
            this.lbworking.Location = new System.Drawing.Point(317, 164);
            this.lbworking.Name = "lbworking";
            this.lbworking.Size = new System.Drawing.Size(131, 30);
            this.lbworking.TabIndex = 44;
            this.lbworking.Text = "WORKING";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(209, -1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1065, 570);
            this.tabControl2.TabIndex = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnHE);
            this.tabPage2.Controls.Add(this.ptbyolo);
            this.tabPage2.Controls.Add(this.ptbafter);
            this.tabPage2.Controls.Add(this.ptbbefore);
            this.tabPage2.Controls.Add(this.btnSaveimg);
            this.tabPage2.Controls.Add(this.cmbCameraID);
            this.tabPage2.Controls.Add(this.lbxCam);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1057, 538);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "camera";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnHE
            // 
            this.btnHE.Enabled = false;
            this.btnHE.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHE.Location = new System.Drawing.Point(455, 309);
            this.btnHE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHE.Name = "btnHE";
            this.btnHE.Size = new System.Drawing.Size(147, 80);
            this.btnHE.TabIndex = 46;
            this.btnHE.Text = "HE";
            this.btnHE.UseVisualStyleBackColor = true;
            this.btnHE.Click += new System.EventHandler(this.btnHE_Click);
            // 
            // ptbyolo
            // 
            this.ptbyolo.Location = new System.Drawing.Point(455, 17);
            this.ptbyolo.Name = "ptbyolo";
            this.ptbyolo.Size = new System.Drawing.Size(582, 271);
            this.ptbyolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbyolo.TabIndex = 45;
            this.ptbyolo.TabStop = false;
            // 
            // ptbafter
            // 
            this.ptbafter.Location = new System.Drawing.Point(20, 271);
            this.ptbafter.Name = "ptbafter";
            this.ptbafter.Size = new System.Drawing.Size(400, 218);
            this.ptbafter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbafter.TabIndex = 44;
            this.ptbafter.TabStop = false;
            this.ptbafter.ImageChanged += new System.EventHandler(this.ptbafter_ImageChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.CmbCardNo);
            this.tabPage3.Controls.Add(this.lbworking);
            this.tabPage3.Controls.Add(this.btnAllStop);
            this.tabPage3.Controls.Add(this.txtcardnum);
            this.tabPage3.Controls.Add(this.txtslavenum);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.cmb04PInode);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.cmbDRIVERnode);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtcommand);
            this.tabPage3.Controls.Add(this.cmbIOnode);
            this.tabPage3.Controls.Add(this.txtspeed);
            this.tabPage3.Controls.Add(this.txtERR);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.cboDIST);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtMaxVel);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1057, 538);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "control";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1057, 538);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "model";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 570);
            this.Controls.Add(this.richText_message);
            this.Controls.Add(this.btnCameraConnect);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.txtCamState);
            this.Controls.Add(this.btnexit);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbbefore)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbyolo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbafter)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.TextBox txtcardnum;
        private System.Windows.Forms.TextBox txtslavenum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb04PInode;
        private System.Windows.Forms.ComboBox cmbDRIVERnode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIOnode;
        private System.Windows.Forms.Button btnCameraConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCameraID;
        private System.Windows.Forms.TextBox txtCamState;
        private System.Windows.Forms.PictureBox ptbbefore;
        private System.Windows.Forms.Timer timer_Inspect;
        private System.Windows.Forms.RichTextBox richText_message;
        private System.Windows.Forms.Button btnPmove;
        private System.Windows.Forms.Button btnNmove;
        private System.Windows.Forms.TextBox cboDIST;
        private System.Windows.Forms.TextBox txtMaxVel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Button btnAllStop;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.TextBox txtspeed;
        private System.Windows.Forms.TextBox txtcommand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbxCam;
        private System.Windows.Forms.Timer timer4PI;
        private System.Windows.Forms.Timer timer_repeat;
        private System.Windows.Forms.Button bntResetPos;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSaveimg;
        private System.Windows.Forms.Label lbworking;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox ptbyolo;
        private PictureEvent ptbafter;
        private System.Windows.Forms.Button btnHE;
    }
}

