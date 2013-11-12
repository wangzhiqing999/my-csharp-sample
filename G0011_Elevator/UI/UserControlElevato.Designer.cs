namespace G0011_Elevator.UI
{
    partial class UserControlElevato
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpElevato = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentFloor = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnGoto6 = new System.Windows.Forms.Button();
            this.btnGoto5 = new System.Windows.Forms.Button();
            this.btnGoto4 = new System.Windows.Forms.Button();
            this.btnGoto3 = new System.Windows.Forms.Button();
            this.btnGoto2 = new System.Windows.Forms.Button();
            this.btnGoto1 = new System.Windows.Forms.Button();
            this.lblDoorInfo = new System.Windows.Forms.Label();
            this.tlpElevato.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpElevato
            // 
            this.tlpElevato.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpElevato.ColumnCount = 3;
            this.tlpElevato.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpElevato.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpElevato.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpElevato.Controls.Add(this.lblCurrentFloor, 0, 0);
            this.tlpElevato.Controls.Add(this.pnlControl, 2, 1);
            this.tlpElevato.Controls.Add(this.lblDoorInfo, 0, 1);
            this.tlpElevato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElevato.Location = new System.Drawing.Point(0, 0);
            this.tlpElevato.Name = "tlpElevato";
            this.tlpElevato.RowCount = 2;
            this.tlpElevato.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpElevato.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElevato.Size = new System.Drawing.Size(335, 343);
            this.tlpElevato.TabIndex = 0;
            // 
            // lblCurrentFloor
            // 
            this.lblCurrentFloor.AutoSize = true;
            this.tlpElevato.SetColumnSpan(this.lblCurrentFloor, 3);
            this.lblCurrentFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentFloor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentFloor.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentFloor.Location = new System.Drawing.Point(6, 3);
            this.lblCurrentFloor.Name = "lblCurrentFloor";
            this.lblCurrentFloor.Size = new System.Drawing.Size(323, 50);
            this.lblCurrentFloor.TabIndex = 0;
            this.lblCurrentFloor.Text = "1";
            this.lblCurrentFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnGoto6);
            this.pnlControl.Controls.Add(this.btnGoto5);
            this.pnlControl.Controls.Add(this.btnGoto4);
            this.pnlControl.Controls.Add(this.btnGoto3);
            this.pnlControl.Controls.Add(this.btnGoto2);
            this.pnlControl.Controls.Add(this.btnGoto1);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.Location = new System.Drawing.Point(272, 59);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(57, 278);
            this.pnlControl.TabIndex = 1;
            // 
            // btnGoto6
            // 
            this.btnGoto6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto6.Location = new System.Drawing.Point(4, 23);
            this.btnGoto6.Name = "btnGoto6";
            this.btnGoto6.Size = new System.Drawing.Size(38, 23);
            this.btnGoto6.TabIndex = 5;
            this.btnGoto6.Text = "6";
            this.btnGoto6.UseVisualStyleBackColor = true;
            this.btnGoto6.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto5
            // 
            this.btnGoto5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto5.Location = new System.Drawing.Point(3, 69);
            this.btnGoto5.Name = "btnGoto5";
            this.btnGoto5.Size = new System.Drawing.Size(38, 23);
            this.btnGoto5.TabIndex = 4;
            this.btnGoto5.Text = "5";
            this.btnGoto5.UseVisualStyleBackColor = true;
            this.btnGoto5.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto4
            // 
            this.btnGoto4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto4.Location = new System.Drawing.Point(4, 110);
            this.btnGoto4.Name = "btnGoto4";
            this.btnGoto4.Size = new System.Drawing.Size(38, 23);
            this.btnGoto4.TabIndex = 3;
            this.btnGoto4.Text = "4";
            this.btnGoto4.UseVisualStyleBackColor = true;
            this.btnGoto4.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto3
            // 
            this.btnGoto3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto3.Location = new System.Drawing.Point(3, 149);
            this.btnGoto3.Name = "btnGoto3";
            this.btnGoto3.Size = new System.Drawing.Size(38, 23);
            this.btnGoto3.TabIndex = 2;
            this.btnGoto3.Text = "3";
            this.btnGoto3.UseVisualStyleBackColor = true;
            this.btnGoto3.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto2
            // 
            this.btnGoto2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto2.Location = new System.Drawing.Point(4, 187);
            this.btnGoto2.Name = "btnGoto2";
            this.btnGoto2.Size = new System.Drawing.Size(38, 23);
            this.btnGoto2.TabIndex = 1;
            this.btnGoto2.Text = "2";
            this.btnGoto2.UseVisualStyleBackColor = true;
            this.btnGoto2.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto1
            // 
            this.btnGoto1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoto1.Location = new System.Drawing.Point(4, 225);
            this.btnGoto1.Name = "btnGoto1";
            this.btnGoto1.Size = new System.Drawing.Size(38, 23);
            this.btnGoto1.TabIndex = 0;
            this.btnGoto1.Text = "1";
            this.btnGoto1.UseVisualStyleBackColor = true;
            this.btnGoto1.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // lblDoorInfo
            // 
            this.lblDoorInfo.AutoSize = true;
            this.lblDoorInfo.BackColor = System.Drawing.Color.Transparent;
            this.tlpElevato.SetColumnSpan(this.lblDoorInfo, 2);
            this.lblDoorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoorInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoorInfo.Location = new System.Drawing.Point(6, 56);
            this.lblDoorInfo.Name = "lblDoorInfo";
            this.lblDoorInfo.Size = new System.Drawing.Size(257, 284);
            this.lblDoorInfo.TabIndex = 2;
            this.lblDoorInfo.Text = "关  门";
            this.lblDoorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlElevato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpElevato);
            this.Name = "UserControlElevato";
            this.Size = new System.Drawing.Size(335, 343);
            this.tlpElevato.ResumeLayout(false);
            this.tlpElevato.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpElevato;
        private System.Windows.Forms.Label lblCurrentFloor;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnGoto2;
        private System.Windows.Forms.Button btnGoto1;
        private System.Windows.Forms.Button btnGoto4;
        private System.Windows.Forms.Button btnGoto3;
        private System.Windows.Forms.Button btnGoto5;
        private System.Windows.Forms.Button btnGoto6;
        private System.Windows.Forms.Label lblDoorInfo;
    }
}
