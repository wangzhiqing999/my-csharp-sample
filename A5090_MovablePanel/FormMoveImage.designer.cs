namespace A5090_MovablePanel
{
    partial class FormMoveImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebugInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 256);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "调试信息";
            // 
            // txtDebugInfo
            // 
            this.txtDebugInfo.Location = new System.Drawing.Point(325, 28);
            this.txtDebugInfo.Multiline = true;
            this.txtDebugInfo.Name = "txtDebugInfo";
            this.txtDebugInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugInfo.Size = new System.Drawing.Size(265, 253);
            this.txtDebugInfo.TabIndex = 2;
            // 
            // FormMoveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 309);
            this.Controls.Add(this.txtDebugInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMoveImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片移动";
            this.Load += new System.EventHandler(this.FormTestImageSwitch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebugInfo;
    }
}