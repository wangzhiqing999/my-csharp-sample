namespace G0011_Elevator
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.ucElevato = new G0011_Elevator.UI.UserControlElevato();
            this.ucFloor6 = new G0011_Elevator.UI.UserControlFloor();
            this.ucFloor5 = new G0011_Elevator.UI.UserControlFloor();
            this.ucFloor4 = new G0011_Elevator.UI.UserControlFloor();
            this.ucFloor3 = new G0011_Elevator.UI.UserControlFloor();
            this.ucFloor2 = new G0011_Elevator.UI.UserControlFloor();
            this.ucFloor1 = new G0011_Elevator.UI.UserControlFloor();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.ucElevato, 1, 0);
            this.tlpMain.Controls.Add(this.ucFloor6, 0, 0);
            this.tlpMain.Controls.Add(this.ucFloor5, 0, 1);
            this.tlpMain.Controls.Add(this.ucFloor4, 0, 2);
            this.tlpMain.Controls.Add(this.ucFloor3, 0, 3);
            this.tlpMain.Controls.Add(this.ucFloor2, 0, 4);
            this.tlpMain.Controls.Add(this.ucFloor1, 0, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMain.Size = new System.Drawing.Size(692, 323);
            this.tlpMain.TabIndex = 0;
            // 
            // ucElevato
            // 
            this.ucElevato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucElevato.Location = new System.Drawing.Point(350, 5);
            this.ucElevato.Name = "ucElevato";
            this.tlpMain.SetRowSpan(this.ucElevato, 6);
            this.ucElevato.Size = new System.Drawing.Size(337, 313);
            this.ucElevato.TabIndex = 0;
            // 
            // ucFloor6
            // 
            this.ucFloor6.FloorNo = 0;
            this.ucFloor6.IsBottomFloor = false;
            this.ucFloor6.IsTopFloor = true;
            this.ucFloor6.Location = new System.Drawing.Point(5, 5);
            this.ucFloor6.Name = "ucFloor6";
            this.ucFloor6.Size = new System.Drawing.Size(337, 45);
            this.ucFloor6.TabIndex = 1;
            // 
            // ucFloor5
            // 
            this.ucFloor5.FloorNo = 0;
            this.ucFloor5.IsBottomFloor = false;
            this.ucFloor5.IsTopFloor = false;
            this.ucFloor5.Location = new System.Drawing.Point(5, 58);
            this.ucFloor5.Name = "ucFloor5";
            this.ucFloor5.Size = new System.Drawing.Size(337, 45);
            this.ucFloor5.TabIndex = 2;
            // 
            // ucFloor4
            // 
            this.ucFloor4.FloorNo = 0;
            this.ucFloor4.IsBottomFloor = false;
            this.ucFloor4.IsTopFloor = false;
            this.ucFloor4.Location = new System.Drawing.Point(5, 111);
            this.ucFloor4.Name = "ucFloor4";
            this.ucFloor4.Size = new System.Drawing.Size(337, 45);
            this.ucFloor4.TabIndex = 3;
            // 
            // ucFloor3
            // 
            this.ucFloor3.FloorNo = 0;
            this.ucFloor3.IsBottomFloor = false;
            this.ucFloor3.IsTopFloor = false;
            this.ucFloor3.Location = new System.Drawing.Point(5, 164);
            this.ucFloor3.Name = "ucFloor3";
            this.ucFloor3.Size = new System.Drawing.Size(337, 45);
            this.ucFloor3.TabIndex = 4;
            // 
            // ucFloor2
            // 
            this.ucFloor2.FloorNo = 0;
            this.ucFloor2.IsBottomFloor = false;
            this.ucFloor2.IsTopFloor = false;
            this.ucFloor2.Location = new System.Drawing.Point(5, 217);
            this.ucFloor2.Name = "ucFloor2";
            this.ucFloor2.Size = new System.Drawing.Size(337, 45);
            this.ucFloor2.TabIndex = 5;
            // 
            // ucFloor1
            // 
            this.ucFloor1.FloorNo = 1;
            this.ucFloor1.IsBottomFloor = true;
            this.ucFloor1.IsTopFloor = false;
            this.ucFloor1.Location = new System.Drawing.Point(5, 270);
            this.ucFloor1.Name = "ucFloor1";
            this.ucFloor1.Size = new System.Drawing.Size(337, 48);
            this.ucFloor1.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 323);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.Text = "电梯运行模拟程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UI.UserControlElevato ucElevato;
        private UI.UserControlFloor ucFloor6;
        private UI.UserControlFloor ucFloor5;
        private UI.UserControlFloor ucFloor4;
        private UI.UserControlFloor ucFloor3;
        private UI.UserControlFloor ucFloor2;
        private UI.UserControlFloor ucFloor1;
    }
}

