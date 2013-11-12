namespace A5060_TwoScreen
{
    partial class FormPrimary
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblBasicInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序运行时， 我将显示在用户的主显示器上面。\r\n你可以假设我这个是一个高级的收银机的程序。\r\n我这个画面是主画面， 面对收银员的。";
            // 
            // lblBasicInfo
            // 
            this.lblBasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBasicInfo.Location = new System.Drawing.Point(25, 161);
            this.lblBasicInfo.Name = "lblBasicInfo";
            this.lblBasicInfo.Size = new System.Drawing.Size(595, 119);
            this.lblBasicInfo.TabIndex = 1;
            this.lblBasicInfo.Text = "-";
            // 
            // FormPrimary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 319);
            this.Controls.Add(this.lblBasicInfo);
            this.Controls.Add(this.label1);
            this.Name = "FormPrimary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "主窗口";
            this.Load += new System.EventHandler(this.FormPrimary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBasicInfo;
    }
}

