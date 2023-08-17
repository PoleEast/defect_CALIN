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
            this.DMCtimer = new System.Windows.Forms.Timer(this.components);
            this.btnCameraConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCameraID = new System.Windows.Forms.ComboBox();
            this.txtCamState = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtcommand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtspeed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbxCam = new System.Windows.Forms.ListBox();
            this.timer4PI = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bntResetPos = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSaveimg = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(44, 37);
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
            this.label1.Location = new System.Drawing.Point(214, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Card num:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(214, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Card No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(214, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Slave num:";
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(317, 100);
            this.CmbCardNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(136, 24);
            this.CmbCardNo.TabIndex = 6;
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(317, 37);
            this.txtcardnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.ReadOnly = true;
            this.txtcardnum.Size = new System.Drawing.Size(136, 23);
            this.txtcardnum.TabIndex = 7;
            // 
            // txtslavenum
            // 
            this.txtslavenum.Location = new System.Drawing.Point(317, 160);
            this.txtslavenum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtslavenum.Name = "txtslavenum";
            this.txtslavenum.ReadOnly = true;
            this.txtslavenum.Size = new System.Drawing.Size(136, 23);
            this.txtslavenum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "04pi Node ID";
            // 
            // cmb04PInode
            // 
            this.cmb04PInode.FormattingEnabled = true;
            this.cmb04PInode.Location = new System.Drawing.Point(317, 209);
            this.cmb04PInode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb04PInode.Name = "cmb04PInode";
            this.cmb04PInode.Size = new System.Drawing.Size(136, 24);
            this.cmb04PInode.TabIndex = 10;
            // 
            // cmbDRIVERnode
            // 
            this.cmbDRIVERnode.FormattingEnabled = true;
            this.cmbDRIVERnode.Location = new System.Drawing.Point(317, 264);
            this.cmbDRIVERnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDRIVERnode.Name = "cmbDRIVERnode";
            this.cmbDRIVERnode.Size = new System.Drawing.Size(136, 24);
            this.cmbDRIVERnode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "motor num";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "I/O Node ID";
            // 
            // cmbIOnode
            // 
            this.cmbIOnode.FormattingEnabled = true;
            this.cmbIOnode.Location = new System.Drawing.Point(317, 315);
            this.cmbIOnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbIOnode.Name = "cmbIOnode";
            this.cmbIOnode.Size = new System.Drawing.Size(136, 24);
            this.cmbIOnode.TabIndex = 14;
            // 
            // DMCtimer
            // 
            this.DMCtimer.Interval = 200;
            // 
            // btnCameraConnect
            // 
            this.btnCameraConnect.Enabled = false;
            this.btnCameraConnect.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCameraConnect.Location = new System.Drawing.Point(44, 338);
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
            this.label7.Location = new System.Drawing.Point(214, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Camera ID";
            // 
            // cmbCameraID
            // 
            this.cmbCameraID.FormattingEnabled = true;
            this.cmbCameraID.Location = new System.Drawing.Point(317, 361);
            this.cmbCameraID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCameraID.Name = "cmbCameraID";
            this.cmbCameraID.Size = new System.Drawing.Size(136, 24);
            this.cmbCameraID.TabIndex = 17;
            this.cmbCameraID.SelectedIndexChanged += new System.EventHandler(this.cmbCameraID_SelectedIndexChanged);
            // 
            // txtCamState
            // 
            this.txtCamState.Location = new System.Drawing.Point(44, 424);
            this.txtCamState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCamState.Name = "txtCamState";
            this.txtCamState.ReadOnly = true;
            this.txtCamState.Size = new System.Drawing.Size(147, 23);
            this.txtCamState.TabIndex = 18;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(712, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(427, 348);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 19;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // timer_Inspect
            // 
            this.timer_Inspect.Tick += new System.EventHandler(this.timer_Inspect_Tick);
            // 
            // richText_message
            // 
            this.richText_message.Location = new System.Drawing.Point(44, 190);
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
            this.cboDIST.Location = new System.Drawing.Point(574, 275);
            this.cboDIST.Name = "cboDIST";
            this.cboDIST.Size = new System.Drawing.Size(100, 23);
            this.cboDIST.TabIndex = 24;
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(574, 242);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(100, 23);
            this.txtMaxVel.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(467, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "motor speed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(530, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "dist:";
            // 
            // btnRepeat
            // 
            this.btnRepeat.Enabled = false;
            this.btnRepeat.Location = new System.Drawing.Point(6, 84);
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
            this.btnAllStop.Location = new System.Drawing.Point(44, 131);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(147, 33);
            this.btnAllStop.TabIndex = 29;
            this.btnAllStop.Text = "All Stop";
            this.btnAllStop.UseVisualStyleBackColor = true;
            this.btnAllStop.Click += new System.EventHandler(this.btnAllStop_Click);
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(559, 131);
            this.txtERR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(136, 23);
            this.txtERR.TabIndex = 32;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(559, 84);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(136, 23);
            this.textBox3.TabIndex = 33;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(559, 37);
            this.txtcommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(136, 23);
            this.txtcommand.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(470, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Command";
            // 
            // txtspeed
            // 
            this.txtspeed.AutoSize = true;
            this.txtspeed.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtspeed.Location = new System.Drawing.Point(499, 85);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.Size = new System.Drawing.Size(45, 16);
            this.txtspeed.TabIndex = 36;
            this.txtspeed.Text = "Speed";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(508, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Error";
            // 
            // lbxCam
            // 
            this.lbxCam.FormattingEnabled = true;
            this.lbxCam.ItemHeight = 16;
            this.lbxCam.Location = new System.Drawing.Point(267, 400);
            this.lbxCam.Name = "lbxCam";
            this.lbxCam.Size = new System.Drawing.Size(183, 84);
            this.lbxCam.TabIndex = 38;
            this.lbxCam.SelectedIndexChanged += new System.EventHandler(this.lbxCam_SelectedIndexChanged);
            // 
            // timer4PI
            // 
            this.timer4PI.Tick += new System.EventHandler(this.timer4PI_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.tabControl1.Location = new System.Drawing.Point(474, 308);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "04pi Node";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSaveimg
            // 
            this.btnSaveimg.Enabled = false;
            this.btnSaveimg.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSaveimg.Location = new System.Drawing.Point(712, 381);
            this.btnSaveimg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveimg.Name = "btnSaveimg";
            this.btnSaveimg.Size = new System.Drawing.Size(147, 80);
            this.btnSaveimg.TabIndex = 43;
            this.btnSaveimg.Text = "Save img";
            this.btnSaveimg.UseVisualStyleBackColor = true;
            this.btnSaveimg.Click += new System.EventHandler(this.btnSaveimg_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(507, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 24);
            this.label11.TabIndex = 44;
            this.label11.Text = "WORKING";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 570);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSaveimg);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbxCam);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtspeed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtcommand);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtERR);
            this.Controls.Add(this.btnAllStop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMaxVel);
            this.Controls.Add(this.cboDIST);
            this.Controls.Add(this.richText_message);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txtCamState);
            this.Controls.Add(this.cmbCameraID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCameraConnect);
            this.Controls.Add(this.cmbIOnode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDRIVERnode);
            this.Controls.Add(this.cmb04PInode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtslavenum);
            this.Controls.Add(this.txtcardnum);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.Timer DMCtimer;
        private System.Windows.Forms.Button btnCameraConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCameraID;
        private System.Windows.Forms.TextBox txtCamState;
        private System.Windows.Forms.PictureBox pictureBox;
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtcommand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtspeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbxCam;
        private System.Windows.Forms.Timer timer4PI;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bntResetPos;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSaveimg;
        private System.Windows.Forms.Label label11;
    }
}

