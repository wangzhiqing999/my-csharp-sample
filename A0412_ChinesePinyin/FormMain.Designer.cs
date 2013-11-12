namespace A0412_ChinesePinyin
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBaseInfo = new System.Windows.Forms.Label();
            this.txtBaseText = new System.Windows.Forms.TextBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnCopyFromBaseToReplace = new System.Windows.Forms.Button();
            this.btnCopyFromReplaceToBase = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaseInfo
            // 
            this.lblBaseInfo.AutoSize = true;
            this.lblBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaseInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBaseInfo.Location = new System.Drawing.Point(205, 0);
            this.lblBaseInfo.Name = "lblBaseInfo";
            this.lblBaseInfo.Size = new System.Drawing.Size(196, 30);
            this.lblBaseInfo.TabIndex = 0;
            this.lblBaseInfo.Text = "初始文本信息";
            this.lblBaseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBaseText
            // 
            this.tlpMain.SetColumnSpan(this.txtBaseText, 3);
            this.txtBaseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBaseText.Location = new System.Drawing.Point(3, 33);
            this.txtBaseText.Multiline = true;
            this.txtBaseText.Name = "txtBaseText";
            this.txtBaseText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBaseText.Size = new System.Drawing.Size(602, 106);
            this.txtBaseText.TabIndex = 1;
            this.txtBaseText.Text = "像楼主这样纯洁的人啊，喜欢萌妹子，出门想的就是如何造福人类。";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.txtResult, 0, 5);
            this.tlpMain.Controls.Add(this.txtReplace, 0, 3);
            this.tlpMain.Controls.Add(this.label1, 1, 2);
            this.tlpMain.Controls.Add(this.lblBaseInfo, 1, 0);
            this.tlpMain.Controls.Add(this.txtBaseText, 0, 1);
            this.tlpMain.Controls.Add(this.btnCopyFromBaseToReplace, 0, 2);
            this.tlpMain.Controls.Add(this.btnCopyFromReplaceToBase, 2, 2);
            this.tlpMain.Controls.Add(this.btnCreate, 1, 4);
            this.tlpMain.Controls.Add(this.btnReset, 2, 0);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Size = new System.Drawing.Size(608, 429);
            this.tlpMain.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(205, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "替换文本信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReplace
            // 
            this.tlpMain.SetColumnSpan(this.txtReplace, 3);
            this.txtReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplace.Location = new System.Drawing.Point(3, 175);
            this.txtReplace.Multiline = true;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplace.Size = new System.Drawing.Size(602, 106);
            this.txtReplace.TabIndex = 3;
            this.txtReplace.Text = "像楼主这样猥琐的人啊，喜欢重口味，出门想的就是如何报复社会。";
            // 
            // btnCopyFromBaseToReplace
            // 
            this.btnCopyFromBaseToReplace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopyFromBaseToReplace.Location = new System.Drawing.Point(51, 145);
            this.btnCopyFromBaseToReplace.Name = "btnCopyFromBaseToReplace";
            this.btnCopyFromBaseToReplace.Size = new System.Drawing.Size(100, 23);
            this.btnCopyFromBaseToReplace.TabIndex = 4;
            this.btnCopyFromBaseToReplace.Text = "向下复制(&D)";
            this.btnCopyFromBaseToReplace.UseVisualStyleBackColor = true;
            this.btnCopyFromBaseToReplace.Click += new System.EventHandler(this.btnCopyFromBaseToReplace_Click);
            // 
            // btnCopyFromReplaceToBase
            // 
            this.btnCopyFromReplaceToBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopyFromReplaceToBase.Location = new System.Drawing.Point(456, 145);
            this.btnCopyFromReplaceToBase.Name = "btnCopyFromReplaceToBase";
            this.btnCopyFromReplaceToBase.Size = new System.Drawing.Size(100, 23);
            this.btnCopyFromReplaceToBase.TabIndex = 5;
            this.btnCopyFromReplaceToBase.Text = "向上复制(&U)";
            this.btnCopyFromReplaceToBase.UseVisualStyleBackColor = true;
            this.btnCopyFromReplaceToBase.Click += new System.EventHandler(this.btnCopyFromReplaceToBase_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.Location = new System.Drawing.Point(253, 287);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "生成文本(&C)";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 3);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 317);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(602, 109);
            this.txtResult.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Location = new System.Drawing.Point(446, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "清除全部输入(&R)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汉字拼音替换处理";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBaseInfo;
        private System.Windows.Forms.TextBox txtBaseText;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyFromBaseToReplace;
        private System.Windows.Forms.Button btnCopyFromReplaceToBase;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnReset;

    }
}

