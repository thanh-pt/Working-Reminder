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
            this.btnCheckinMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnCheckinMask.ForeColor = System.Drawing.Color.Black;
            this.btnCheckinMask.Location = new System.Drawing.Point(317, 267);
            this.btnCheckinMask.Name = "btnCheckinMask";
            this.btnCheckinMask.Size = new System.Drawing.Size(458, 108);
            this.btnCheckinMask.TabIndex = 2;
            this.btnCheckinMask.Text = "Check-in!";
            this.btnCheckinMask.Click += new System.EventHandler(this.btnCheckinMask_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckin.Location = new System.Drawing.Point(449, 379);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(94, 23);
            this.btnCheckin.TabIndex = 5;
            this.btnCheckin.Text = "I\'m Working";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Visible = false;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnRelax
            // 
            this.btnRelax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelax.Location = new System.Drawing.Point(549, 379);
            this.btnRelax.Name = "btnRelax";
            this.btnRelax.Size = new System.Drawing.Size(94, 23);
            this.btnRelax.TabIndex = 6;
            this.btnRelax.Text = "Relax!";
            this.btnRelax.UseVisualStyleBackColor = true;
            this.btnRelax.Visible = false;
            this.btnRelax.Click += new System.EventHandler(this.btnRelax_Click);
            // 
            // txtHistory
            // 
            this.txtHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHistory.BackColor = System.Drawing.SystemColors.Control;
            this.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHistory.Enabled = false;
            this.txtHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtHistory.Location = new System.Drawing.Point(436, 370);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.Size = new System.Drawing.Size(221, 150);
            this.txtHistory.TabIndex = 7;
            this.txtHistory.Text = "● 00:00:00    Hello\r\n";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 677);
            this.ControlBox = false;
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.btnCheckinMask);
            this.Controls.Add(this.btnRelax);
            this.Controls.Add(this.btnCheckin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💲💲💲 00:00:00";
            this.TopMost = true;
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
    }
}

