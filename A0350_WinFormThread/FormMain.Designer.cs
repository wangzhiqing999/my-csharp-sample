namespace A0350_WinFormThread
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUseUIThread = new System.Windows.Forms.RadioButton();
            this.rdoUseNewThread = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUseNewThread);
            this.groupBox1.Controls.Add(this.rdoUseUIThread);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线程启用";
            // 
            // rdoUseUIThread
            // 
            this.rdoUseUIThread.AutoSize = true;
            this.rdoUseUIThread.Checked = true;
            this.rdoUseUIThread.Location = new System.Drawing.Point(17, 21);
            this.rdoUseUIThread.Name = "rdoUseUIThread";
            this.rdoUseUIThread.Size = new System.Drawing.Size(215, 16);
            this.rdoUseUIThread.TabIndex = 0;
            this.rdoUseUIThread.TabStop = true;
            this.rdoUseUIThread.Text = "长时间处理，使用UI线程，画面会卡";
            this.rdoUseUIThread.UseVisualStyleBackColor = true;
            // 
            // rdoUseNewThread
            // 
            this.rdoUseNewThread.AutoSize = true;
            this.rdoUseNewThread.Location = new System.Drawing.Point(17, 44);
            this.rdoUseNewThread.Name = "rdoUseNewThread";
            this.rdoUseNewThread.Size = new System.Drawing.Size(239, 16);
            this.rdoUseNewThread.TabIndex = 1;
            this.rdoUseNewThread.Text = "长时间处理，使用新建的线程，画面不卡";
            this.rdoUseNewThread.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模拟一个长时间处理，耗时（秒）：";
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(234, 109);
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(102, 21);
            this.nudSecond.TabIndex = 2;
            this.nudSecond.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(148, 145);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始处理";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 189);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(346, 72);
            this.txtResult.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm多线程测试";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUseNewThread;
        private System.Windows.Forms.RadioButton rdoUseUIThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtResult;
    }
}

