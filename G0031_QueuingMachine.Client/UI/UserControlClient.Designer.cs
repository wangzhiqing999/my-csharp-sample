namespace G0031_QueuingMachine.Client.UI
{
    partial class UserControlClient
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNumberInfo = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblWindow = new System.Windows.Forms.Label();
            this.pnlWork = new System.Windows.Forms.Panel();
            this.lblWorkInfo = new System.Windows.Forms.Label();
            this.timerProcess = new System.Windows.Forms.Timer(this.components);
            this.lblTimes = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.pnlWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumberInfo
            // 
            this.lblNumberInfo.AutoSize = true;
            this.lblNumberInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumberInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumberInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNumberInfo.Location = new System.Drawing.Point(5, 2);
            this.lblNumberInfo.Name = "lblNumberInfo";
            this.lblNumberInfo.Size = new System.Drawing.Size(196, 35);
            this.lblNumberInfo.TabIndex = 0;
            this.lblNumberInfo.Text = "123456";
            this.lblNumberInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblNumberInfo, 0, 0);
            this.tlpMain.Controls.Add(this.lblWindow, 0, 2);
            this.tlpMain.Controls.Add(this.pnlWork, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.Size = new System.Drawing.Size(206, 217);
            this.tlpMain.TabIndex = 1;
            // 
            // lblWindow
            // 
            this.lblWindow.AutoSize = true;
            this.lblWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWindow.Location = new System.Drawing.Point(5, 180);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(196, 35);
            this.lblWindow.TabIndex = 1;
            this.lblWindow.Text = "1";
            this.lblWindow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlWork
            // 
            this.pnlWork.Controls.Add(this.lblTimes);
            this.pnlWork.Controls.Add(this.lblWorkInfo);
            this.pnlWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWork.Location = new System.Drawing.Point(5, 42);
            this.pnlWork.Name = "pnlWork";
            this.pnlWork.Size = new System.Drawing.Size(196, 133);
            this.pnlWork.TabIndex = 2;
            // 
            // lblWorkInfo
            // 
            this.lblWorkInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkInfo.Location = new System.Drawing.Point(14, 11);
            this.lblWorkInfo.Name = "lblWorkInfo";
            this.lblWorkInfo.Size = new System.Drawing.Size(164, 64);
            this.lblWorkInfo.TabIndex = 0;
            this.lblWorkInfo.Text = "-";
            // 
            // timerProcess
            // 
            this.timerProcess.Interval = 1000;
            this.timerProcess.Tick += new System.EventHandler(this.timerProcess_Tick);
            // 
            // lblTimes
            // 
            this.lblTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimes.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTimes.Location = new System.Drawing.Point(16, 98);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(162, 23);
            this.lblTimes.TabIndex = 1;
            this.lblTimes.Text = "0/1";
            this.lblTimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "UserControlClient";
            this.Size = new System.Drawing.Size(206, 217);
            this.Load += new System.EventHandler(this.UserControlClient_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlWork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumberInfo;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblWindow;
        private System.Windows.Forms.Panel pnlWork;
        private System.Windows.Forms.Label lblWorkInfo;
        private System.Windows.Forms.Timer timerProcess;
        private System.Windows.Forms.Label lblTimes;
    }
}
