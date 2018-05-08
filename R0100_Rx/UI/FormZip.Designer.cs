namespace R0100_Rx.UI
{
    partial class FormZip
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
            this.btnB = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(322, 79);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(121, 23);
            this.btnB.TabIndex = 13;
            this.btnB.Text = "生产出零件B";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(138, 187);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(221, 12);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "上面的按钮，都点过之后，才会更新这里";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(79, 79);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(116, 23);
            this.btnA.TabIndex = 11;
            this.btnA.Text = "生产出零件A";
            this.btnA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Zip — 通过指定的函数结合多个被观察对象，并且每一个条目基于函数计算";
            // 
            // FormZip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 270);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.label1);
            this.Name = "FormZip";
            this.Text = "FormZip";
            this.Load += new System.EventHandler(this.FormZip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Label label1;
    }
}