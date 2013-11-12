namespace A0352_WinFormThreadInvokeParam
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvSourceData = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblThread1 = new System.Windows.Forms.Label();
            this.lblThread2 = new System.Windows.Forms.Label();
            this.lblThread3 = new System.Windows.Forms.Label();
            this.lblThread4 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "本测试主要用于 Control.Invoke 方法中，获取画面的部分数据，返回给线程中进行处理！";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvSourceData
            // 
            this.lvSourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSourceData.GridLines = true;
            this.lvSourceData.Location = new System.Drawing.Point(3, 63);
            this.lvSourceData.Name = "lvSourceData";
            this.tlpMain.SetRowSpan(this.lvSourceData, 4);
            this.lvSourceData.Size = new System.Drawing.Size(391, 178);
            this.lvSourceData.TabIndex = 1;
            this.lvSourceData.UseCompatibleStateImageBehavior = false;
            this.lvSourceData.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "源数据：多线程将从下面这个列表获取数据";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.Controls.Add(this.lblThread4, 2, 5);
            this.tlpMain.Controls.Add(this.lblThread3, 2, 4);
            this.tlpMain.Controls.Add(this.lblThread2, 2, 3);
            this.tlpMain.Controls.Add(this.label7, 1, 5);
            this.tlpMain.Controls.Add(this.label6, 1, 4);
            this.tlpMain.Controls.Add(this.label3, 1, 1);
            this.tlpMain.Controls.Add(this.label1, 0, 0);
            this.tlpMain.Controls.Add(this.lvSourceData, 0, 2);
            this.tlpMain.Controls.Add(this.label2, 0, 1);
            this.tlpMain.Controls.Add(this.btnProcess, 0, 6);
            this.tlpMain.Controls.Add(this.label4, 1, 2);
            this.tlpMain.Controls.Add(this.label5, 1, 3);
            this.tlpMain.Controls.Add(this.lblThread1, 2, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.Size = new System.Drawing.Size(618, 274);
            this.tlpMain.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(400, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "处理线程： 下面这些线程处理左边的数据";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpMain.SetColumnSpan(this.btnProcess, 3);
            this.btnProcess.Location = new System.Drawing.Point(271, 247);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "开始处理";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(400, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 46);
            this.label4.TabIndex = 5;
            this.label4.Text = "线程1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(400, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 46);
            this.label5.TabIndex = 6;
            this.label5.Text = "线程2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(400, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 46);
            this.label6.TabIndex = 7;
            this.label6.Text = "线程3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(400, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 46);
            this.label7.TabIndex = 8;
            this.label7.Text = "线程4";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThread1
            // 
            this.lblThread1.AutoSize = true;
            this.lblThread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThread1.Location = new System.Drawing.Point(450, 60);
            this.lblThread1.Name = "lblThread1";
            this.lblThread1.Size = new System.Drawing.Size(165, 46);
            this.lblThread1.TabIndex = 9;
            this.lblThread1.Text = "-";
            this.lblThread1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThread2
            // 
            this.lblThread2.AutoSize = true;
            this.lblThread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThread2.Location = new System.Drawing.Point(450, 106);
            this.lblThread2.Name = "lblThread2";
            this.lblThread2.Size = new System.Drawing.Size(165, 46);
            this.lblThread2.TabIndex = 11;
            this.lblThread2.Text = "-";
            this.lblThread2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThread3
            // 
            this.lblThread3.AutoSize = true;
            this.lblThread3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThread3.Location = new System.Drawing.Point(450, 152);
            this.lblThread3.Name = "lblThread3";
            this.lblThread3.Size = new System.Drawing.Size(165, 46);
            this.lblThread3.TabIndex = 12;
            this.lblThread3.Text = "-";
            this.lblThread3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThread4
            // 
            this.lblThread4.AutoSize = true;
            this.lblThread4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThread4.Location = new System.Drawing.Point(450, 198);
            this.lblThread4.Name = "lblThread4";
            this.lblThread4.Size = new System.Drawing.Size(165, 46);
            this.lblThread4.TabIndex = 13;
            this.lblThread4.Text = "-";
            this.lblThread4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 274);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.Text = "WinForm多线程测试";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvSourceData;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblThread4;
        private System.Windows.Forms.Label lblThread3;
        private System.Windows.Forms.Label lblThread2;
        private System.Windows.Forms.Label lblThread1;
    }
}

