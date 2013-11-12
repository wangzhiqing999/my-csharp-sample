namespace A5040_MDI_SubForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rootToolStripMenuItem
            // 
            this.rootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.singtonToolStripMenuItem,
            this.closeOpenToolStripMenuItem});
            this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
            this.rootToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.rootToolStripMenuItem.Text = "打开子窗口";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "普通方式";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // singtonToolStripMenuItem
            // 
            this.singtonToolStripMenuItem.Name = "singtonToolStripMenuItem";
            this.singtonToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.singtonToolStripMenuItem.Text = "单例方式";
            this.singtonToolStripMenuItem.Click += new System.EventHandler(this.singtonToolStripMenuItem_Click);
            // 
            // closeOpenToolStripMenuItem
            // 
            this.closeOpenToolStripMenuItem.Name = "closeOpenToolStripMenuItem";
            this.closeOpenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeOpenToolStripMenuItem.Text = "先关后开";
            this.closeOpenToolStripMenuItem.Click += new System.EventHandler(this.closeOpenToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 280);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "MDI 主窗口";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeOpenToolStripMenuItem;
    }
}

