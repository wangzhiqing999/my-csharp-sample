namespace A5200_Chart.Range
{
    partial class FormRange
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnRangeColumn = new System.Windows.Forms.Button();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlCmd = new System.Windows.Forms.Panel();
            this.btnRangeBar = new System.Windows.Forms.Button();
            this.btnRange = new System.Windows.Forms.Button();
            this.btnSplineRange = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRangeColumn
            // 
            this.btnRangeColumn.Location = new System.Drawing.Point(324, 11);
            this.btnRangeColumn.Name = "btnRangeColumn";
            this.btnRangeColumn.Size = new System.Drawing.Size(99, 23);
            this.btnRangeColumn.TabIndex = 4;
            this.btnRangeColumn.Text = "RangeColumn";
            this.btnRangeColumn.UseVisualStyleBackColor = true;
            this.btnRangeColumn.Click += new System.EventHandler(this.btnRangeColumn_Click);
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Checked = true;
            this.chk3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3D.Location = new System.Drawing.Point(629, 14);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(36, 16);
            this.chk3D.TabIndex = 3;
            this.chk3D.Text = "3D";
            this.chk3D.UseVisualStyleBackColor = true;
            this.chk3D.CheckedChanged += new System.EventHandler(this.chk3D_CheckedChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.chart1, 0, 1);
            this.tlpMain.Controls.Add(this.pnlCmd, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(794, 452);
            this.tlpMain.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(788, 396);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.btnRangeColumn);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Controls.Add(this.btnRangeBar);
            this.pnlCmd.Controls.Add(this.btnRange);
            this.pnlCmd.Controls.Add(this.btnSplineRange);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(723, 44);
            this.pnlCmd.TabIndex = 1;
            // 
            // btnRangeBar
            // 
            this.btnRangeBar.Location = new System.Drawing.Point(222, 10);
            this.btnRangeBar.Name = "btnRangeBar";
            this.btnRangeBar.Size = new System.Drawing.Size(75, 23);
            this.btnRangeBar.TabIndex = 2;
            this.btnRangeBar.Text = "RangeBar";
            this.btnRangeBar.UseVisualStyleBackColor = true;
            this.btnRangeBar.Click += new System.EventHandler(this.btnRangeBar_Click);
            // 
            // btnRange
            // 
            this.btnRange.Location = new System.Drawing.Point(118, 10);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(75, 23);
            this.btnRange.TabIndex = 1;
            this.btnRange.Text = "Range";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // btnSplineRange
            // 
            this.btnSplineRange.Location = new System.Drawing.Point(22, 10);
            this.btnSplineRange.Name = "btnSplineRange";
            this.btnSplineRange.Size = new System.Drawing.Size(75, 23);
            this.btnSplineRange.TabIndex = 0;
            this.btnSplineRange.Text = "SplineRange";
            this.btnSplineRange.UseVisualStyleBackColor = true;
            this.btnSplineRange.Click += new System.EventHandler(this.btnSplineRange_Click);
            // 
            // FormRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 452);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormRange";
            this.Text = "FormRange";
            this.Load += new System.EventHandler(this.FormRange_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlCmd.ResumeLayout(false);
            this.pnlCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRangeColumn;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlCmd;
        private System.Windows.Forms.Button btnRangeBar;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Button btnSplineRange;
    }
}