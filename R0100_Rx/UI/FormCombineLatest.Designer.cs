namespace R0100_Rx.UI
{
    partial class FormCombineLatest
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnB = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "CombineLatest — 通过指定函数结合各被观察对象的最新条目，基于函数计算结果";
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(322, 79);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(121, 23);
            this.btnB.TabIndex = 9;
            this.btnB.Text = "获取最新持仓";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(138, 187);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(221, 12);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "上面的按钮，都点过之后，才会更新这里";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(79, 79);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(116, 23);
            this.btnA.TabIndex = 6;
            this.btnA.Text = "获取最新行情";
            this.btnA.UseVisualStyleBackColor = true;
            // 
            // FormCombineLatest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 249);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.label1);
            this.Name = "FormCombineLatest";
            this.Text = "FormCombineLatest";
            this.Load += new System.EventHandler(this.FormCombineLatest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnA;
    }
}