namespace A5070_CheckAbleComboBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cboTest = new A5070_CheckAbleComboBox.UI.ComboBoxEx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "测试输入：";
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(375, 26);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(75, 23);
            this.btnGetResult.TabIndex = 2;
            this.btnGetResult.Text = "获取输入结果";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 69);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(471, 210);
            this.txtResult.TabIndex = 3;
            // 
            // cboTest
            // 
            this.cboTest.CheckAbleItemList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTest.CheckAbleItemList")));
            this.cboTest.CheckedItemList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTest.CheckedItemList")));
            this.cboTest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTest.FormattingEnabled = true;
            this.cboTest.Location = new System.Drawing.Point(83, 23);
            this.cboTest.Name = "cboTest";
            this.cboTest.Size = new System.Drawing.Size(258, 22);
            this.cboTest.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 291);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTest);
            this.Controls.Add(this.txtResult);
            this.Name = "FormMain";
            this.Text = "Combox测试画面";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.ComboBoxEx cboTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.TextBox txtResult;
    }
}

