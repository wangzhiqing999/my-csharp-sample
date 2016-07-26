namespace A5200_Chart.Circular
{
    partial class FormPolar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlCmd = new System.Windows.Forms.Panel();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.cboPolarDrawingStyle = new System.Windows.Forms.ComboBox();
            this.cboAreaDrawingStyle = new System.Windows.Forms.ComboBox();
            this.cboCircularLabelsStyle = new System.Windows.Forms.ComboBox();
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
            this.tlpMain.Size = new System.Drawing.Size(912, 521);
            this.tlpMain.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(906, 465);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.cboCircularLabelsStyle);
            this.pnlCmd.Controls.Add(this.cboAreaDrawingStyle);
            this.pnlCmd.Controls.Add(this.cboPolarDrawingStyle);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(723, 44);
            this.pnlCmd.TabIndex = 1;
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
            // cboPolarDrawingStyle
            // 
            this.cboPolarDrawingStyle.FormattingEnabled = true;
            this.cboPolarDrawingStyle.Items.AddRange(new object[] {
            "Line",
            "Marker"});
            this.cboPolarDrawingStyle.Location = new System.Drawing.Point(9, 12);
            this.cboPolarDrawingStyle.Name = "cboPolarDrawingStyle";
            this.cboPolarDrawingStyle.Size = new System.Drawing.Size(161, 20);
            this.cboPolarDrawingStyle.TabIndex = 4;
            this.cboPolarDrawingStyle.SelectedIndexChanged += new System.EventHandler(this.cboPolarDrawingStyle_SelectedIndexChanged);
            // 
            // cboAreaDrawingStyle
            // 
            this.cboAreaDrawingStyle.FormattingEnabled = true;
            this.cboAreaDrawingStyle.Items.AddRange(new object[] {
            "Circle",
            "Polygon"});
            this.cboAreaDrawingStyle.Location = new System.Drawing.Point(197, 12);
            this.cboAreaDrawingStyle.Name = "cboAreaDrawingStyle";
            this.cboAreaDrawingStyle.Size = new System.Drawing.Size(161, 20);
            this.cboAreaDrawingStyle.TabIndex = 5;
            this.cboAreaDrawingStyle.SelectedIndexChanged += new System.EventHandler(this.cboAreaDrawingStyle_SelectedIndexChanged);
            // 
            // cboCircularLabelsStyle
            // 
            this.cboCircularLabelsStyle.FormattingEnabled = true;
            this.cboCircularLabelsStyle.Items.AddRange(new object[] {
            "Auto",
            "Horizontal",
            "Circular",
            "Radial"});
            this.cboCircularLabelsStyle.Location = new System.Drawing.Point(401, 12);
            this.cboCircularLabelsStyle.Name = "cboCircularLabelsStyle";
            this.cboCircularLabelsStyle.Size = new System.Drawing.Size(161, 20);
            this.cboCircularLabelsStyle.TabIndex = 6;
            this.cboCircularLabelsStyle.SelectedIndexChanged += new System.EventHandler(this.cboCircularLabelsStyle_SelectedIndexChanged);
            // 
            // FormPolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 521);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormPolar";
            this.Text = "FormPolar";
            this.Load += new System.EventHandler(this.FormPolar_Load);
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
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.ComboBox cboPolarDrawingStyle;
        private System.Windows.Forms.ComboBox cboAreaDrawingStyle;
        private System.Windows.Forms.ComboBox cboCircularLabelsStyle;
    }
}