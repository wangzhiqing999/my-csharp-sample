namespace R0100_Rx.UI2
{
    partial class FormConditionalAndBoolean
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
            this.btnTakeWhile = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAmb = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.btnDefaultIfEmpty = new System.Windows.Forms.Button();
            this.btnSequenceEqual = new System.Windows.Forms.Button();
            this.btnSkipUntil = new System.Windows.Forms.Button();
            this.btnSkipWhile = new System.Windows.Forms.Button();
            this.btnTakeUntil = new System.Windows.Forms.Button();
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
            this.tlpMain.Controls.Add(this.btnTakeWhile, 0, 2);
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Controls.Add(this.btnAll, 0, 0);
            this.tlpMain.Controls.Add(this.btnAmb, 1, 0);
            this.tlpMain.Controls.Add(this.btnContains, 2, 0);
            this.tlpMain.Controls.Add(this.btnDefaultIfEmpty, 3, 0);
            this.tlpMain.Controls.Add(this.btnSequenceEqual, 0, 1);
            this.tlpMain.Controls.Add(this.btnSkipUntil, 1, 1);
            this.tlpMain.Controls.Add(this.btnSkipWhile, 2, 1);
            this.tlpMain.Controls.Add(this.btnTakeUntil, 3, 1);
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
            this.tlpMain.TabIndex = 17;
            // 
            // btnTakeWhile
            // 
            this.btnTakeWhile.Location = new System.Drawing.Point(3, 73);
            this.btnTakeWhile.Name = "btnTakeWhile";
            this.btnTakeWhile.Size = new System.Drawing.Size(190, 23);
            this.btnTakeWhile.TabIndex = 18;
            this.btnTakeWhile.Text = "使用 TakeWhile ";
            this.btnTakeWhile.UseVisualStyleBackColor = true;
            this.btnTakeWhile.Click += new System.EventHandler(this.btnTakeWhile_Click);
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
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(3, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(190, 23);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "使用 All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAmb
            // 
            this.btnAmb.Location = new System.Drawing.Point(199, 3);
            this.btnAmb.Name = "btnAmb";
            this.btnAmb.Size = new System.Drawing.Size(190, 23);
            this.btnAmb.TabIndex = 12;
            this.btnAmb.Text = "使用 Amb";
            this.btnAmb.UseVisualStyleBackColor = true;
            this.btnAmb.Click += new System.EventHandler(this.btnAmb_Click);
            // 
            // btnContains
            // 
            this.btnContains.Location = new System.Drawing.Point(395, 3);
            this.btnContains.Name = "btnContains";
            this.btnContains.Size = new System.Drawing.Size(190, 23);
            this.btnContains.TabIndex = 7;
            this.btnContains.Text = "使用 Contains / Any";
            this.btnContains.UseVisualStyleBackColor = true;
            this.btnContains.Click += new System.EventHandler(this.btnContains_Click);
            // 
            // btnDefaultIfEmpty
            // 
            this.btnDefaultIfEmpty.Location = new System.Drawing.Point(591, 3);
            this.btnDefaultIfEmpty.Name = "btnDefaultIfEmpty";
            this.btnDefaultIfEmpty.Size = new System.Drawing.Size(190, 23);
            this.btnDefaultIfEmpty.TabIndex = 13;
            this.btnDefaultIfEmpty.Text = "使用 DefaultIfEmpty";
            this.btnDefaultIfEmpty.UseVisualStyleBackColor = true;
            this.btnDefaultIfEmpty.Click += new System.EventHandler(this.btnDefaultIfEmpty_Click);
            // 
            // btnSequenceEqual
            // 
            this.btnSequenceEqual.Location = new System.Drawing.Point(3, 38);
            this.btnSequenceEqual.Name = "btnSequenceEqual";
            this.btnSequenceEqual.Size = new System.Drawing.Size(190, 23);
            this.btnSequenceEqual.TabIndex = 14;
            this.btnSequenceEqual.Text = "使用 SequenceEqual";
            this.btnSequenceEqual.UseVisualStyleBackColor = true;
            this.btnSequenceEqual.Click += new System.EventHandler(this.btnSequenceEqual_Click);
            // 
            // btnSkipUntil
            // 
            this.btnSkipUntil.Location = new System.Drawing.Point(199, 38);
            this.btnSkipUntil.Name = "btnSkipUntil";
            this.btnSkipUntil.Size = new System.Drawing.Size(190, 23);
            this.btnSkipUntil.TabIndex = 15;
            this.btnSkipUntil.Text = "使用 SkipUntil";
            this.btnSkipUntil.UseVisualStyleBackColor = true;
            this.btnSkipUntil.Click += new System.EventHandler(this.btnSkipUntil_Click);
            // 
            // btnSkipWhile
            // 
            this.btnSkipWhile.Location = new System.Drawing.Point(395, 38);
            this.btnSkipWhile.Name = "btnSkipWhile";
            this.btnSkipWhile.Size = new System.Drawing.Size(190, 23);
            this.btnSkipWhile.TabIndex = 16;
            this.btnSkipWhile.Text = "使用 SkipWhile";
            this.btnSkipWhile.UseVisualStyleBackColor = true;
            this.btnSkipWhile.Click += new System.EventHandler(this.btnSkipWhile_Click);
            // 
            // btnTakeUntil
            // 
            this.btnTakeUntil.Location = new System.Drawing.Point(591, 38);
            this.btnTakeUntil.Name = "btnTakeUntil";
            this.btnTakeUntil.Size = new System.Drawing.Size(190, 23);
            this.btnTakeUntil.TabIndex = 17;
            this.btnTakeUntil.Text = "使用 TakeUntil ";
            this.btnTakeUntil.UseVisualStyleBackColor = true;
            this.btnTakeUntil.Click += new System.EventHandler(this.btnTakeUntil_Click);
            // 
            // FormConditionalAndBoolean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormConditionalAndBoolean";
            this.Text = "条件和布尔操作";
            this.Load += new System.EventHandler(this.FormConditionalAndBoolean_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnTakeWhile;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnAmb;
        private System.Windows.Forms.Button btnContains;
        private System.Windows.Forms.Button btnDefaultIfEmpty;
        private System.Windows.Forms.Button btnSequenceEqual;
        private System.Windows.Forms.Button btnSkipUntil;
        private System.Windows.Forms.Button btnSkipWhile;
        private System.Windows.Forms.Button btnTakeUntil;
    }
}