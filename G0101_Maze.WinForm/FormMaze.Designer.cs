namespace G0101_Maze.WinForm
{
    partial class FormMaze
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaze));
            this.imgLstMaze = new System.Windows.Forms.ImageList(this.components);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imgLstMaze
            // 
            this.imgLstMaze.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMaze.ImageStream")));
            this.imgLstMaze.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMaze.Images.SetKeyName(0, "START");
            this.imgLstMaze.Images.SetKeyName(1, "FINISH");
            this.imgLstMaze.Images.SetKeyName(2, "BLANK");
            this.imgLstMaze.Images.SetKeyName(3, "WALL");
            this.imgLstMaze.Images.SetKeyName(4, "USER");
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Location = new System.Drawing.Point(12, 42);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(200, 100);
            this.tlpMain.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 282);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tlpMain);
            this.KeyPreview = true;
            this.Name = "FormMaze";
            this.Text = "迷宫";
            this.Load += new System.EventHandler(this.FormMaze_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMaze_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMaze_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgLstMaze;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnStart;
    }
}

