namespace A1010_Print
{
    partial class FormTestPrint
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
            this.btnPrintSetup = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.Location = new System.Drawing.Point(80, 410);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPrintSetup.TabIndex = 0;
            this.btnPrintSetup.Text = "页面设置";
            this.btnPrintSetup.UseVisualStyleBackColor = true;
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(282, 410);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPreview.TabIndex = 1;
            this.btnPrintPreview.Text = "打印预览";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(472, 410);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(582, 348);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "打印处理测试程序\r\n\r\n本程序测试 打印设置、打印预览、打印的功能。\r\n\r\n本文本的内容将被作为打印的内容。\r\n\r\n下面是为了测试翻页而追加的信息：\r\n1\r\n2\r" +
                "\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n";
            // 
            // FormTestPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnPrintSetup);
            this.Name = "FormTestPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTestPrint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintSetup;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textBox1;
    }
}