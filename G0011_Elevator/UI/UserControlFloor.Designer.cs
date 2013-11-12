namespace G0011_Elevator.UI
{
    partial class UserControlFloor
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
            this.tlpFloor = new System.Windows.Forms.TableLayoutPanel();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblFloorNum = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblCurrentFloor = new System.Windows.Forms.Label();
            this.tlpFloor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFloor
            // 
            this.tlpFloor.ColumnCount = 4;
            this.tlpFloor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFloor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFloor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFloor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFloor.Controls.Add(this.btnDown, 3, 0);
            this.tlpFloor.Controls.Add(this.lblFloorNum, 0, 0);
            this.tlpFloor.Controls.Add(this.btnUp, 1, 0);
            this.tlpFloor.Controls.Add(this.lblCurrentFloor, 2, 0);
            this.tlpFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFloor.Location = new System.Drawing.Point(0, 0);
            this.tlpFloor.Name = "tlpFloor";
            this.tlpFloor.RowCount = 1;
            this.tlpFloor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFloor.Size = new System.Drawing.Size(603, 54);
            this.tlpFloor.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Location = new System.Drawing.Point(489, 15);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "向下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lblFloorNum
            // 
            this.lblFloorNum.AutoSize = true;
            this.lblFloorNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFloorNum.Location = new System.Drawing.Point(3, 0);
            this.lblFloorNum.Name = "lblFloorNum";
            this.lblFloorNum.Size = new System.Drawing.Size(144, 54);
            this.lblFloorNum.TabIndex = 0;
            this.lblFloorNum.Text = "1楼";
            this.lblFloorNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Location = new System.Drawing.Point(187, 15);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "向上";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblCurrentFloor
            // 
            this.lblCurrentFloor.AutoSize = true;
            this.lblCurrentFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentFloor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentFloor.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentFloor.Location = new System.Drawing.Point(303, 0);
            this.lblCurrentFloor.Name = "lblCurrentFloor";
            this.lblCurrentFloor.Size = new System.Drawing.Size(144, 54);
            this.lblCurrentFloor.TabIndex = 2;
            this.lblCurrentFloor.Text = "1";
            this.lblCurrentFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpFloor);
            this.Name = "UserControlFloor";
            this.Size = new System.Drawing.Size(603, 54);
            this.tlpFloor.ResumeLayout(false);
            this.tlpFloor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpFloor;
        private System.Windows.Forms.Label lblFloorNum;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblCurrentFloor;
    }
}
