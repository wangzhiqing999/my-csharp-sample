namespace R0100_Rx.UI
{
    partial class FormAll
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(127, 155);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 12);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "处理的结果";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(102, 80);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(191, 23);
            this.btnTest.TabIndex = 12;
            this.btnTest.Text = "秒大于等于30时，结束。";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "All — 确定被观察对象的所有项目是否符合一定的标准";
            // 
            // FormAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 284);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label1);
            this.Name = "FormAll";
            this.Text = "FormAll";
            this.Load += new System.EventHandler(this.FormAll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
    }
}