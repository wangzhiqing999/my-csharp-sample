namespace G0061_Pic_Mov
{
    partial class UserControlPic2Mov
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
            this.picUser = new System.Windows.Forms.PictureBox();
            this.timerMov = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // picUser
            // 
            this.picUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUser.Location = new System.Drawing.Point(0, 0);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(223, 217);
            this.picUser.TabIndex = 1;
            this.picUser.TabStop = false;
            // 
            // timerMov
            // 
            this.timerMov.Interval = 200;
            this.timerMov.Tick += new System.EventHandler(this.timerMov_Tick);
            // 
            // UserControlPic2Mov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picUser);
            this.Name = "UserControlPic2Mov";
            this.Size = new System.Drawing.Size(223, 217);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Timer timerMov;
    }
}
