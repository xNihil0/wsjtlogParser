namespace wsjtlogParser
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblCallsign = new System.Windows.Forms.Label();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.fdlgLog = new System.Windows.Forms.OpenFileDialog();
            this.lblGridSquare = new System.Windows.Forms.Label();
            this.txtGrid = new System.Windows.Forms.TextBox();
            this.lblSig = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCallsign
            // 
            this.lblCallsign.AutoSize = true;
            this.lblCallsign.Location = new System.Drawing.Point(12, 9);
            this.lblCallsign.Name = "lblCallsign";
            this.lblCallsign.Size = new System.Drawing.Size(89, 12);
            this.lblCallsign.TabIndex = 4;
            this.lblCallsign.Text = "Your Callsign:";
            // 
            // txtCallsign
            // 
            this.txtCallsign.Location = new System.Drawing.Point(107, 6);
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(100, 21);
            this.txtCallsign.TabIndex = 1;
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point(12, 63);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(59, 12);
            this.lblLogPath.TabIndex = 6;
            this.lblLogPath.Text = "Log File:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(106, 58);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open&&Parse";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // fdlgLog
            // 
            this.fdlgLog.DefaultExt = "log";
            this.fdlgLog.Filter = "WSJT-X Log|wsjtx.log|WSJT-X Log|*.log";
            // 
            // lblGridSquare
            // 
            this.lblGridSquare.AutoSize = true;
            this.lblGridSquare.Location = new System.Drawing.Point(12, 36);
            this.lblGridSquare.Name = "lblGridSquare";
            this.lblGridSquare.Size = new System.Drawing.Size(65, 12);
            this.lblGridSquare.TabIndex = 5;
            this.lblGridSquare.Text = "Your Grid:";
            // 
            // txtGrid
            // 
            this.txtGrid.Location = new System.Drawing.Point(107, 33);
            this.txtGrid.Name = "txtGrid";
            this.txtGrid.Size = new System.Drawing.Size(100, 21);
            this.txtGrid.TabIndex = 2;
            // 
            // lblSig
            // 
            this.lblSig.AutoSize = true;
            this.lblSig.Location = new System.Drawing.Point(206, 64);
            this.lblSig.Name = "lblSig";
            this.lblSig.Size = new System.Drawing.Size(71, 12);
            this.lblSig.TabIndex = 7;
            this.lblSig.Text = "2019 BH4ESB";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 85);
            this.Controls.Add(this.lblSig);
            this.Controls.Add(this.txtGrid);
            this.Controls.Add(this.lblGridSquare);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblLogPath);
            this.Controls.Add(this.txtCallsign);
            this.Controls.Add(this.lblCallsign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "WSJT-X Log Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCallsign;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog fdlgLog;
        private System.Windows.Forms.Label lblGridSquare;
        private System.Windows.Forms.TextBox txtGrid;
        private System.Windows.Forms.Label lblSig;
    }
}

