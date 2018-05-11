namespace R0100_Rx.UI2
{
    partial class FormTransforming
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.btnBufferSkip = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnGroupBy = new System.Windows.Forms.Button();
            this.btnSelectMany = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnWindow = new System.Windows.Forms.Button();
            this.btnWindowSkip = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.txtResult, 0, 3);
            this.tlpMain.Controls.Add(this.btnBuffer, 0, 0);
            this.tlpMain.Controls.Add(this.btnBufferSkip, 1, 0);
            this.tlpMain.Controls.Add(this.btnScan, 3, 0);
            this.tlpMain.Controls.Add(this.btnGroupBy, 2, 0);
            this.tlpMain.Controls.Add(this.btnSelectMany, 0, 1);
            this.tlpMain.Controls.Add(this.btnSelect, 1, 1);
            this.tlpMain.Controls.Add(this.btnWindow, 2, 1);
            this.tlpMain.Controls.Add(this.btnWindowSkip, 3, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(784, 361);
            this.tlpMain.TabIndex = 14;
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 4);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 108);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(778, 250);
            this.txtResult.TabIndex = 11;
            // 
            // btnBuffer
            // 
            this.btnBuffer.Location = new System.Drawing.Point(3, 3);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Size = new System.Drawing.Size(190, 23);
            this.btnBuffer.TabIndex = 6;
            this.btnBuffer.Text = "使用 Buffer ";
            this.btnBuffer.UseVisualStyleBackColor = true;
            this.btnBuffer.Click += new System.EventHandler(this.btnBuffer_Click);
            // 
            // btnBufferSkip
            // 
            this.btnBufferSkip.Location = new System.Drawing.Point(199, 3);
            this.btnBufferSkip.Name = "btnBufferSkip";
            this.btnBufferSkip.Size = new System.Drawing.Size(190, 23);
            this.btnBufferSkip.TabIndex = 7;
            this.btnBufferSkip.Text = "使用 Buffer + skip";
            this.btnBufferSkip.UseVisualStyleBackColor = true;
            this.btnBufferSkip.Click += new System.EventHandler(this.btnBufferSkip_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(591, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(190, 23);
            this.btnScan.TabIndex = 9;
            this.btnScan.Text = "使用 Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnGroupBy
            // 
            this.btnGroupBy.Location = new System.Drawing.Point(395, 3);
            this.btnGroupBy.Name = "btnGroupBy";
            this.btnGroupBy.Size = new System.Drawing.Size(190, 23);
            this.btnGroupBy.TabIndex = 8;
            this.btnGroupBy.Text = "使用 GroupBy";
            this.btnGroupBy.UseVisualStyleBackColor = true;
            this.btnGroupBy.Click += new System.EventHandler(this.btnGroupBy_Click);
            // 
            // btnSelectMany
            // 
            this.btnSelectMany.Location = new System.Drawing.Point(3, 38);
            this.btnSelectMany.Name = "btnSelectMany";
            this.btnSelectMany.Size = new System.Drawing.Size(190, 23);
            this.btnSelectMany.TabIndex = 12;
            this.btnSelectMany.Text = "使用 SelectMany";
            this.btnSelectMany.UseVisualStyleBackColor = true;
            this.btnSelectMany.Click += new System.EventHandler(this.btnSelectMany_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(199, 38);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(190, 23);
            this.btnSelect.TabIndex = 13;
            this.btnSelect.Text = "使用 Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnWindow
            // 
            this.btnWindow.Location = new System.Drawing.Point(395, 38);
            this.btnWindow.Name = "btnWindow";
            this.btnWindow.Size = new System.Drawing.Size(190, 23);
            this.btnWindow.TabIndex = 14;
            this.btnWindow.Text = "使用 Window";
            this.btnWindow.UseVisualStyleBackColor = true;
            this.btnWindow.Click += new System.EventHandler(this.btnWindow_Click);
            // 
            // btnWindowSkip
            // 
            this.btnWindowSkip.Location = new System.Drawing.Point(591, 38);
            this.btnWindowSkip.Name = "btnWindowSkip";
            this.btnWindowSkip.Size = new System.Drawing.Size(190, 23);
            this.btnWindowSkip.TabIndex = 15;
            this.btnWindowSkip.Text = "使用 Window + skip";
            this.btnWindowSkip.UseVisualStyleBackColor = true;
            this.btnWindowSkip.Click += new System.EventHandler(this.btnWindowSkip_Click);
            // 
            // FormTransforming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormTransforming";
            this.Text = "转化操作";
            this.Load += new System.EventHandler(this.FormTransforming_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnBuffer;
        private System.Windows.Forms.Button btnBufferSkip;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnGroupBy;
        private System.Windows.Forms.Button btnSelectMany;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnWindow;
        private System.Windows.Forms.Button btnWindowSkip;
    }
}