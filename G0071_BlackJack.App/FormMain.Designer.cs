namespace G0071_BlackJack.App
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
            this.btnOnePlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOnePlayer
            // 
            this.btnOnePlayer.Location = new System.Drawing.Point(40, 29);
            this.btnOnePlayer.Name = "btnOnePlayer";
            this.btnOnePlayer.Size = new System.Drawing.Size(75, 23);
            this.btnOnePlayer.TabIndex = 0;
            this.btnOnePlayer.Text = "单人游戏";
            this.btnOnePlayer.UseVisualStyleBackColor = true;
            this.btnOnePlayer.Click += new System.EventHandler(this.btnOnePlayer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.btnOnePlayer);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "21点";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOnePlayer;
    }
}

