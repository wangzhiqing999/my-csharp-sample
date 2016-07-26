namespace A5200_Chart.Line
{
    partial class FormChartLine
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCmd = new System.Windows.Forms.Panel();
            this.btnStepline = new System.Windows.Forms.Button();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.btnSpline = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnFastLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnlCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Axis X 标题";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.DarkOrange;
            chartArea1.AxisY.Title = "Axis Y 标题";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.OrangeRed;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Title = "Legend标题";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "数据1";
            series1.LegendToolTip = "数据1ToolTip";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.LegendText = "数据2";
            series2.LegendToolTip = "数据2ToolTip";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(754, 374);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Chart 标题";
            this.chart1.Titles.Add(title1);
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
            this.tlpMain.Size = new System.Drawing.Size(760, 430);
            this.tlpMain.TabIndex = 1;
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.btnStepline);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Controls.Add(this.btnSpline);
            this.pnlCmd.Controls.Add(this.btnLine);
            this.pnlCmd.Controls.Add(this.btnFastLine);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(723, 44);
            this.pnlCmd.TabIndex = 1;
            // 
            // btnStepline
            // 
            this.btnStepline.Location = new System.Drawing.Point(324, 11);
            this.btnStepline.Name = "btnStepline";
            this.btnStepline.Size = new System.Drawing.Size(75, 23);
            this.btnStepline.TabIndex = 4;
            this.btnStepline.Text = "Stepline";
            this.btnStepline.UseVisualStyleBackColor = true;
            this.btnStepline.Click += new System.EventHandler(this.btnStepline_Click);
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
            // btnSpline
            // 
            this.btnSpline.Location = new System.Drawing.Point(222, 10);
            this.btnSpline.Name = "btnSpline";
            this.btnSpline.Size = new System.Drawing.Size(75, 23);
            this.btnSpline.TabIndex = 2;
            this.btnSpline.Text = "Spline";
            this.btnSpline.UseVisualStyleBackColor = true;
            this.btnSpline.Click += new System.EventHandler(this.btnSpline_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(118, 10);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnFastLine
            // 
            this.btnFastLine.Location = new System.Drawing.Point(22, 10);
            this.btnFastLine.Name = "btnFastLine";
            this.btnFastLine.Size = new System.Drawing.Size(75, 23);
            this.btnFastLine.TabIndex = 0;
            this.btnFastLine.Text = "FastLine";
            this.btnFastLine.UseVisualStyleBackColor = true;
            this.btnFastLine.Click += new System.EventHandler(this.btnFastLine_Click);
            // 
            // FormChartLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 430);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormChartLine";
            this.Text = "FormChartLine";
            this.Load += new System.EventHandler(this.FormChartLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnlCmd.ResumeLayout(false);
            this.pnlCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlCmd;
        private System.Windows.Forms.Button btnFastLine;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnSpline;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Button btnStepline;
    }
}