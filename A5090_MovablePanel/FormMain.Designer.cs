namespace A5090_MovablePanel
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
            this.btnMoveImage = new System.Windows.Forms.Button();
            this.btnMovePanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoveImage
            // 
            this.btnMoveImage.Location = new System.Drawing.Point(46, 32);
            this.btnMoveImage.Name = "btnMoveImage";
            this.btnMoveImage.Size = new System.Drawing.Size(75, 23);
            this.btnMoveImage.TabIndex = 0;
            this.btnMoveImage.Text = "移动图片";
            this.btnMoveImage.UseVisualStyleBackColor = true;
            this.btnMoveImage.Click += new System.EventHandler(this.btnMoveImage_Click);
            // 
            // btnMovePanel
            // 
            this.btnMovePanel.Location = new System.Drawing.Point(224, 31);
            this.btnMovePanel.Name = "btnMovePanel";
            this.btnMovePanel.Size = new System.Drawing.Size(75, 23);
            this.btnMovePanel.TabIndex = 1;
            this.btnMovePanel.Text = "移动Panel";
            this.btnMovePanel.UseVisualStyleBackColor = true;
            this.btnMovePanel.Click += new System.EventHandler(this.btnMovePanel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 90);
            this.Controls.Add(this.btnMovePanel);
            this.Controls.Add(this.btnMoveImage);
            this.Name = "FormMain";
            this.Text = "Panel移动";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveImage;
        private System.Windows.Forms.Button btnMovePanel;
    }
}

