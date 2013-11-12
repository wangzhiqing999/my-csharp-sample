namespace A5040_MDI_SubForm
{
    partial class FormSington
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "单例方式的 MDI 窗口，本窗口只能打开一个";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 47);
            this.label2.TabIndex = 3;
            this.label2.Text = "因为是单例，所以在下面输入信息以后，关闭窗口，再次打开，会显示上次输入的信息。";
            // 
            // FormSington
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 173);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormSington";
            this.Text = "FormSington";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSington_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}