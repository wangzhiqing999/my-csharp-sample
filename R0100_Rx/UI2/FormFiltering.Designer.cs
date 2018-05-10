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
            this.tlpMain.Controls.Add(this.btnFirst, 1, 1);
            this.tlpMain.Controls.Add(this.btnDistinctUntilChanged, 0, 1);
            this.tlpMain.Controls.Add(this.txtResult, 0, 3);
            this.tlpMain.Controls.Add(this.btnWhere, 0, 0);
            this.tlpMain.Controls.Add(this.btnTake, 1, 0);
            this.tlpMain.Controls.Add(this.btnDistinct, 3, 0);
            this.tlpMain.Controls.Add(this.btnTakeLast, 2, 0);
            this.tlpMain.Controls.Add(this.btnLast, 2, 1);
            this.tlpMain.Controls.Add(this.btnSample, 3, 1);
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
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(199, 38);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(190, 23);
            this.btnFirst.TabIndex = 13;
            this.btnFirst.Text = "使用 First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnDistinctUntilChanged
            // 
            this.btnDistinctUntilChanged.Location = new System.Drawing.Point(3, 38);
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
            this.txtResult.Location = new System.Drawing.Point(3, 108);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(778, 250);
            this.txtResult.TabIndex = 11;
            // 
            // btnWhere
            // 
            this.btnWhere.Location = new System.Drawing.Point(3, 3);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(190, 23);
            this.btnWhere.TabIndex = 6;
            this.btnWhere.Text = "使用 Where";
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(199, 3);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(190, 23);
            this.btnTake.TabIndex = 7;
            this.btnTake.Text = "使用 Take";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // btnDistinct
            // 
            this.btnDistinct.Location = new System.Drawing.Point(591, 3);
            this.btnDistinct.Name = "btnDistinct";
            this.btnDistinct.Size = new System.Drawing.Size(190, 23);
            this.btnDistinct.TabIndex = 9;
            this.btnDistinct.Text = "使用 Distinct ";
            this.btnDistinct.UseVisualStyleBackColor = true;
            this.btnDistinct.Click += new System.EventHandler(this.btnDistinct_Click);
            // 
            // btnTakeLast
            // 
            this.btnTakeLast.Location = new System.Drawing.Point(395, 3);
            this.btnTakeLast.Name = "btnTakeLast";
            this.btnTakeLast.Size = new System.Drawing.Size(190, 23);
            this.btnTakeLast.TabIndex = 8;
            this.btnTakeLast.Text = "使用 TakeLast";
            this.btnTakeLast.UseVisualStyleBackColor = true;
            this.btnTakeLast.Click += new System.EventHandler(this.btnTakeLast_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(395, 38);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(190, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "使用 Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSample
            // 
            this.btnSample.Location = new System.Drawing.Point(591, 38);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(190, 23);
            this.btnSample.TabIndex = 15;
            this.btnSample.Text = "使用 Sample";
            this.btnSample.UseVisualStyleBackColor = true;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
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
    }
}