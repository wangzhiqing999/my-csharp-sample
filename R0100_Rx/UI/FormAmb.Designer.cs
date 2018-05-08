namespace R0100_Rx.UI
{
    partial class FormAmb
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
            this.btnB.Location = new System.Drawing.Point(333, 84);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(121, 23);
            this.btnB.TabIndex = 13;
            this.btnB.Text = "用户B通话";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(88, 219);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(257, 12);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "上面的按钮，点过任意一个之后，才会更新这里";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(90, 84);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(116, 23);
            this.btnA.TabIndex = 11;
            this.btnA.Text = "用户A通话";
            this.btnA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Amb — 给定两个或多个源被观察对象，发出所有的条目从只观测发出的第一项";
            // 
            // FormAmb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 327);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.label1);
            this.Name = "FormAmb";
            this.Text = "FormAmb";
            this.Load += new System.EventHandler(this.FormAmb_Load);
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