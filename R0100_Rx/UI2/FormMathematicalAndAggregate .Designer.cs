namespace R0100_Rx.UI2
{
    partial class FormMathematicalAndAggregate
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
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnConcat = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnReduce = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
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
            this.tlpMain.Controls.Add(this.btnAverage, 0, 0);
            this.tlpMain.Controls.Add(this.btnMin, 0, 1);
            this.tlpMain.Controls.Add(this.btnConcat, 1, 0);
            this.tlpMain.Controls.Add(this.btnCount, 2, 0);
            this.tlpMain.Controls.Add(this.btnMax, 3, 0);
            this.tlpMain.Controls.Add(this.btnReduce, 1, 1);
            this.tlpMain.Controls.Add(this.btnSum, 2, 1);
            this.tlpMain.Controls.Add(this.btnScan, 1, 2);
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
            this.tlpMain.TabIndex = 16;
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
            // btnAverage
            // 
            this.btnAverage.Location = new System.Drawing.Point(3, 3);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(190, 23);
            this.btnAverage.TabIndex = 6;
            this.btnAverage.Text = "使用 Average";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(3, 38);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(190, 23);
            this.btnMin.TabIndex = 7;
            this.btnMin.Text = "使用 Min";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnConcat
            // 
            this.btnConcat.Location = new System.Drawing.Point(199, 3);
            this.btnConcat.Name = "btnConcat";
            this.btnConcat.Size = new System.Drawing.Size(190, 23);
            this.btnConcat.TabIndex = 12;
            this.btnConcat.Text = "使用 Concat";
            this.btnConcat.UseVisualStyleBackColor = true;
            this.btnConcat.Click += new System.EventHandler(this.btnConcat_Click);
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(395, 3);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(190, 23);
            this.btnCount.TabIndex = 13;
            this.btnCount.Text = "使用 Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnMax
            // 
            this.btnMax.Location = new System.Drawing.Point(591, 3);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(190, 23);
            this.btnMax.TabIndex = 14;
            this.btnMax.Text = "使用 Max";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnReduce
            // 
            this.btnReduce.Location = new System.Drawing.Point(199, 38);
            this.btnReduce.Name = "btnReduce";
            this.btnReduce.Size = new System.Drawing.Size(190, 23);
            this.btnReduce.TabIndex = 15;
            this.btnReduce.Text = "使用 Reduce";
            this.btnReduce.UseVisualStyleBackColor = true;
            this.btnReduce.Click += new System.EventHandler(this.btnReduce_Click);
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(395, 38);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(190, 23);
            this.btnSum.TabIndex = 16;
            this.btnSum.Text = "使用 Sum";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(199, 73);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(190, 23);
            this.btnScan.TabIndex = 17;
            this.btnScan.Text = "对比使用 Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // FormMathematicalAndAggregate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMathematicalAndAggregate";
            this.Text = "算术和聚合";
            this.Load += new System.EventHandler(this.FormMathematicalAndAggregate_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnConcat;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnReduce;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnScan;
    }
}