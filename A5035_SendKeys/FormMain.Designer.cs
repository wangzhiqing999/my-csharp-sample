namespace A5035_SendKeys
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
            this.btnABC = new System.Windows.Forms.Button();
            this.btn123 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btn_AA = new System.Windows.Forms.Button();
            this.btn_A1 = new System.Windows.Forms.Button();
            this.btn_Sxyz = new System.Windows.Forms.Button();
            this.btn_CV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnABC
            // 
            this.btnABC.Location = new System.Drawing.Point(12, 12);
            this.btnABC.Name = "btnABC";
            this.btnABC.Size = new System.Drawing.Size(75, 23);
            this.btnABC.TabIndex = 0;
            this.btnABC.Text = "ABC(&A)";
            this.btnABC.UseVisualStyleBackColor = true;
            this.btnABC.Click += new System.EventHandler(this.btnABC_Click);
            // 
            // btn123
            // 
            this.btn123.Location = new System.Drawing.Point(110, 12);
            this.btn123.Name = "btn123";
            this.btn123.Size = new System.Drawing.Size(75, 23);
            this.btn123.TabIndex = 2;
            this.btn123.Text = "123(&1)";
            this.btn123.UseVisualStyleBackColor = true;
            this.btn123.Click += new System.EventHandler(this.btn123_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 120);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(593, 232);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "";
            // 
            // btn_AA
            // 
            this.btn_AA.Location = new System.Drawing.Point(12, 58);
            this.btn_AA.Name = "btn_AA";
            this.btn_AA.Size = new System.Drawing.Size(75, 23);
            this.btn_AA.TabIndex = 5;
            this.btn_AA.Text = "Alt+A";
            this.btn_AA.UseVisualStyleBackColor = true;
            this.btn_AA.Click += new System.EventHandler(this.btn_AA_Click);
            // 
            // btn_A1
            // 
            this.btn_A1.Location = new System.Drawing.Point(115, 58);
            this.btn_A1.Name = "btn_A1";
            this.btn_A1.Size = new System.Drawing.Size(75, 23);
            this.btn_A1.TabIndex = 6;
            this.btn_A1.Text = "Alt+1";
            this.btn_A1.UseVisualStyleBackColor = true;
            this.btn_A1.Click += new System.EventHandler(this.btn_A1_Click);
            // 
            // btn_Sxyz
            // 
            this.btn_Sxyz.Location = new System.Drawing.Point(261, 11);
            this.btn_Sxyz.Name = "btn_Sxyz";
            this.btn_Sxyz.Size = new System.Drawing.Size(75, 23);
            this.btn_Sxyz.TabIndex = 7;
            this.btn_Sxyz.Text = "Shift+xyz";
            this.btn_Sxyz.UseVisualStyleBackColor = true;
            this.btn_Sxyz.Click += new System.EventHandler(this.btn_Sxyz_Click);
            // 
            // btn_CV
            // 
            this.btn_CV.Location = new System.Drawing.Point(261, 58);
            this.btn_CV.Name = "btn_CV";
            this.btn_CV.Size = new System.Drawing.Size(75, 23);
            this.btn_CV.TabIndex = 8;
            this.btn_CV.Text = "Ctrl+V";
            this.btn_CV.UseVisualStyleBackColor = true;
            this.btn_CV.Click += new System.EventHandler(this.btn_CV_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 364);
            this.Controls.Add(this.btn_CV);
            this.Controls.Add(this.btn_Sxyz);
            this.Controls.Add(this.btn_A1);
            this.Controls.Add(this.btn_AA);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btn123);
            this.Controls.Add(this.btnABC);
            this.Name = "FormMain";
            this.Text = "SendKeys.Send 方法测试";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnABC;
        private System.Windows.Forms.Button btn123;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btn_AA;
        private System.Windows.Forms.Button btn_A1;
        private System.Windows.Forms.Button btn_Sxyz;
        private System.Windows.Forms.Button btn_CV;
    }
}

