namespace R0100_Rx.UI
{
    partial class FormNewObservable
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRange = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnInterval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "这里仅仅是用于演示，如何创建一个IObservable<T>， 因此， 没有与 WinForm 的相关操作，结果都输出到控制台了。";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(14, 58);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(259, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "使用 Observable.Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(14, 112);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(259, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "使用 Observable.Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRange
            // 
            this.btnRange.Location = new System.Drawing.Point(14, 168);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(259, 23);
            this.btnRange.TabIndex = 3;
            this.btnRange.Text = "使用 Observable.Range";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(14, 221);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(259, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "使用 Observable.Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnInterval
            // 
            this.btnInterval.Location = new System.Drawing.Point(14, 277);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(259, 23);
            this.btnInterval.TabIndex = 5;
            this.btnInterval.Text = "使用 Observable.Interval";
            this.btnInterval.UseVisualStyleBackColor = true;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // FormNewObservable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 414);
            this.Controls.Add(this.btnInterval);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnRange);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label1);
            this.Name = "FormNewObservable";
            this.Text = "新建Observable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnInterval;
    }
}