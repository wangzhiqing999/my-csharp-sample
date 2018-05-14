namespace R0100_Rx.UI2
{
    partial class FormConnectable
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnNoPublic = new System.Windows.Forms.Button();
            this.btnRefCount = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 4);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 108);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(778, 250);
            this.txtResult.TabIndex = 11;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.txtResult, 0, 3);
            this.tlpMain.Controls.Add(this.btnNoPublic, 0, 0);
            this.tlpMain.Controls.Add(this.btnRefCount, 0, 1);
            this.tlpMain.Controls.Add(this.btnPublish, 1, 0);
            this.tlpMain.Controls.Add(this.btnReplay, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(784, 361);
            this.tlpMain.TabIndex = 16;
            // 
            // btnNoPublic
            // 
            this.btnNoPublic.Location = new System.Drawing.Point(3, 3);
            this.btnNoPublic.Name = "btnNoPublic";
            this.btnNoPublic.Size = new System.Drawing.Size(190, 23);
            this.btnNoPublic.TabIndex = 6;
            this.btnNoPublic.Text = "不使用 Publish + Connect";
            this.btnNoPublic.UseVisualStyleBackColor = true;
            this.btnNoPublic.Click += new System.EventHandler(this.btnNoPublic_Click);
            // 
            // btnRefCount
            // 
            this.btnRefCount.Location = new System.Drawing.Point(3, 38);
            this.btnRefCount.Name = "btnRefCount";
            this.btnRefCount.Size = new System.Drawing.Size(190, 23);
            this.btnRefCount.TabIndex = 7;
            this.btnRefCount.Text = "使用 RefCount";
            this.btnRefCount.UseVisualStyleBackColor = true;
            this.btnRefCount.Click += new System.EventHandler(this.btnRefCount_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(199, 3);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(190, 23);
            this.btnPublish.TabIndex = 12;
            this.btnPublish.Text = "使用 Publish + Connect";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(199, 38);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(190, 23);
            this.btnReplay.TabIndex = 13;
            this.btnReplay.Text = "使用 Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // FormConnectable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormConnectable";
            this.Text = "连接操作";
            this.Load += new System.EventHandler(this.FormConnectable_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnNoPublic;
        private System.Windows.Forms.Button btnRefCount;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnReplay;
    }
}