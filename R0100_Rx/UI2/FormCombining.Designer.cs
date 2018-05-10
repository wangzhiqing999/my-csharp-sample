namespace R0100_Rx.UI2
{
    partial class FormCombining
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnMerege = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnCombineLatest = new System.Windows.Forms.Button();
            this.btnAndThenWhen = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnStartWith = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.txtResult, 0, 3);
            this.tlpMain.Controls.Add(this.btnZip, 0, 0);
            this.tlpMain.Controls.Add(this.btnMerege, 1, 0);
            this.tlpMain.Controls.Add(this.btnJoin, 2, 0);
            this.tlpMain.Controls.Add(this.btnCombineLatest, 3, 0);
            this.tlpMain.Controls.Add(this.btnAndThenWhen, 0, 1);
            this.tlpMain.Controls.Add(this.btnSwitch, 1, 1);
            this.tlpMain.Controls.Add(this.btnStartWith, 2, 1);
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
            this.tlpMain.TabIndex = 15;
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
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(3, 3);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(190, 23);
            this.btnZip.TabIndex = 6;
            this.btnZip.Text = "使用 Zip";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnMerege
            // 
            this.btnMerege.Location = new System.Drawing.Point(199, 3);
            this.btnMerege.Name = "btnMerege";
            this.btnMerege.Size = new System.Drawing.Size(190, 23);
            this.btnMerege.TabIndex = 7;
            this.btnMerege.Text = "使用 Merege";
            this.btnMerege.UseVisualStyleBackColor = true;
            this.btnMerege.Click += new System.EventHandler(this.btnMerege_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(395, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(190, 23);
            this.btnJoin.TabIndex = 12;
            this.btnJoin.Text = "使用 Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnCombineLatest
            // 
            this.btnCombineLatest.Location = new System.Drawing.Point(591, 3);
            this.btnCombineLatest.Name = "btnCombineLatest";
            this.btnCombineLatest.Size = new System.Drawing.Size(190, 23);
            this.btnCombineLatest.TabIndex = 13;
            this.btnCombineLatest.Text = "使用 CombineLatest";
            this.btnCombineLatest.UseVisualStyleBackColor = true;
            this.btnCombineLatest.Click += new System.EventHandler(this.btnCombineLatest_Click);
            // 
            // btnAndThenWhen
            // 
            this.btnAndThenWhen.Location = new System.Drawing.Point(3, 38);
            this.btnAndThenWhen.Name = "btnAndThenWhen";
            this.btnAndThenWhen.Size = new System.Drawing.Size(190, 23);
            this.btnAndThenWhen.TabIndex = 14;
            this.btnAndThenWhen.Text = "使用 And-Then-When";
            this.btnAndThenWhen.UseVisualStyleBackColor = true;
            this.btnAndThenWhen.Click += new System.EventHandler(this.btnAndThenWhen_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(199, 38);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(190, 23);
            this.btnSwitch.TabIndex = 15;
            this.btnSwitch.Text = "使用 Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnStartWith
            // 
            this.btnStartWith.Location = new System.Drawing.Point(395, 38);
            this.btnStartWith.Name = "btnStartWith";
            this.btnStartWith.Size = new System.Drawing.Size(190, 23);
            this.btnStartWith.TabIndex = 16;
            this.btnStartWith.Text = "使用 StartWith";
            this.btnStartWith.UseVisualStyleBackColor = true;
            this.btnStartWith.Click += new System.EventHandler(this.btnStartWith_Click);
            // 
            // FormCombining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormCombining";
            this.Text = "结合操作";
            this.Load += new System.EventHandler(this.FormCombining_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnMerege;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnCombineLatest;
        private System.Windows.Forms.Button btnAndThenWhen;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnStartWith;
    }
}