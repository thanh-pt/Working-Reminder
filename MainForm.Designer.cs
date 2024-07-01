namespace Working_Reminder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reqRelaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheckinMask = new System.Windows.Forms.Label();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.btnRelax = new System.Windows.Forms.Button();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.listDate = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Working Reminder";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reqRelaxToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 48);
            // 
            // reqRelaxToolStripMenuItem
            // 
            this.reqRelaxToolStripMenuItem.Name = "reqRelaxToolStripMenuItem";
            this.reqRelaxToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.reqRelaxToolStripMenuItem.Text = "Req Relax";
            this.reqRelaxToolStripMenuItem.Click += new System.EventHandler(this.btnRelax_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // btnCheckinMask
            // 
            this.btnCheckinMask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckinMask.AutoSize = true;
            this.btnCheckinMask.Font = new System.Drawing.Font("Consolas", 68F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnCheckinMask.ForeColor = System.Drawing.Color.Black;
            this.btnCheckinMask.Location = new System.Drawing.Point(-7, 25);
            this.btnCheckinMask.Name = "btnCheckinMask";
            this.btnCheckinMask.Size = new System.Drawing.Size(495, 107);
            this.btnCheckinMask.TabIndex = 0;
            this.btnCheckinMask.Text = "Check-in!";
            this.btnCheckinMask.Click += new System.EventHandler(this.btnCheckinMask_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckin.Location = new System.Drawing.Point(146, 116);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(94, 23);
            this.btnCheckin.TabIndex = 1;
            this.btnCheckin.Text = "I\'m Working";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Visible = false;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnRelax
            // 
            this.btnRelax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelax.Location = new System.Drawing.Point(246, 116);
            this.btnRelax.Name = "btnRelax";
            this.btnRelax.Size = new System.Drawing.Size(94, 23);
            this.btnRelax.TabIndex = 2;
            this.btnRelax.Text = "Relax!";
            this.btnRelax.UseVisualStyleBackColor = true;
            this.btnRelax.Visible = false;
            this.btnRelax.Click += new System.EventHandler(this.btnRelax_Click);
            // 
            // txtHistory
            // 
            this.txtHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHistory.BackColor = System.Drawing.SystemColors.Control;
            this.txtHistory.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtHistory.Location = new System.Drawing.Point(159, 142);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(313, 160);
            this.txtHistory.TabIndex = 0;
            this.txtHistory.Text = "💻 00:00:00  ~  ⛏ 00:00:00  ~  👌 100%\r\n----------------------------------------\r" +
    "\n- 00:00:15\tdevenv\r\n- 00:00:12\tvlc\r\n- 00:00:02\tWorking Reminder\r\n- 00:00:02\tFoxi" +
    "tPDFReader\r\n- 00:00:01\tIdle";
            // 
            // listDate
            // 
            this.listDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listDate.FormattingEnabled = true;
            this.listDate.Location = new System.Drawing.Point(11, 142);
            this.listDate.Name = "listDate";
            this.listDate.Size = new System.Drawing.Size(142, 160);
            this.listDate.TabIndex = 3;
            this.listDate.Click += new System.EventHandler(this.listDate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.ControlBox = false;
            this.Controls.Add(this.btnRelax);
            this.Controls.Add(this.btnCheckin);
            this.Controls.Add(this.listDate);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.btnCheckinMask);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "⛏ 00:00:00 ➝ 💰";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label btnCheckinMask;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Button btnRelax;
        private System.Windows.Forms.ToolStripMenuItem reqRelaxToolStripMenuItem;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.ListBox listDate;
    }
}

