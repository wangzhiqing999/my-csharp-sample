namespace G0081_ImageSwitch
{
    partial class UcImageSwitch
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
            this.components = new System.ComponentModel.Container();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.timerSwitch = new System.Windows.Forms.Timer(this.components);
            this.picSub = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSub)).BeginInit();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Location = new System.Drawing.Point(3, 3);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(202, 166);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // timerSwitch
            // 
            this.timerSwitch.Interval = 10;
            this.timerSwitch.Tick += new System.EventHandler(this.timerSwitch_Tick);
            // 
            // picSub
            // 
            this.picSub.Location = new System.Drawing.Point(150, 40);
            this.picSub.Name = "picSub";
            this.picSub.Size = new System.Drawing.Size(202, 166);
            this.picSub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSub.TabIndex = 1;
            this.picSub.TabStop = false;
            // 
            // UcImageSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.picSub);
            this.Name = "UcImageSwitch";
            this.Size = new System.Drawing.Size(417, 254);
            this.Load += new System.EventHandler(this.UcImaheSwitch_Load);
            this.SizeChanged += new System.EventHandler(this.UcImageSwitch_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Timer timerSwitch;
        private System.Windows.Forms.PictureBox picSub;
    }
}
