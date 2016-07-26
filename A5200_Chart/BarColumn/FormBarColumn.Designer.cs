namespace A5200_Chart.BarColumn
{
    partial class FormBarColumn
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
            this.cboDrawingStyle = new System.Windows.Forms.ComboBox();
            this.btnStackedColumn = new System.Windows.Forms.Button();
            this.btnStackedBar = new System.Windows.Forms.Button();
            this.btnStackedColumn100 = new System.Windows.Forms.Button();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.btnStackedBar100 = new System.Windows.Forms.Button();
            this.btnColumn = new System.Windows.Forms.Button();
            this.btnBar = new System.Windows.Forms.Button();
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
            this.tlpMain.Size = new System.Drawing.Size(1198, 549);
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
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1192, 493);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlCmd
            // 
            this.pnlCmd.Controls.Add(this.cboDrawingStyle);
            this.pnlCmd.Controls.Add(this.btnStackedColumn);
            this.pnlCmd.Controls.Add(this.btnStackedBar);
            this.pnlCmd.Controls.Add(this.btnStackedColumn100);
            this.pnlCmd.Controls.Add(this.chk3D);
            this.pnlCmd.Controls.Add(this.btnStackedBar100);
            this.pnlCmd.Controls.Add(this.btnColumn);
            this.pnlCmd.Controls.Add(this.btnBar);
            this.pnlCmd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCmd.Location = new System.Drawing.Point(3, 3);
            this.pnlCmd.Name = "pnlCmd";
            this.pnlCmd.Size = new System.Drawing.Size(1165, 44);
            this.pnlCmd.TabIndex = 1;
            // 
            // cboDrawingStyle
            // 
            this.cboDrawingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawingStyle.FormattingEnabled = true;
            this.cboDrawingStyle.Items.AddRange(new object[] {
            "Cylinder",
            "Emboss"});
            this.cboDrawingStyle.Location = new System.Drawing.Point(934, 11);
            this.cboDrawingStyle.Name = "cboDrawingStyle";
            this.cboDrawingStyle.Size = new System.Drawing.Size(145, 20);
            this.cboDrawingStyle.TabIndex = 7;
            this.cboDrawingStyle.SelectedIndexChanged += new System.EventHandler(this.cboDrawingStyle_SelectedIndexChanged);
            // 
            // btnStackedColumn
            // 
            this.btnStackedColumn.Location = new System.Drawing.Point(556, 11);
            this.btnStackedColumn.Name = "btnStackedColumn";
            this.btnStackedColumn.Size = new System.Drawing.Size(123, 23);
            this.btnStackedColumn.TabIndex = 6;
            this.btnStackedColumn.Text = "StackedColumn";
            this.btnStackedColumn.UseVisualStyleBackColor = true;
            this.btnStackedColumn.Click += new System.EventHandler(this.btnStackedColumn_Click);
            // 
            // btnStackedBar
            // 
            this.btnStackedBar.Location = new System.Drawing.Point(439, 11);
            this.btnStackedBar.Name = "btnStackedBar";
            this.btnStackedBar.Size = new System.Drawing.Size(109, 23);
            this.btnStackedBar.TabIndex = 5;
            this.btnStackedBar.Text = "StackedBar";
            this.btnStackedBar.UseVisualStyleBackColor = true;
            this.btnStackedBar.Click += new System.EventHandler(this.btnStackedBar_Click);
            // 
            // btnStackedColumn100
            // 
            this.btnStackedColumn100.Location = new System.Drawing.Point(302, 11);
            this.btnStackedColumn100.Name = "btnStackedColumn100";
            this.btnStackedColumn100.Size = new System.Drawing.Size(123, 23);
            this.btnStackedColumn100.TabIndex = 4;
            this.btnStackedColumn100.Text = "StackedColumn100";
            this.btnStackedColumn100.UseVisualStyleBackColor = true;
            this.btnStackedColumn100.Click += new System.EventHandler(this.btnStackedColumn100_Click);
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Checked = true;
            this.chk3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3D.Location = new System.Drawing.Point(1114, 15);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(36, 16);
            this.chk3D.TabIndex = 3;
            this.chk3D.Text = "3D";
            this.chk3D.UseVisualStyleBackColor = true;
            this.chk3D.CheckedChanged += new System.EventHandler(this.chk3D_CheckedChanged);
            // 
            // btnStackedBar100
            // 
            this.btnStackedBar100.Location = new System.Drawing.Point(188, 11);
            this.btnStackedBar100.Name = "btnStackedBar100";
            this.btnStackedBar100.Size = new System.Drawing.Size(109, 23);
            this.btnStackedBar100.TabIndex = 2;
            this.btnStackedBar100.Text = "StackedBar100";
            this.btnStackedBar100.UseVisualStyleBackColor = true;
            this.btnStackedBar100.Click += new System.EventHandler(this.btnStackedBar100_Click);
            // 
            // btnColumn
            // 
            this.btnColumn.Location = new System.Drawing.Point(100, 11);
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Size = new System.Drawing.Size(75, 23);
            this.btnColumn.TabIndex = 1;
            this.btnColumn.Text = "Column";
            this.btnColumn.UseVisualStyleBackColor = true;
            this.btnColumn.Click += new System.EventHandler(this.btnColumn_Click);
            // 
            // btnBar
            // 
            this.btnBar.Location = new System.Drawing.Point(12, 11);
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(75, 23);
            this.btnBar.TabIndex = 0;
            this.btnBar.Text = "Bar";
            this.btnBar.UseVisualStyleBackColor = true;
            this.btnBar.Click += new System.EventHandler(this.btnBar_Click);
            // 
            // FormBarColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 549);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormBarColumn";
            this.Text = "FormBarColumn";
            this.Load += new System.EventHandler(this.FormBarColumn_Load);
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
        private System.Windows.Forms.Button btnStackedColumn100;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Button btnStackedBar100;
        private System.Windows.Forms.Button btnColumn;
        private System.Windows.Forms.Button btnBar;
        private System.Windows.Forms.Button btnStackedColumn;
        private System.Windows.Forms.Button btnStackedBar;
        private System.Windows.Forms.ComboBox cboDrawingStyle;
    }
}