namespace A5200_Chart.Point
{
    partial class FormPoint
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlCmd = new System.Windows.Forms.Panel();
            this.cboMarkerStyle = new System.Windows.Forms.ComboBox();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.btnBubble = new System.Windows.Forms.Button();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btnFastPoint = new System.Windows.Forms.Button();
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
            this.tlpMain.Size = new System.Drawing.Size(862, 512);
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
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(856, 456);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.btnFastPoint);
            this.pnlCmd.Controls.Add(this.cboMarkerStyle);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Controls.Add(this.btnBubble);
            this.pnlCmd.Controls.Add(this.btnPoint);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(723, 44);
            this.pnlCmd.TabIndex = 1;
            // 
            // cboMarkerStyle
            // 
            this.cboMarkerStyle.FormattingEnabled = true;
            this.cboMarkerStyle.Items.AddRange(new object[] {
            "None",
            "Square",
            "Circle",
            "Diamond",
            "Triangle",
            "Cross",
            "Star4",
            "Star5",
            "Star6",
            "Star10"});
            this.cboMarkerStyle.Location = new System.Drawing.Point(430, 12);
            this.cboMarkerStyle.Name = "cboMarkerStyle";
            this.cboMarkerStyle.Size = new System.Drawing.Size(121, 20);
            this.cboMarkerStyle.TabIndex = 4;
            this.cboMarkerStyle.SelectedIndexChanged += new System.EventHandler(this.cboMarkerStyle_SelectedIndexChanged);
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
            // btnBubble
            // 
            this.btnBubble.Location = new System.Drawing.Point(247, 12);
            this.btnBubble.Name = "btnBubble";
            this.btnBubble.Size = new System.Drawing.Size(75, 23);
            this.btnBubble.TabIndex = 1;
            this.btnBubble.Text = "Bubble";
            this.btnBubble.UseVisualStyleBackColor = true;
            this.btnBubble.Click += new System.EventHandler(this.btnBubble_Click);
            // 
            // btnPoint
            // 
            this.btnPoint.Location = new System.Drawing.Point(151, 12);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(75, 23);
            this.btnPoint.TabIndex = 0;
            this.btnPoint.Text = "Point";
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // btnFastPoint
            // 
            this.btnFastPoint.Location = new System.Drawing.Point(38, 12);
            this.btnFastPoint.Name = "btnFastPoint";
            this.btnFastPoint.Size = new System.Drawing.Size(75, 23);
            this.btnFastPoint.TabIndex = 5;
            this.btnFastPoint.Text = "FastPoint";
            this.btnFastPoint.UseVisualStyleBackColor = true;
            this.btnFastPoint.Click += new System.EventHandler(this.btnFastPoint_Click);
            // 
            // FormPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 512);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormPoint";
            this.Text = "FormPoint";
            this.Load += new System.EventHandler(this.FormPoint_Load);
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
        private System.Windows.Forms.Button btnBubble;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.ComboBox cboMarkerStyle;
        private System.Windows.Forms.Button btnFastPoint;
    }
}