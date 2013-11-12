namespace A0351_WinFormThreadTwoPart
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
            this.txtResult1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUseNewThread2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoUseNewThread = new System.Windows.Forms.RadioButton();
            this.rdoUseUIThread = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult1
            // 
            this.txtResult1.Location = new System.Drawing.Point(14, 238);
            this.txtResult1.Multiline = true;
            this.txtResult1.Name = "txtResult1";
            this.txtResult1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult1.Size = new System.Drawing.Size(230, 100);
            this.txtResult1.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(278, 189);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "开始处理";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(249, 155);
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(102, 21);
            this.nudSecond.TabIndex = 7;
            this.nudSecond.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "模拟一个长时间处理，耗时（秒）：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUseNewThread2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rdoUseNewThread);
            this.groupBox1.Controls.Add(this.rdoUseUIThread);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线程启用";
            // 
            // rdoUseNewThread2
            // 
            this.rdoUseNewThread2.AutoSize = true;
            this.rdoUseNewThread2.Location = new System.Drawing.Point(16, 67);
            this.rdoUseNewThread2.Name = "rdoUseNewThread2";
            this.rdoUseNewThread2.Size = new System.Drawing.Size(413, 16);
            this.rdoUseNewThread2.TabIndex = 3;
            this.rdoUseNewThread2.Text = "长时间处理，使用新建2个独立的线程，并行处理，耗时相对短，画面不卡";
            this.rdoUseNewThread2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 92);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(497, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "长时间处理，使用 Task.WaitAll （.NET 4.0 新特性）并行处理，耗时相对短，画面会卡";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoUseNewThread
            // 
            this.rdoUseNewThread.AutoSize = true;
            this.rdoUseNewThread.Location = new System.Drawing.Point(17, 44);
            this.rdoUseNewThread.Name = "rdoUseNewThread";
            this.rdoUseNewThread.Size = new System.Drawing.Size(353, 16);
            this.rdoUseNewThread.TabIndex = 1;
            this.rdoUseNewThread.Text = "长时间处理，使用新建1个线程，串行处理，耗时长，画面不卡";
            this.rdoUseNewThread.UseVisualStyleBackColor = true;
            // 
            // rdoUseUIThread
            // 
            this.rdoUseUIThread.AutoSize = true;
            this.rdoUseUIThread.Checked = true;
            this.rdoUseUIThread.Location = new System.Drawing.Point(17, 21);
            this.rdoUseUIThread.Name = "rdoUseUIThread";
            this.rdoUseUIThread.Size = new System.Drawing.Size(323, 16);
            this.rdoUseUIThread.TabIndex = 0;
            this.rdoUseUIThread.TabStop = true;
            this.rdoUseUIThread.Text = "长时间处理，使用UI线程，串行处理，耗时长，画面会卡";
            this.rdoUseUIThread.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "第一个长时间处理的结果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "第二个长时间处理的结果";
            // 
            // txtResult2
            // 
            this.txtResult2.Location = new System.Drawing.Point(390, 238);
            this.txtResult2.Multiline = true;
            this.txtResult2.Name = "txtResult2";
            this.txtResult2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult2.Size = new System.Drawing.Size(230, 100);
            this.txtResult2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "最终的处理结果";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 374);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(606, 67);
            this.txtResult.TabIndex = 13;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm多线程测试";
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUseNewThread;
        private System.Windows.Forms.RadioButton rdoUseUIThread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoUseNewThread2;
    }
}

