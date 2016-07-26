namespace A4005_Settings
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
            this.btnTestRead = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnTestWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestRead
            // 
            this.btnTestRead.Location = new System.Drawing.Point(90, 30);
            this.btnTestRead.Name = "btnTestRead";
            this.btnTestRead.Size = new System.Drawing.Size(119, 23);
            this.btnTestRead.TabIndex = 0;
            this.btnTestRead.Text = "测试读取属性";
            this.btnTestRead.UseVisualStyleBackColor = true;
            this.btnTestRead.Click += new System.EventHandler(this.btnTestRead_Click);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtResult.Location = new System.Drawing.Point(0, 88);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(909, 397);
            this.txtResult.TabIndex = 1;
            // 
            // btnTestWrite
            // 
            this.btnTestWrite.Location = new System.Drawing.Point(589, 30);
            this.btnTestWrite.Name = "btnTestWrite";
            this.btnTestWrite.Size = new System.Drawing.Size(119, 23);
            this.btnTestWrite.TabIndex = 2;
            this.btnTestWrite.Text = "测试修改属性";
            this.btnTestWrite.UseVisualStyleBackColor = true;
            this.btnTestWrite.Click += new System.EventHandler(this.btnTestWrite_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 485);
            this.Controls.Add(this.btnTestWrite);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnTestRead);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目配置文件测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestRead;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnTestWrite;
    }
}

