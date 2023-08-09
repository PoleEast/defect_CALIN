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
            this.timer4PI = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmb04PInode = new System.Windows.Forms.ComboBox();
            this.cmbDRIVERnode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIOnode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DMCtimer = new System.Windows.Forms.Timer(this.components);
            this.timerIO = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(81, 61);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(147, 80);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startbtn_Click_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnexit.Location = new System.Drawing.Point(81, 172);
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
            this.label1.Location = new System.Drawing.Point(341, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Card num:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(341, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Card No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(341, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Slave num:";
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(444, 148);
            this.CmbCardNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(136, 24);
            this.CmbCardNo.TabIndex = 6;
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(444, 85);
            this.txtcardnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.ReadOnly = true;
            this.txtcardnum.Size = new System.Drawing.Size(136, 23);
            this.txtcardnum.TabIndex = 7;
            // 
            // txtslavenum
            // 
            this.txtslavenum.Location = new System.Drawing.Point(444, 208);
            this.txtslavenum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtslavenum.Name = "txtslavenum";
            this.txtslavenum.ReadOnly = true;
            this.txtslavenum.Size = new System.Drawing.Size(136, 23);
            this.txtslavenum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "04pi Node ID";
            // 
            // cmb04PInode
            // 
            this.cmb04PInode.FormattingEnabled = true;
            this.cmb04PInode.Location = new System.Drawing.Point(444, 257);
            this.cmb04PInode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb04PInode.Name = "cmb04PInode";
            this.cmb04PInode.Size = new System.Drawing.Size(136, 24);
            this.cmb04PInode.TabIndex = 10;
            // 
            // cmbDRIVERnode
            // 
            this.cmbDRIVERnode.FormattingEnabled = true;
            this.cmbDRIVERnode.Location = new System.Drawing.Point(444, 312);
            this.cmbDRIVERnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDRIVERnode.Name = "cmbDRIVERnode";
            this.cmbDRIVERnode.Size = new System.Drawing.Size(136, 24);
            this.cmbDRIVERnode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "馬達編號";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "I/O Node ID";
            // 
            // cmbIOnode
            // 
            this.cmbIOnode.FormattingEnabled = true;
            this.cmbIOnode.Location = new System.Drawing.Point(444, 363);
            this.cmbIOnode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbIOnode.Name = "cmbIOnode";
            this.cmbIOnode.Size = new System.Drawing.Size(136, 24);
            this.cmbIOnode.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "I/O Node ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(444, 416);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(34, 23);
            this.textBox1.TabIndex = 16;
            // 
            // DMCtimer
            // 
            this.DMCtimer.Interval = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
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
        private System.Windows.Forms.Timer timer4PI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb04PInode;
        private System.Windows.Forms.ComboBox cmbDRIVERnode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIOnode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer DMCtimer;
        private System.Windows.Forms.Timer timerIO;
    }
}

