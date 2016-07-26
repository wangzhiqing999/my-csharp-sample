namespace A5200_Chart.Area
{
    partial class FormArea
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlCmd = new System.Windows.Forms.Panel();
            this.btnStackedArea100 = new System.Windows.Forms.Button();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.btnSplineArea = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnStackedArea = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlCmd.SuspendLayout();
            this.SuspendLayout();
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
            this.tlpMain.Size = new System.Drawing.Size(874, 486);
            this.tlpMain.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(868, 430);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.btnStackedArea100);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Controls.Add(this.btnSplineArea);
            this.pnlCmd.Controls.Add(this.btnArea);
            this.pnlCmd.Controls.Add(this.btnStackedArea);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(723, 44);
            this.pnlCmd.TabIndex = 1;
            // 
            // btnStackedArea100
            // 
            this.btnStackedArea100.Location = new System.Drawing.Point(365, 12);
            this.btnStackedArea100.Name = "btnStackedArea100";
            this.btnStackedArea100.Size = new System.Drawing.Size(109, 23);
            this.btnStackedArea100.TabIndex = 4;
            this.btnStackedArea100.Text = "StackedArea100";
            this.btnStackedArea100.UseVisualStyleBackColor = true;
            this.btnStackedArea100.Click += new System.EventHandler(this.btnStackedArea100_Click);
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
            // btnSplineArea
            // 
            this.btnSplineArea.Location = new System.Drawing.Point(222, 12);
            this.btnSplineArea.Name = "btnSplineArea";
            this.btnSplineArea.Size = new System.Drawing.Size(96, 23);
            this.btnSplineArea.TabIndex = 2;
            this.btnSplineArea.Text = "SplineArea";
            this.btnSplineArea.UseVisualStyleBackColor = true;
            this.btnSplineArea.Click += new System.EventHandler(this.btnSplineArea_Click);
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(123, 12);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(75, 23);
            this.btnArea.TabIndex = 1;
            this.btnArea.Text = "Area";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnStackedArea
            // 
            this.btnStackedArea.Location = new System.Drawing.Point(22, 12);
            this.btnStackedArea.Name = "btnStackedArea";
            this.btnStackedArea.Size = new System.Drawing.Size(90, 23);
            this.btnStackedArea.TabIndex = 0;
            this.btnStackedArea.Text = "StackedArea";
            this.btnStackedArea.UseVisualStyleBackColor = true;
            this.btnStackedArea.Click += new System.EventHandler(this.btnStackedArea_Click);
            // 
            // FormArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 486);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormArea";
            this.Text = "FormArea";
            this.Load += new System.EventHandler(this.FormArea_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlCmd.ResumeLayout(false);
            this.pnlCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlCmd;
        private System.Windows.Forms.Button btnStackedArea100;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Button btnSplineArea;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnStackedArea;
    }
}