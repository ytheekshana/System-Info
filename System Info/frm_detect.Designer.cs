namespace System_Info
{
    partial class frm_detect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_detect));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgw_detect = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblprogressinfo = new System.Windows.Forms.Label();
            this.lblappinfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 18);
            this.progressBar1.TabIndex = 7;
            // 
            // bgw_detect
            // 
            this.bgw_detect.WorkerReportsProgress = true;
            this.bgw_detect.WorkerSupportsCancellation = true;
            this.bgw_detect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_detect_DoWork);
            this.bgw_detect.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_detect_ProgressChanged);
            this.bgw_detect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_detect_RunWorkerCompleted);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 76);
            this.label4.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(360, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 76);
            this.label3.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 3);
            this.label2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 3);
            this.label1.TabIndex = 10;
            // 
            // lblprogressinfo
            // 
            this.lblprogressinfo.AutoSize = true;
            this.lblprogressinfo.BackColor = System.Drawing.Color.Transparent;
            this.lblprogressinfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprogressinfo.ForeColor = System.Drawing.Color.Black;
            this.lblprogressinfo.Location = new System.Drawing.Point(24, 50);
            this.lblprogressinfo.Name = "lblprogressinfo";
            this.lblprogressinfo.Size = new System.Drawing.Size(88, 13);
            this.lblprogressinfo.TabIndex = 8;
            this.lblprogressinfo.Text = "Getting CPU Info";
            // 
            // lblappinfo
            // 
            this.lblappinfo.BackColor = System.Drawing.Color.Transparent;
            this.lblappinfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblappinfo.ForeColor = System.Drawing.Color.Black;
            this.lblappinfo.Location = new System.Drawing.Point(187, 47);
            this.lblappinfo.Name = "lblappinfo";
            this.lblappinfo.Size = new System.Drawing.Size(151, 19);
            this.lblappinfo.TabIndex = 9;
            this.lblappinfo.Text = "System Info 1.3 - 64Bit";
            this.lblappinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_detect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 82);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblprogressinfo);
            this.Controls.Add(this.lblappinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_detect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detecting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_detect_FormClosing);
            this.Load += new System.EventHandler(this.frm_detect_Load);
            this.Shown += new System.EventHandler(this.frm_detect_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        public System.ComponentModel.BackgroundWorker bgw_detect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblprogressinfo;
        private System.Windows.Forms.Label lblappinfo;
    }
}