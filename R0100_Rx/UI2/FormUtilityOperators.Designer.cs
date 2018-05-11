namespace R0100_Rx.UI2
{
    partial class FormUtilityOperators
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
            this.btnSynchronize = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnDelay = new System.Windows.Forms.Button();
            this.btnDelaySubscription = new System.Windows.Forms.Button();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnMaterialize = new System.Windows.Forms.Button();
            this.btnDematerialize = new System.Windows.Forms.Button();
            this.btnObserveOn = new System.Windows.Forms.Button();
            this.btnSubscribeOn = new System.Windows.Forms.Button();
            this.btnTimeInterval = new System.Windows.Forms.Button();
            this.btnTimeout = new System.Windows.Forms.Button();
            this.btnTimeoutOther = new System.Windows.Forms.Button();
            this.btnTimestamp = new System.Windows.Forms.Button();
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
            this.tlpMain.Controls.Add(this.btnSynchronize, 0, 2);
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Controls.Add(this.btnDelay, 0, 0);
            this.tlpMain.Controls.Add(this.btnDelaySubscription, 1, 0);
            this.tlpMain.Controls.Add(this.btnDo, 2, 0);
            this.tlpMain.Controls.Add(this.btnMaterialize, 3, 0);
            this.tlpMain.Controls.Add(this.btnDematerialize, 0, 1);
            this.tlpMain.Controls.Add(this.btnObserveOn, 1, 1);
            this.tlpMain.Controls.Add(this.btnSubscribeOn, 2, 1);
            this.tlpMain.Controls.Add(this.btnTimeInterval, 3, 1);
            this.tlpMain.Controls.Add(this.btnTimeout, 1, 2);
            this.tlpMain.Controls.Add(this.btnTimeoutOther, 2, 2);
            this.tlpMain.Controls.Add(this.btnTimestamp, 3, 2);
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
            this.tlpMain.TabIndex = 16;
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Location = new System.Drawing.Point(3, 73);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Size = new System.Drawing.Size(190, 23);
            this.btnSynchronize.TabIndex = 18;
            this.btnSynchronize.Text = "使用 Synchronize";
            this.btnSynchronize.UseVisualStyleBackColor = true;
            this.btnSynchronize.Click += new System.EventHandler(this.btnSerialize_Click);
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
            // btnDelay
            // 
            this.btnDelay.Location = new System.Drawing.Point(3, 3);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(190, 23);
            this.btnDelay.TabIndex = 6;
            this.btnDelay.Text = "使用 Delay";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnDelaySubscription
            // 
            this.btnDelaySubscription.Location = new System.Drawing.Point(199, 3);
            this.btnDelaySubscription.Name = "btnDelaySubscription";
            this.btnDelaySubscription.Size = new System.Drawing.Size(190, 23);
            this.btnDelaySubscription.TabIndex = 12;
            this.btnDelaySubscription.Text = "使用 DelaySubscription";
            this.btnDelaySubscription.UseVisualStyleBackColor = true;
            this.btnDelaySubscription.Click += new System.EventHandler(this.btnDelaySubscription_Click);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(395, 3);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(190, 23);
            this.btnDo.TabIndex = 7;
            this.btnDo.Text = "使用 Do";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnMaterialize
            // 
            this.btnMaterialize.Location = new System.Drawing.Point(591, 3);
            this.btnMaterialize.Name = "btnMaterialize";
            this.btnMaterialize.Size = new System.Drawing.Size(190, 23);
            this.btnMaterialize.TabIndex = 13;
            this.btnMaterialize.Text = "使用 Materialize";
            this.btnMaterialize.UseVisualStyleBackColor = true;
            this.btnMaterialize.Click += new System.EventHandler(this.btnMaterialize_Click);
            // 
            // btnDematerialize
            // 
            this.btnDematerialize.Location = new System.Drawing.Point(3, 38);
            this.btnDematerialize.Name = "btnDematerialize";
            this.btnDematerialize.Size = new System.Drawing.Size(190, 23);
            this.btnDematerialize.TabIndex = 14;
            this.btnDematerialize.Text = "使用 Dematerialize";
            this.btnDematerialize.UseVisualStyleBackColor = true;
            this.btnDematerialize.Click += new System.EventHandler(this.btnDematerialize_Click);
            // 
            // btnObserveOn
            // 
            this.btnObserveOn.Location = new System.Drawing.Point(199, 38);
            this.btnObserveOn.Name = "btnObserveOn";
            this.btnObserveOn.Size = new System.Drawing.Size(190, 23);
            this.btnObserveOn.TabIndex = 15;
            this.btnObserveOn.Text = "使用 ObserveOn";
            this.btnObserveOn.UseVisualStyleBackColor = true;
            this.btnObserveOn.Click += new System.EventHandler(this.btnObserveOn_Click);
            // 
            // btnSubscribeOn
            // 
            this.btnSubscribeOn.Location = new System.Drawing.Point(395, 38);
            this.btnSubscribeOn.Name = "btnSubscribeOn";
            this.btnSubscribeOn.Size = new System.Drawing.Size(190, 23);
            this.btnSubscribeOn.TabIndex = 16;
            this.btnSubscribeOn.Text = "使用 SubscribeOn";
            this.btnSubscribeOn.UseVisualStyleBackColor = true;
            this.btnSubscribeOn.Click += new System.EventHandler(this.btnSubscribeOn_Click);
            // 
            // btnTimeInterval
            // 
            this.btnTimeInterval.Location = new System.Drawing.Point(591, 38);
            this.btnTimeInterval.Name = "btnTimeInterval";
            this.btnTimeInterval.Size = new System.Drawing.Size(190, 23);
            this.btnTimeInterval.TabIndex = 17;
            this.btnTimeInterval.Text = "使用 TimeInterval";
            this.btnTimeInterval.UseVisualStyleBackColor = true;
            this.btnTimeInterval.Click += new System.EventHandler(this.btnTimeInterval_Click);
            // 
            // btnTimeout
            // 
            this.btnTimeout.Location = new System.Drawing.Point(199, 73);
            this.btnTimeout.Name = "btnTimeout";
            this.btnTimeout.Size = new System.Drawing.Size(190, 23);
            this.btnTimeout.TabIndex = 19;
            this.btnTimeout.Text = "使用 Timeout";
            this.btnTimeout.UseVisualStyleBackColor = true;
            this.btnTimeout.Click += new System.EventHandler(this.btnTimeout_Click);
            // 
            // btnTimeoutOther
            // 
            this.btnTimeoutOther.Location = new System.Drawing.Point(395, 73);
            this.btnTimeoutOther.Name = "btnTimeoutOther";
            this.btnTimeoutOther.Size = new System.Drawing.Size(190, 23);
            this.btnTimeoutOther.TabIndex = 20;
            this.btnTimeoutOther.Text = "使用 Timeout+Other";
            this.btnTimeoutOther.UseVisualStyleBackColor = true;
            this.btnTimeoutOther.Click += new System.EventHandler(this.btnTimeoutOther_Click);
            // 
            // btnTimestamp
            // 
            this.btnTimestamp.Location = new System.Drawing.Point(591, 73);
            this.btnTimestamp.Name = "btnTimestamp";
            this.btnTimestamp.Size = new System.Drawing.Size(190, 23);
            this.btnTimestamp.TabIndex = 21;
            this.btnTimestamp.Text = "使用 Timestamp";
            this.btnTimestamp.UseVisualStyleBackColor = true;
            this.btnTimestamp.Click += new System.EventHandler(this.btnTimestamp_Click);
            // 
            // FormUtilityOperators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormUtilityOperators";
            this.Text = "辅助操作";
            this.Load += new System.EventHandler(this.FormUtilityOperators_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnDelay;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnDelaySubscription;
        private System.Windows.Forms.Button btnMaterialize;
        private System.Windows.Forms.Button btnDematerialize;
        private System.Windows.Forms.Button btnObserveOn;
        private System.Windows.Forms.Button btnSubscribeOn;
        private System.Windows.Forms.Button btnTimeInterval;
        private System.Windows.Forms.Button btnSynchronize;
        private System.Windows.Forms.Button btnTimeout;
        private System.Windows.Forms.Button btnTimeoutOther;
        private System.Windows.Forms.Button btnTimestamp;
    }
}