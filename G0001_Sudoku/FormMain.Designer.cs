namespace G0001_Sudoku
{
    partial class FormMain
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.typeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temi9X9 = new System.Windows.Forms.ToolStripMenuItem();
            this.temi6X6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeListToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(592, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // typeListToolStripMenuItem
            // 
            this.typeListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temi9X9,
            this.temi6X6});
            this.typeListToolStripMenuItem.Name = "typeListToolStripMenuItem";
            this.typeListToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.typeListToolStripMenuItem.Text = "TypeList";
            // 
            // temi9X9
            // 
            this.temi9X9.Name = "temi9X9";
            this.temi9X9.Size = new System.Drawing.Size(152, 22);
            this.temi9X9.Text = "9x9";
            this.temi9X9.Click += new System.EventHandler(this.temi9X9_Click);
            // 
            // temi6X6
            // 
            this.temi6X6.Name = "temi6X6";
            this.temi6X6.Size = new System.Drawing.Size(152, 22);
            this.temi6X6.Text = "6x6";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数独计算";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem typeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temi9X9;
        private System.Windows.Forms.ToolStripMenuItem temi6X6;
    }
}