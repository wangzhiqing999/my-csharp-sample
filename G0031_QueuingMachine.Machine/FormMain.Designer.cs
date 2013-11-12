namespace G0031_QueuingMachine.Machine
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
            this.btnA = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(36, 18);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(108, 34);
            this.btnA.TabIndex = 0;
            this.btnA.Tag = "A";
            this.btnA.Text = "A服务";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 1;
            this.button1.Tag = "B";
            this.button1.Text = "B服务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnA_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 2;
            this.button2.Tag = "C";
            this.button2.Text = "C服务";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnA_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(36, 72);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(419, 142);
            this.txtResult.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 226);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnA);
            this.Name = "FormMain";
            this.Text = "取号机";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtResult;
    }
}

