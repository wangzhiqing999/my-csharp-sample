namespace G0081_ImageSwitch
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
            this.btnStart = new System.Windows.Forms.Button();
            this.ucImageSwitchRotationLeftToRight = new G0081_ImageSwitch.UcImageSwitch();
            this.ucImageSwitchRotationUpToDown = new G0081_ImageSwitch.UcImageSwitch();
            this.ucImageSwitchMoveLeftToRight = new G0081_ImageSwitch.UcImageSwitch();
            this.ucImageSwitchMoveUpToDown = new G0081_ImageSwitch.UcImageSwitch();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.AutoSize = true;
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.ucImageSwitchRotationLeftToRight, 0, 0);
            this.tlpMain.Controls.Add(this.ucImageSwitchRotationUpToDown, 1, 0);
            this.tlpMain.Controls.Add(this.ucImageSwitchMoveLeftToRight, 0, 1);
            this.tlpMain.Controls.Add(this.ucImageSwitchMoveUpToDown, 1, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(496, 267);
            this.tlpMain.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(231, 296);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始处理";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ucImageSwitchRotationLeftToRight
            // 
            this.ucImageSwitchRotationLeftToRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageSwitchRotationLeftToRight.Location = new System.Drawing.Point(4, 4);
            this.ucImageSwitchRotationLeftToRight.Name = "ucImageSwitchRotationLeftToRight";
            this.ucImageSwitchRotationLeftToRight.Pic1 = null;
            this.ucImageSwitchRotationLeftToRight.Pic2 = null;
            this.ucImageSwitchRotationLeftToRight.PicSwitchMode = G0081_ImageSwitch.UcImageSwitch.SwitchMode.LeftRightRotation;
            this.ucImageSwitchRotationLeftToRight.Size = new System.Drawing.Size(240, 126);
            this.ucImageSwitchRotationLeftToRight.TabIndex = 0;
            // 
            // ucImageSwitchRotationUpToDown
            // 
            this.ucImageSwitchRotationUpToDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageSwitchRotationUpToDown.Location = new System.Drawing.Point(251, 4);
            this.ucImageSwitchRotationUpToDown.Name = "ucImageSwitchRotationUpToDown";
            this.ucImageSwitchRotationUpToDown.Pic1 = null;
            this.ucImageSwitchRotationUpToDown.Pic2 = null;
            this.ucImageSwitchRotationUpToDown.PicSwitchMode = G0081_ImageSwitch.UcImageSwitch.SwitchMode.TopDownRotation;
            this.ucImageSwitchRotationUpToDown.Size = new System.Drawing.Size(241, 126);
            this.ucImageSwitchRotationUpToDown.TabIndex = 1;
            // 
            // ucImageSwitchMoveLeftToRight
            // 
            this.ucImageSwitchMoveLeftToRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageSwitchMoveLeftToRight.Location = new System.Drawing.Point(4, 137);
            this.ucImageSwitchMoveLeftToRight.Name = "ucImageSwitchMoveLeftToRight";
            this.ucImageSwitchMoveLeftToRight.Pic1 = null;
            this.ucImageSwitchMoveLeftToRight.Pic2 = null;
            this.ucImageSwitchMoveLeftToRight.PicSwitchMode = G0081_ImageSwitch.UcImageSwitch.SwitchMode.LeftRightMove;
            this.ucImageSwitchMoveLeftToRight.Size = new System.Drawing.Size(240, 126);
            this.ucImageSwitchMoveLeftToRight.TabIndex = 2;
            // 
            // ucImageSwitchMoveUpToDown
            // 
            this.ucImageSwitchMoveUpToDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageSwitchMoveUpToDown.Location = new System.Drawing.Point(251, 137);
            this.ucImageSwitchMoveUpToDown.Name = "ucImageSwitchMoveUpToDown";
            this.ucImageSwitchMoveUpToDown.Pic1 = null;
            this.ucImageSwitchMoveUpToDown.Pic2 = null;
            this.ucImageSwitchMoveUpToDown.PicSwitchMode = G0081_ImageSwitch.UcImageSwitch.SwitchMode.UpDownMove;
            this.ucImageSwitchMoveUpToDown.Size = new System.Drawing.Size(241, 126);
            this.ucImageSwitchMoveUpToDown.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 322);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.Text = "图片切换效果";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UcImageSwitch ucImageSwitchRotationLeftToRight;
        private System.Windows.Forms.Button btnStart;
        private UcImageSwitch ucImageSwitchRotationUpToDown;
        private UcImageSwitch ucImageSwitchMoveLeftToRight;
        private UcImageSwitch ucImageSwitchMoveUpToDown;

    }
}

