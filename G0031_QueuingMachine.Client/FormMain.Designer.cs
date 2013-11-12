namespace G0031_QueuingMachine.Client
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.userControlClient1 = new G0031_QueuingMachine.Client.UI.UserControlClient();
            this.userControlClient2 = new G0031_QueuingMachine.Client.UI.UserControlClient();
            this.userControlClient3 = new G0031_QueuingMachine.Client.UI.UserControlClient();
            this.userControlClient4 = new G0031_QueuingMachine.Client.UI.UserControlClient();
            this.userControlClient5 = new G0031_QueuingMachine.Client.UI.UserControlClient();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Controls.Add(this.userControlClient1, 0, 0);
            this.tlpMain.Controls.Add(this.userControlClient2, 1, 0);
            this.tlpMain.Controls.Add(this.userControlClient3, 2, 0);
            this.tlpMain.Controls.Add(this.userControlClient4, 3, 0);
            this.tlpMain.Controls.Add(this.userControlClient5, 4, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(685, 201);
            this.tlpMain.TabIndex = 0;
            // 
            // userControlClient1
            // 
            this.userControlClient1.Location = new System.Drawing.Point(3, 3);
            this.userControlClient1.Name = "userControlClient1";
            this.userControlClient1.ServiceCode = null;
            this.userControlClient1.Size = new System.Drawing.Size(131, 195);
            this.userControlClient1.TabIndex = 0;
            // 
            // userControlClient2
            // 
            this.userControlClient2.Location = new System.Drawing.Point(140, 3);
            this.userControlClient2.Name = "userControlClient2";
            this.userControlClient2.ServiceCode = null;
            this.userControlClient2.Size = new System.Drawing.Size(131, 195);
            this.userControlClient2.TabIndex = 1;
            // 
            // userControlClient3
            // 
            this.userControlClient3.Location = new System.Drawing.Point(277, 3);
            this.userControlClient3.Name = "userControlClient3";
            this.userControlClient3.ServiceCode = null;
            this.userControlClient3.Size = new System.Drawing.Size(131, 195);
            this.userControlClient3.TabIndex = 2;
            // 
            // userControlClient4
            // 
            this.userControlClient4.Location = new System.Drawing.Point(414, 3);
            this.userControlClient4.Name = "userControlClient4";
            this.userControlClient4.ServiceCode = null;
            this.userControlClient4.Size = new System.Drawing.Size(131, 195);
            this.userControlClient4.TabIndex = 3;
            // 
            // userControlClient5
            // 
            this.userControlClient5.Location = new System.Drawing.Point(551, 3);
            this.userControlClient5.Name = "userControlClient5";
            this.userControlClient5.ServiceCode = null;
            this.userControlClient5.Size = new System.Drawing.Size(131, 195);
            this.userControlClient5.TabIndex = 4;
            this.userControlClient5.Load += new System.EventHandler(this.userControlClient5_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 201);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.Text = "模拟服务台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UI.UserControlClient userControlClient1;
        private UI.UserControlClient userControlClient2;
        private UI.UserControlClient userControlClient3;
        private UI.UserControlClient userControlClient4;
        private UI.UserControlClient userControlClient5;
    }
}

