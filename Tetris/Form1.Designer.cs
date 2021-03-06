﻿namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlServer = new System.Windows.Forms.Panel();
            this.pnlServerInClient = new System.Windows.Forms.Panel();
            this.lbInfoServer = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnModeClassic = new System.Windows.Forms.Button();
            this.btnModeTime = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.pnlClientInServer = new System.Windows.Forms.Panel();
            this.lbInfoClient = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerWatch = new System.Windows.Forms.Timer(this.components);
            this.timerBegin = new System.Windows.Forms.Timer(this.components);
            this.lbWatch = new System.Windows.Forms.Label();
            this.lb3sPlay = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.btnSendMessenger = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lboxMessenger = new System.Windows.Forms.ListBox();
            this.pnlServer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServer
            // 
            this.pnlServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServer.Controls.Add(this.pnlServerInClient);
            this.pnlServer.Controls.Add(this.lbInfoServer);
            this.pnlServer.Controls.Add(this.panel3);
            this.pnlServer.Location = new System.Drawing.Point(12, 64);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(425, 850);
            this.pnlServer.TabIndex = 0;
            this.pnlServer.Visible = false;
            // 
            // pnlServerInClient
            // 
            this.pnlServerInClient.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlServerInClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlServerInClient.Location = new System.Drawing.Point(3, 3);
            this.pnlServerInClient.Name = "pnlServerInClient";
            this.pnlServerInClient.Size = new System.Drawing.Size(159, 136);
            this.pnlServerInClient.TabIndex = 8;
            // 
            // lbInfoServer
            // 
            this.lbInfoServer.AutoSize = true;
            this.lbInfoServer.Location = new System.Drawing.Point(200, 303);
            this.lbInfoServer.Name = "lbInfoServer";
            this.lbInfoServer.Size = new System.Drawing.Size(0, 17);
            this.lbInfoServer.TabIndex = 7;
            this.lbInfoServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(203, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(206, 136);
            this.panel3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "900";
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.txtIP);
            this.pnlLogin.Controls.Add(this.button1);
            this.pnlLogin.Controls.Add(this.label13);
            this.pnlLogin.Location = new System.Drawing.Point(443, 178);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(200, 149);
            this.pnlLogin.TabIndex = 7;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(17, 40);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(165, 22);
            this.txtIP.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "CONNECT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(79, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "IP";
            // 
            // btnModeClassic
            // 
            this.btnModeClassic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModeClassic.Location = new System.Drawing.Point(460, 451);
            this.btnModeClassic.Name = "btnModeClassic";
            this.btnModeClassic.Size = new System.Drawing.Size(160, 52);
            this.btnModeClassic.TabIndex = 9;
            this.btnModeClassic.Text = "CLASSIC MODE";
            this.btnModeClassic.UseVisualStyleBackColor = true;
            this.btnModeClassic.Click += new System.EventHandler(this.btnModeClassic_Click);
            // 
            // btnModeTime
            // 
            this.btnModeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModeTime.Location = new System.Drawing.Point(460, 361);
            this.btnModeTime.Name = "btnModeTime";
            this.btnModeTime.Size = new System.Drawing.Size(160, 52);
            this.btnModeTime.TabIndex = 8;
            this.btnModeTime.Text = "TIME MODE";
            this.btnModeTime.UseVisualStyleBackColor = true;
            this.btnModeTime.Click += new System.EventHandler(this.btnModeTime_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 900;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(667, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(203, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 136);
            this.panel2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Level";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Điểm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Speed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(107, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "900";
            // 
            // pnlClient
            // 
            this.pnlClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClient.Controls.Add(this.pnlClientInServer);
            this.pnlClient.Controls.Add(this.lbInfoClient);
            this.pnlClient.Controls.Add(this.panel2);
            this.pnlClient.Location = new System.Drawing.Point(650, 53);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(430, 861);
            this.pnlClient.TabIndex = 6;
            this.pnlClient.Visible = false;
            // 
            // pnlClientInServer
            // 
            this.pnlClientInServer.AccessibleDescription = "";
            this.pnlClientInServer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlClientInServer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlClientInServer.Location = new System.Drawing.Point(3, 3);
            this.pnlClientInServer.Name = "pnlClientInServer";
            this.pnlClientInServer.Size = new System.Drawing.Size(159, 136);
            this.pnlClientInServer.TabIndex = 7;
            // 
            // lbInfoClient
            // 
            this.lbInfoClient.AutoSize = true;
            this.lbInfoClient.Location = new System.Drawing.Point(158, 290);
            this.lbInfoClient.Name = "lbInfoClient";
            this.lbInfoClient.Size = new System.Drawing.Size(0, 17);
            this.lbInfoClient.TabIndex = 6;
            this.lbInfoClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(455, 57);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(165, 41);
            this.lbName.TabIndex = 8;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(443, 540);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 346);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1398, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // timerWatch
            // 
            this.timerWatch.Interval = 1000;
            this.timerWatch.Tick += new System.EventHandler(this.timerWatch_Tick);
            // 
            // timerBegin
            // 
            this.timerBegin.Interval = 1000;
            this.timerBegin.Tick += new System.EventHandler(this.timerBegin_Tick);
            // 
            // lbWatch
            // 
            this.lbWatch.AutoSize = true;
            this.lbWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWatch.Location = new System.Drawing.Point(508, 111);
            this.lbWatch.Name = "lbWatch";
            this.lbWatch.Size = new System.Drawing.Size(62, 25);
            this.lbWatch.TabIndex = 11;
            this.lbWatch.Text = "04:59";
            this.lbWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb3sPlay
            // 
            this.lb3sPlay.AutoSize = true;
            this.lb3sPlay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb3sPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 41F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3sPlay.Location = new System.Drawing.Point(200, 388);
            this.lb3sPlay.Name = "lb3sPlay";
            this.lb3sPlay.Size = new System.Drawing.Size(0, 79);
            this.lb3sPlay.TabIndex = 9;
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(1087, 577);
            this.txtNhap.Multiline = true;
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(299, 58);
            this.txtNhap.TabIndex = 13;
            this.txtNhap.Text = "Nhập tin nhắn";
            this.txtNhap.Visible = false;
            // 
            // btnSendMessenger
            // 
            this.btnSendMessenger.Location = new System.Drawing.Point(1194, 652);
            this.btnSendMessenger.Name = "btnSendMessenger";
            this.btnSendMessenger.Size = new System.Drawing.Size(83, 36);
            this.btnSendMessenger.TabIndex = 14;
            this.btnSendMessenger.Text = "Send";
            this.btnSendMessenger.UseVisualStyleBackColor = true;
            this.btnSendMessenger.Visible = false;
            this.btnSendMessenger.Click += new System.EventHandler(this.btnSendMessenger_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1087, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "CHAT";
            // 
            // lboxMessenger
            // 
            this.lboxMessenger.FormattingEnabled = true;
            this.lboxMessenger.ItemHeight = 16;
            this.lboxMessenger.Location = new System.Drawing.Point(1087, 119);
            this.lboxMessenger.Name = "lboxMessenger";
            this.lboxMessenger.Size = new System.Drawing.Size(299, 436);
            this.lboxMessenger.TabIndex = 16;
            this.lboxMessenger.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1398, 1055);
            this.Controls.Add(this.lboxMessenger);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSendMessenger);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.lb3sPlay);
            this.Controls.Add(this.btnModeClassic);
            this.Controls.Add(this.lbWatch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnModeTime);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlServer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbInfoClient;
        private System.Windows.Forms.Label lbInfoServer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Panel pnlServerInClient;
        private System.Windows.Forms.Panel pnlClientInServer;
        private System.Windows.Forms.Timer timerWatch;
        private System.Windows.Forms.Timer timerBegin;
        private System.Windows.Forms.Label lbWatch;
        private System.Windows.Forms.Button btnModeClassic;
        private System.Windows.Forms.Button btnModeTime;
        private System.Windows.Forms.Label lb3sPlay;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.Button btnSendMessenger;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lboxMessenger;
    }
}

