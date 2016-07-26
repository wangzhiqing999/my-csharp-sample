namespace A6000_ImportExe_Main
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadExe = new System.Windows.Forms.Button();
            this.btnLoadDotNetExe = new System.Windows.Forms.Button();
            this.pnlExe = new System.Windows.Forms.Panel();
            this.pnlDotNetExe = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFormBorderStyle = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.label1, 0, 0);
            this.tlpMain.Controls.Add(this.label2, 1, 0);
            this.tlpMain.Controls.Add(this.btnLoadExe, 0, 1);
            this.tlpMain.Controls.Add(this.pnlExe, 0, 2);
            this.tlpMain.Controls.Add(this.pnlDotNetExe, 1, 2);
            this.tlpMain.Controls.Add(this.panel1, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(922, 466);
            this.tlpMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "普通 Exe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(464, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(455, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = ".NET Exe";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadExe
            // 
            this.btnLoadExe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadExe.Location = new System.Drawing.Point(3, 53);
            this.btnLoadExe.Name = "btnLoadExe";
            this.btnLoadExe.Size = new System.Drawing.Size(455, 44);
            this.btnLoadExe.TabIndex = 2;
            this.btnLoadExe.Text = "加载普通Exe";
            this.btnLoadExe.UseVisualStyleBackColor = true;
            this.btnLoadExe.Click += new System.EventHandler(this.btnLoadExe_Click);
            // 
            // btnLoadDotNetExe
            // 
            this.btnLoadDotNetExe.Location = new System.Drawing.Point(294, 6);
            this.btnLoadDotNetExe.Name = "btnLoadDotNetExe";
            this.btnLoadDotNetExe.Size = new System.Drawing.Size(152, 32);
            this.btnLoadDotNetExe.TabIndex = 3;
            this.btnLoadDotNetExe.Text = "加载.Net Exe 的Form";
            this.btnLoadDotNetExe.UseVisualStyleBackColor = true;
            this.btnLoadDotNetExe.Click += new System.EventHandler(this.btnLoadDotNetExe_Click);
            // 
            // pnlExe
            // 
            this.pnlExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExe.Location = new System.Drawing.Point(3, 103);
            this.pnlExe.Name = "pnlExe";
            this.pnlExe.Size = new System.Drawing.Size(455, 360);
            this.pnlExe.TabIndex = 4;
            // 
            // pnlDotNetExe
            // 
            this.pnlDotNetExe.Location = new System.Drawing.Point(464, 103);
            this.pnlDotNetExe.Name = "pnlDotNetExe";
            this.pnlDotNetExe.Size = new System.Drawing.Size(455, 360);
            this.pnlDotNetExe.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFormBorderStyle);
            this.panel1.Controls.Add(this.btnLoadDotNetExe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(464, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 44);
            this.panel1.TabIndex = 6;
            // 
            // cboFormBorderStyle
            // 
            this.cboFormBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormBorderStyle.FormattingEnabled = true;
            this.cboFormBorderStyle.Items.AddRange(new object[] {
            "None",
            "FixedSingle",
            "Fixed3D",
            "FixedDialog",
            "Sizable",
            "FixedToolWindow",
            "SizableToolWindow"});
            this.cboFormBorderStyle.Location = new System.Drawing.Point(44, 13);
            this.cboFormBorderStyle.Name = "cboFormBorderStyle";
            this.cboFormBorderStyle.Size = new System.Drawing.Size(227, 20);
            this.cboFormBorderStyle.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 466);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试 当前程序，嵌入其他的 EXE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadExe;
        private System.Windows.Forms.Button btnLoadDotNetExe;
        private System.Windows.Forms.Panel pnlExe;
        private System.Windows.Forms.Panel pnlDotNetExe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboFormBorderStyle;
    }
}

