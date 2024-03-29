﻿using Emgu.CV.UI;
namespace omokproto1
{
    partial class omokbot
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jiwan_rb = new System.Windows.Forms.RadioButton();
            this.hard_rb = new System.Windows.Forms.RadioButton();
            this.normal_rb = new System.Windows.Forms.RadioButton();
            this.start_btn = new System.Windows.Forms.Button();
            this.omokpan = new System.Windows.Forms.Panel();
            this.win_lb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmb_first = new System.Windows.Forms.ComboBox();
            this.explainer_lb = new System.Windows.Forms.Label();
            this.gbx_omokbot = new System.Windows.Forms.GroupBox();
            this.aitext = new System.Windows.Forms.Label();
            this.aiface = new System.Windows.Forms.PictureBox();
            this.control = new System.Windows.Forms.GroupBox();
            this.home_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SerialSend_bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Y_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.X_tb = new System.Windows.Forms.TextBox();
            this.Gbx_processing = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cap_btn = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.originalImageBox = new Emgu.CV.UI.ImageBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cvtimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.gbx_omokbot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aiface)).BeginInit();
            this.control.SuspendLayout();
            this.Gbx_processing.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cap_btn)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jiwan_rb);
            this.groupBox1.Controls.Add(this.hard_rb);
            this.groupBox1.Controls.Add(this.normal_rb);
            this.groupBox1.Location = new System.Drawing.Point(810, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 205);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "난이도 선택";
            // 
            // jiwan_rb
            // 
            this.jiwan_rb.AutoSize = true;
            this.jiwan_rb.Font = new System.Drawing.Font("굴림", 14F);
            this.jiwan_rb.Location = new System.Drawing.Point(110, 157);
            this.jiwan_rb.Name = "jiwan_rb";
            this.jiwan_rb.Size = new System.Drawing.Size(68, 23);
            this.jiwan_rb.TabIndex = 3;
            this.jiwan_rb.TabStop = true;
            this.jiwan_rb.Text = "jiwan";
            this.jiwan_rb.UseVisualStyleBackColor = true;
            this.jiwan_rb.Click += new System.EventHandler(this.difficult_changed);
            // 
            // hard_rb
            // 
            this.hard_rb.AutoSize = true;
            this.hard_rb.Font = new System.Drawing.Font("굴림", 14F);
            this.hard_rb.Location = new System.Drawing.Point(110, 93);
            this.hard_rb.Name = "hard_rb";
            this.hard_rb.Size = new System.Drawing.Size(63, 23);
            this.hard_rb.TabIndex = 2;
            this.hard_rb.TabStop = true;
            this.hard_rb.Text = "hard";
            this.hard_rb.UseVisualStyleBackColor = true;
            this.hard_rb.Click += new System.EventHandler(this.difficult_changed);
            // 
            // normal_rb
            // 
            this.normal_rb.AutoSize = true;
            this.normal_rb.Font = new System.Drawing.Font("굴림", 14F);
            this.normal_rb.Location = new System.Drawing.Point(110, 30);
            this.normal_rb.Name = "normal_rb";
            this.normal_rb.Size = new System.Drawing.Size(67, 23);
            this.normal_rb.TabIndex = 1;
            this.normal_rb.TabStop = true;
            this.normal_rb.Text = "easy";
            this.normal_rb.UseVisualStyleBackColor = true;
            this.normal_rb.Click += new System.EventHandler(this.difficult_changed);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(883, 640);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(155, 50);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // omokpan
            // 
            this.omokpan.BackColor = System.Drawing.Color.Orange;
            this.omokpan.Location = new System.Drawing.Point(6, 20);
            this.omokpan.Name = "omokpan";
            this.omokpan.Size = new System.Drawing.Size(800, 800);
            this.omokpan.TabIndex = 3;
            this.omokpan.Paint += new System.Windows.Forms.PaintEventHandler(this.Omokpan_Paint);
            this.omokpan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.omokpan_MouseDown_1);
            // 
            // win_lb
            // 
            this.win_lb.BackColor = System.Drawing.Color.Transparent;
            this.win_lb.Font = new System.Drawing.Font("굴림", 15F);
            this.win_lb.Location = new System.Drawing.Point(813, 910);
            this.win_lb.Name = "win_lb";
            this.win_lb.Size = new System.Drawing.Size(282, 20);
            this.win_lb.TabIndex = 4;
            this.win_lb.Text = "label1";
            this.win_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // cmb_first
            // 
            this.cmb_first.Font = new System.Drawing.Font("굴림", 14F);
            this.cmb_first.FormattingEnabled = true;
            this.cmb_first.Items.AddRange(new object[] {
            "유저 선수",
            "AI 선수"});
            this.cmb_first.Location = new System.Drawing.Point(883, 607);
            this.cmb_first.Name = "cmb_first";
            this.cmb_first.Size = new System.Drawing.Size(155, 27);
            this.cmb_first.TabIndex = 5;
            this.cmb_first.Text = "유저 선수";
            // 
            // explainer_lb
            // 
            this.explainer_lb.Location = new System.Drawing.Point(817, 746);
            this.explainer_lb.Name = "explainer_lb";
            this.explainer_lb.Size = new System.Drawing.Size(275, 66);
            this.explainer_lb.TabIndex = 6;
            this.explainer_lb.Text = "label1";
            this.explainer_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbx_omokbot
            // 
            this.gbx_omokbot.Controls.Add(this.aitext);
            this.gbx_omokbot.Controls.Add(this.aiface);
            this.gbx_omokbot.Controls.Add(this.control);
            this.gbx_omokbot.Controls.Add(this.start_btn);
            this.gbx_omokbot.Controls.Add(this.win_lb);
            this.gbx_omokbot.Controls.Add(this.omokpan);
            this.gbx_omokbot.Controls.Add(this.groupBox1);
            this.gbx_omokbot.Controls.Add(this.cmb_first);
            this.gbx_omokbot.Controls.Add(this.explainer_lb);
            this.gbx_omokbot.Location = new System.Drawing.Point(10, 10);
            this.gbx_omokbot.Name = "gbx_omokbot";
            this.gbx_omokbot.Size = new System.Drawing.Size(1101, 1019);
            this.gbx_omokbot.TabIndex = 8;
            this.gbx_omokbot.TabStop = false;
            this.gbx_omokbot.Text = "OMOKBOT";
            // 
            // aitext
            // 
            this.aitext.AllowDrop = true;
            this.aitext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aitext.Location = new System.Drawing.Point(819, 313);
            this.aitext.Name = "aitext";
            this.aitext.Size = new System.Drawing.Size(273, 43);
            this.aitext.TabIndex = 10;
            this.aitext.Text = "덤벼라 애송이";
            this.aitext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aiface
            // 
            this.aiface.Image = global::omokproto1.Properties.Resources.playerturn1;
            this.aiface.Location = new System.Drawing.Point(817, 22);
            this.aiface.Name = "aiface";
            this.aiface.Size = new System.Drawing.Size(275, 266);
            this.aiface.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aiface.TabIndex = 9;
            this.aiface.TabStop = false;
            // 
            // control
            // 
            this.control.Controls.Add(this.home_btn);
            this.control.Controls.Add(this.button1);
            this.control.Controls.Add(this.label3);
            this.control.Controls.Add(this.listView1);
            this.control.Controls.Add(this.SerialSend_bt);
            this.control.Controls.Add(this.label2);
            this.control.Controls.Add(this.Y_tb);
            this.control.Controls.Add(this.label1);
            this.control.Controls.Add(this.X_tb);
            this.control.Location = new System.Drawing.Point(6, 830);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(800, 183);
            this.control.TabIndex = 8;
            this.control.TabStop = false;
            this.control.Text = "수동 조작";
            // 
            // home_btn
            // 
            this.home_btn.Location = new System.Drawing.Point(6, 108);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(58, 65);
            this.home_btn.TabIndex = 14;
            this.home_btn.Text = "home";
            this.home_btn.UseVisualStyleBackColor = true;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "serialport";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(394, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(398, 157);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // SerialSend_bt
            // 
            this.SerialSend_bt.Location = new System.Drawing.Point(70, 108);
            this.SerialSend_bt.Name = "SerialSend_bt";
            this.SerialSend_bt.Size = new System.Drawing.Size(75, 65);
            this.SerialSend_bt.TabIndex = 11;
            this.SerialSend_bt.Text = "SerialSend";
            this.SerialSend_bt.UseVisualStyleBackColor = true;
            this.SerialSend_bt.Click += new System.EventHandler(this.SerialSend_bt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y";
            // 
            // Y_tb
            // 
            this.Y_tb.Location = new System.Drawing.Point(45, 72);
            this.Y_tb.Name = "Y_tb";
            this.Y_tb.Size = new System.Drawing.Size(100, 21);
            this.Y_tb.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // X_tb
            // 
            this.X_tb.Location = new System.Drawing.Point(45, 42);
            this.X_tb.Name = "X_tb";
            this.X_tb.Size = new System.Drawing.Size(100, 21);
            this.X_tb.TabIndex = 7;
            // 
            // Gbx_processing
            // 
            this.Gbx_processing.Controls.Add(this.groupBox3);
            this.Gbx_processing.Controls.Add(this.groupBox2);
            this.Gbx_processing.Location = new System.Drawing.Point(1117, 12);
            this.Gbx_processing.Name = "Gbx_processing";
            this.Gbx_processing.Size = new System.Drawing.Size(775, 1017);
            this.Gbx_processing.TabIndex = 9;
            this.Gbx_processing.TabStop = false;
            this.Gbx_processing.Text = "VideoProcessing";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.cap_btn);
            this.groupBox3.Location = new System.Drawing.Point(6, 506);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(763, 480);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "processing";
            // 
            // cap_btn
            // 
            this.cap_btn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cap_btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cap_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cap_btn.Location = new System.Drawing.Point(3, 17);
            this.cap_btn.Margin = new System.Windows.Forms.Padding(0);
            this.cap_btn.Name = "cap_btn";
            this.cap_btn.Size = new System.Drawing.Size(757, 460);
            this.cap_btn.TabIndex = 5;
            this.cap_btn.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.originalImageBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(763, 480);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "원본";
            // 
            // originalImageBox
            // 
            this.originalImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.originalImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImageBox.Location = new System.Drawing.Point(3, 17);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(757, 460);
            this.originalImageBox.TabIndex = 4;
            this.originalImageBox.TabStop = false;
            // 
            // cvtimer
            // 
            this.cvtimer.Interval = 30;
            this.cvtimer.Tick += new System.EventHandler(this.cvtimer_Tick);
            // 
            // omokbot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Gbx_processing);
            this.Controls.Add(this.gbx_omokbot);
            this.Name = "omokbot";
            this.Text = "omok";
            this.Load += new System.EventHandler(this.omokbot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbx_omokbot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aiface)).EndInit();
            this.control.ResumeLayout(false);
            this.control.PerformLayout();
            this.Gbx_processing.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cap_btn)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton hard_rb;
        private System.Windows.Forms.RadioButton normal_rb;
        private System.Windows.Forms.RadioButton jiwan_rb;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel omokpan;
        private System.Windows.Forms.Label win_lb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmb_first;
        private System.Windows.Forms.Label explainer_lb;
        private System.Windows.Forms.GroupBox gbx_omokbot;
        private System.Windows.Forms.GroupBox Gbx_processing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox control;
        private System.Windows.Forms.Button SerialSend_bt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Y_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox X_tb;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer cvtimer;
        private Emgu.CV.UI.ImageBox originalImageBox;
        private Emgu.CV.UI.ImageBox cap_btn;
        private System.Windows.Forms.PictureBox aiface;
        private System.Windows.Forms.Label aitext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button home_btn;
    }
}

