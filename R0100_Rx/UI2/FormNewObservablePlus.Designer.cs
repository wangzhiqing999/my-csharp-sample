namespace R0100_Rx.UI2
{
    partial class FormNewObservablePlus
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
            this.btnInterval = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnRange = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnThrow = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnNever = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInterval
            // 
            this.btnInterval.Location = new System.Drawing.Point(3, 38);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(190, 23);
            this.btnInterval.TabIndex = 10;
            this.btnInterval.Text = "使用 Observable.Interval";
            this.btnInterval.UseVisualStyleBackColor = true;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(591, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(190, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "使用 Observable.Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnRange
            // 
            this.btnRange.Location = new System.Drawing.Point(395, 3);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(190, 23);
            this.btnRange.TabIndex = 8;
            this.btnRange.Text = "使用 Observable.Range";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(199, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(190, 23);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "使用 Observable.Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(3, 3);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(190, 23);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "使用 Observable.Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
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
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(591, 73);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(190, 23);
            this.btnRepeat.TabIndex = 12;
            this.btnRepeat.Text = "使用 Repeat";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.btnThrow, 0, 2);
            this.tlpMain.Controls.Add(this.btnTimer, 1, 1);
            this.tlpMain.Controls.Add(this.txtResult, 0, 3);
            this.tlpMain.Controls.Add(this.btnReturn, 0, 0);
            this.tlpMain.Controls.Add(this.btnInterval, 0, 1);
            this.tlpMain.Controls.Add(this.btnCreate, 1, 0);
            this.tlpMain.Controls.Add(this.btnGenerate, 3, 0);
            this.tlpMain.Controls.Add(this.btnRange, 2, 0);
            this.tlpMain.Controls.Add(this.btnEmpty, 2, 1);
            this.tlpMain.Controls.Add(this.btnRepeat, 3, 2);
            this.tlpMain.Controls.Add(this.btnNever, 3, 1);
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
            this.tlpMain.TabIndex = 13;
            // 
            // btnThrow
            // 
            this.btnThrow.Location = new System.Drawing.Point(3, 73);
            this.btnThrow.Name = "btnThrow";
            this.btnThrow.Size = new System.Drawing.Size(190, 23);
            this.btnThrow.TabIndex = 16;
            this.btnThrow.Text = "使用 Observable.Throw";
            this.btnThrow.UseVisualStyleBackColor = true;
            this.btnThrow.Click += new System.EventHandler(this.btnThrow_Click);
            // 
            // btnTimer
            // 
            this.btnTimer.Location = new System.Drawing.Point(199, 38);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(190, 23);
            this.btnTimer.TabIndex = 13;
            this.btnTimer.Text = "使用 Observable.Timer";
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(395, 38);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(190, 23);
            this.btnEmpty.TabIndex = 14;
            this.btnEmpty.Text = "使用 Observable.Empty";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnNever
            // 
            this.btnNever.Location = new System.Drawing.Point(591, 38);
            this.btnNever.Name = "btnNever";
            this.btnNever.Size = new System.Drawing.Size(190, 23);
            this.btnNever.TabIndex = 15;
            this.btnNever.Text = "使用 Observable.Never";
            this.btnNever.UseVisualStyleBackColor = true;
            this.btnNever.Click += new System.EventHandler(this.btnNever_Click);
            // 
            // FormNewObservablePlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormNewObservablePlus";
            this.Text = "创建操作";
            this.Load += new System.EventHandler(this.FormNewObservablePlus_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInterval;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btnThrow;
        private System.Windows.Forms.Button btnNever;
    }
}