﻿namespace omokproto1
{
    partial class Form1
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jiwan_rb);
            this.groupBox1.Controls.Add(this.hard_rb);
            this.groupBox1.Controls.Add(this.normal_rb);
            this.groupBox1.Location = new System.Drawing.Point(821, 254);
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
            this.normal_rb.Size = new System.Drawing.Size(82, 23);
            this.normal_rb.TabIndex = 1;
            this.normal_rb.TabStop = true;
            this.normal_rb.Text = "normal";
            this.normal_rb.UseVisualStyleBackColor = true;
            this.normal_rb.Click += new System.EventHandler(this.difficult_changed);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(894, 506);
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
            this.omokpan.Location = new System.Drawing.Point(10, 10);
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
            this.win_lb.Location = new System.Drawing.Point(821, 155);
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
            this.cmb_first.Location = new System.Drawing.Point(894, 473);
            this.cmb_first.Name = "cmb_first";
            this.cmb_first.Size = new System.Drawing.Size(155, 27);
            this.cmb_first.TabIndex = 5;
            this.cmb_first.Text = "유저 선수";
            // 
            // explainer_lb
            // 
            this.explainer_lb.AutoSize = true;
            this.explainer_lb.Location = new System.Drawing.Point(843, 671);
            this.explainer_lb.Name = "explainer_lb";
            this.explainer_lb.Size = new System.Drawing.Size(38, 12);
            this.explainer_lb.TabIndex = 6;
            this.explainer_lb.Text = "label1";
            this.explainer_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 822);
            this.Controls.Add(this.explainer_lb);
            this.Controls.Add(this.cmb_first);
            this.Controls.Add(this.win_lb);
            this.Controls.Add(this.omokpan);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "omok";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

