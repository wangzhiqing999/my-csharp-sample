namespace R0100_Rx.UI2
{
    partial class FormFiltering
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
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnDistinctUntilChanged = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnWhere = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.btnDistinct = new System.Windows.Forms.Button();
            this.btnTakeLast = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.btnThrottle = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnSkipLast = new System.Windows.Forms.Button();
            this.btnElementAt = new System.Windows.Forms.Button();
            this.btnIgnoreElements = new System.Windows.Forms.Button();
            this.btnOfType = new System.Windows.Forms.Button();
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
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Controls.Add(this.btnThrottle, 0, 0);
            this.tlpMain.Controls.Add(this.btnDistinct, 1, 0);
            this.tlpMain.Controls.Add(this.btnDistinctUntilChanged, 2, 0);
            this.tlpMain.Controls.Add(this.btnTake, 2, 3);
            this.tlpMain.Controls.Add(this.btnTakeLast, 3, 3);
            this.tlpMain.Controls.Add(this.btnWhere, 0, 1);
            this.tlpMain.Controls.Add(this.btnElementAt, 3, 0);
            this.tlpMain.Controls.Add(this.btnSkipLast, 3, 2);
            this.tlpMain.Controls.Add(this.btnSkip, 2, 2);
            this.tlpMain.Controls.Add(this.btnSample, 1, 2);
            this.tlpMain.Controls.Add(this.btnIgnoreElements, 0, 2);
            this.tlpMain.Controls.Add(this.btnLast, 3, 1);
            this.tlpMain.Controls.Add(this.btnFirst, 2, 1);
            this.tlpMain.Controls.Add(this.btnOfType, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(784, 361);
            this.tlpMain.TabIndex = 15;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(395, 38);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(190, 23);
            this.btnFirst.TabIndex = 13;
            this.btnFirst.Text = "使用 First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnDistinctUntilChanged
            // 
            this.btnDistinctUntilChanged.Location = new System.Drawing.Point(395, 3);
            this.btnDistinctUntilChanged.Name = "btnDistinctUntilChanged";
            this.btnDistinctUntilChanged.Size = new System.Drawing.Size(190, 23);
            this.btnDistinctUntilChanged.TabIndex = 12;
            this.btnDistinctUntilChanged.Text = "使用 DistinctUntilChanged";
            this.btnDistinctUntilChanged.UseVisualStyleBackColor = true;
            this.btnDistinctUntilChanged.Click += new System.EventHandler(this.btnDistinctUntilChanged_Click);
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 4);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 143);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(778, 215);
            this.txtResult.TabIndex = 11;
            // 
            // btnWhere
            // 
            this.btnWhere.Location = new System.Drawing.Point(3, 38);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(190, 23);
            this.btnWhere.TabIndex = 6;
            this.btnWhere.Text = "使用 Where";
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(395, 108);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(190, 23);
            this.btnTake.TabIndex = 7;
            this.btnTake.Text = "使用 Take";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // btnDistinct
            // 
            this.btnDistinct.Location = new System.Drawing.Point(199, 3);
            this.btnDistinct.Name = "btnDistinct";
            this.btnDistinct.Size = new System.Drawing.Size(190, 23);
            this.btnDistinct.TabIndex = 9;
            this.btnDistinct.Text = "使用 Distinct ";
            this.btnDistinct.UseVisualStyleBackColor = true;
            this.btnDistinct.Click += new System.EventHandler(this.btnDistinct_Click);
            // 
            // btnTakeLast
            // 
            this.btnTakeLast.Location = new System.Drawing.Point(591, 108);
            this.btnTakeLast.Name = "btnTakeLast";
            this.btnTakeLast.Size = new System.Drawing.Size(190, 23);
            this.btnTakeLast.TabIndex = 8;
            this.btnTakeLast.Text = "使用 TakeLast";
            this.btnTakeLast.UseVisualStyleBackColor = true;
            this.btnTakeLast.Click += new System.EventHandler(this.btnTakeLast_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(591, 38);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(190, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "使用 Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSample
            // 
            this.btnSample.Location = new System.Drawing.Point(199, 73);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(190, 23);
            this.btnSample.TabIndex = 15;
            this.btnSample.Text = "使用 Sample";
            this.btnSample.UseVisualStyleBackColor = true;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // btnThrottle
            // 
            this.btnThrottle.Location = new System.Drawing.Point(3, 3);
            this.btnThrottle.Name = "btnThrottle";
            this.btnThrottle.Size = new System.Drawing.Size(190, 23);
            this.btnThrottle.TabIndex = 16;
            this.btnThrottle.Text = "使用 Throttle";
            this.btnThrottle.UseVisualStyleBackColor = true;
            this.btnThrottle.Click += new System.EventHandler(this.btnThrottle_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(395, 73);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(190, 23);
            this.btnSkip.TabIndex = 17;
            this.btnSkip.Text = "使用 Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnSkipLast
            // 
            this.btnSkipLast.Location = new System.Drawing.Point(591, 73);
            this.btnSkipLast.Name = "btnSkipLast";
            this.btnSkipLast.Size = new System.Drawing.Size(190, 23);
            this.btnSkipLast.TabIndex = 18;
            this.btnSkipLast.Text = "使用 SkipLast";
            this.btnSkipLast.UseVisualStyleBackColor = true;
            this.btnSkipLast.Click += new System.EventHandler(this.btnSkipLast_Click);
            // 
            // btnElementAt
            // 
            this.btnElementAt.Location = new System.Drawing.Point(591, 3);
            this.btnElementAt.Name = "btnElementAt";
            this.btnElementAt.Size = new System.Drawing.Size(190, 23);
            this.btnElementAt.TabIndex = 19;
            this.btnElementAt.Text = "使用 ElementAt";
            this.btnElementAt.UseVisualStyleBackColor = true;
            this.btnElementAt.Click += new System.EventHandler(this.btnElementAt_Click);
            // 
            // btnIgnoreElements
            // 
            this.btnIgnoreElements.Location = new System.Drawing.Point(3, 73);
            this.btnIgnoreElements.Name = "btnIgnoreElements";
            this.btnIgnoreElements.Size = new System.Drawing.Size(190, 23);
            this.btnIgnoreElements.TabIndex = 20;
            this.btnIgnoreElements.Text = "使用 IgnoreElements";
            this.btnIgnoreElements.UseVisualStyleBackColor = true;
            this.btnIgnoreElements.Click += new System.EventHandler(this.btnIgnoreElements_Click);
            // 
            // btnOfType
            // 
            this.btnOfType.Location = new System.Drawing.Point(199, 38);
            this.btnOfType.Name = "btnOfType";
            this.btnOfType.Size = new System.Drawing.Size(190, 23);
            this.btnOfType.TabIndex = 21;
            this.btnOfType.Text = "使用 OfType";
            this.btnOfType.UseVisualStyleBackColor = true;
            this.btnOfType.Click += new System.EventHandler(this.btnOfType_Click);
            // 
            // FormFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormFiltering";
            this.Text = "过滤操作";
            this.Load += new System.EventHandler(this.FormFiltering_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnWhere;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button btnDistinct;
        private System.Windows.Forms.Button btnTakeLast;
        private System.Windows.Forms.Button btnDistinctUntilChanged;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Button btnThrottle;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnSkipLast;
        private System.Windows.Forms.Button btnElementAt;
        private System.Windows.Forms.Button btnIgnoreElements;
        private System.Windows.Forms.Button btnOfType;
    }
}