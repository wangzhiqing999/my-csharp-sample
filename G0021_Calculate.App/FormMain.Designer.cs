namespace G0021_Calculate.App
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCalclateInfo = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "计算";
            // 
            // lblCalclateInfo
            // 
            this.lblCalclateInfo.AutoSize = true;
            this.lblCalclateInfo.Location = new System.Drawing.Point(158, 91);
            this.lblCalclateInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCalclateInfo.Name = "lblCalclateInfo";
            this.lblCalclateInfo.Size = new System.Drawing.Size(59, 20);
            this.lblCalclateInfo.TabIndex = 1;
            this.lblCalclateInfo.Text = "1+1=?";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(52, 185);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(88, 40);
            this.btnA.TabIndex = 2;
            this.btnA.Text = "2";
            this.btnA.UseVisualStyleBackColor = true;
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(189, 185);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(88, 40);
            this.btnB.TabIndex = 3;
            this.btnB.Text = "3";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(326, 185);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(88, 40);
            this.btnC.TabIndex = 4;
            this.btnC.Text = "4";
            this.btnC.UseVisualStyleBackColor = true;
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(463, 185);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(88, 40);
            this.btnD.TabIndex = 5;
            this.btnD.Text = "5";
            this.btnD.UseVisualStyleBackColor = true;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(459, 91);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 20);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "10";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(108, 37);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(19, 20);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblCalclateInfo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算题";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCalclateInfo;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblResult;
    }
}

