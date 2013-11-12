namespace G0051_Jigsaw.App
{
    partial class Form3x3
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAutoProcess = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMain.Location = new System.Drawing.Point(13, 46);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Size = new System.Drawing.Size(409, 255);
            this.tlpMain.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(49, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新开始";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAutoProcess
            // 
            this.btnAutoProcess.Enabled = false;
            this.btnAutoProcess.Location = new System.Drawing.Point(189, 12);
            this.btnAutoProcess.Name = "btnAutoProcess";
            this.btnAutoProcess.Size = new System.Drawing.Size(75, 23);
            this.btnAutoProcess.TabIndex = 2;
            this.btnAutoProcess.Text = "自动处理";
            this.btnAutoProcess.UseVisualStyleBackColor = true;
            this.btnAutoProcess.Click += new System.EventHandler(this.btnAutoProcess_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(369, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(53, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3x3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 313);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnAutoProcess);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form3x3";
            this.Text = "Form3x3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAutoProcess;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}