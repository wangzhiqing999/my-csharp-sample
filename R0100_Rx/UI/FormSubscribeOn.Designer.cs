namespace R0100_Rx.UI
{
    partial class FormSubscribeOn
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
            this.btnNewThreadScheduler = new System.Windows.Forms.Button();
            this.btnThreadPoolScheduler = new System.Windows.Forms.Button();
            this.btnWithoutSubscribeOn = new System.Windows.Forms.Button();
            this.btnSubscribeOnObserveOn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "这里仅仅是用于演示，如何使用 SubscribeOn， 因此， 没有与 WinForm 的相关操作，结果都输出到控制台了。";
            // 
            // btnNewThreadScheduler
            // 
            this.btnNewThreadScheduler.Location = new System.Drawing.Point(30, 138);
            this.btnNewThreadScheduler.Name = "btnNewThreadScheduler";
            this.btnNewThreadScheduler.Size = new System.Drawing.Size(597, 23);
            this.btnNewThreadScheduler.TabIndex = 2;
            this.btnNewThreadScheduler.Text = ".SubscribeOn(NewThreadScheduler.Default)";
            this.btnNewThreadScheduler.UseVisualStyleBackColor = true;
            this.btnNewThreadScheduler.Click += new System.EventHandler(this.btnNewThreadScheduler_Click);
            // 
            // btnThreadPoolScheduler
            // 
            this.btnThreadPoolScheduler.Location = new System.Drawing.Point(30, 199);
            this.btnThreadPoolScheduler.Name = "btnThreadPoolScheduler";
            this.btnThreadPoolScheduler.Size = new System.Drawing.Size(597, 23);
            this.btnThreadPoolScheduler.TabIndex = 3;
            this.btnThreadPoolScheduler.Text = ".SubscribeOn(ThreadPoolScheduler.Instance)";
            this.btnThreadPoolScheduler.UseVisualStyleBackColor = true;
            this.btnThreadPoolScheduler.Click += new System.EventHandler(this.btnThreadPoolScheduler_Click);
            // 
            // btnWithoutSubscribeOn
            // 
            this.btnWithoutSubscribeOn.Location = new System.Drawing.Point(30, 77);
            this.btnWithoutSubscribeOn.Name = "btnWithoutSubscribeOn";
            this.btnWithoutSubscribeOn.Size = new System.Drawing.Size(597, 23);
            this.btnWithoutSubscribeOn.TabIndex = 4;
            this.btnWithoutSubscribeOn.Text = "默认情况下";
            this.btnWithoutSubscribeOn.UseVisualStyleBackColor = true;
            this.btnWithoutSubscribeOn.Click += new System.EventHandler(this.btnWithoutSubscribeOn_Click);
            // 
            // btnSubscribeOnObserveOn
            // 
            this.btnSubscribeOnObserveOn.Location = new System.Drawing.Point(30, 274);
            this.btnSubscribeOnObserveOn.Name = "btnSubscribeOnObserveOn";
            this.btnSubscribeOnObserveOn.Size = new System.Drawing.Size(597, 23);
            this.btnSubscribeOnObserveOn.TabIndex = 5;
            this.btnSubscribeOnObserveOn.Text = "SubscribeOn / ObserveOn";
            this.btnSubscribeOnObserveOn.UseVisualStyleBackColor = true;
            this.btnSubscribeOnObserveOn.Click += new System.EventHandler(this.btnSubscribeOnObserveOn_Click);
            // 
            // FormSubscribeOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 485);
            this.Controls.Add(this.btnSubscribeOnObserveOn);
            this.Controls.Add(this.btnWithoutSubscribeOn);
            this.Controls.Add(this.btnThreadPoolScheduler);
            this.Controls.Add(this.btnNewThreadScheduler);
            this.Controls.Add(this.label1);
            this.Name = "FormSubscribeOn";
            this.Text = "FormSubscribeOn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewThreadScheduler;
        private System.Windows.Forms.Button btnThreadPoolScheduler;
        private System.Windows.Forms.Button btnWithoutSubscribeOn;
        private System.Windows.Forms.Button btnSubscribeOnObserveOn;
    }
}