namespace A5050_UCbo
{
    partial class FormTest
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
            this.components = new System.ComponentModel.Container();
            this.myComboBoxEx1 = new A5050_UCbo.UI.MyComboBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // myComboBoxEx1
            // 
            this.myComboBoxEx1.FormattingEnabled = true;
            this.myComboBoxEx1.Location = new System.Drawing.Point(114, 42);
            this.myComboBoxEx1.Name = "myComboBoxEx1";
            this.myComboBoxEx1.Size = new System.Drawing.Size(297, 20);
            this.myComboBoxEx1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "测试输入";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 246);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myComboBoxEx1);
            this.Name = "FormTest";
            this.Text = "测试自动模糊匹配";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.MyComboBoxEx myComboBoxEx1;
        private System.Windows.Forms.Label label1;
    }
}

