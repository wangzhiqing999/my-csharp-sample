namespace A5126_WebBrowserAjax
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pnlFoot = new System.Windows.Forms.Panel();
            this.btnAppendScript2 = new System.Windows.Forms.Button();
            this.btnAppendScript1 = new System.Windows.Forms.Button();
            this.btnCallScript4 = new System.Windows.Forms.Button();
            this.btnCallScript3 = new System.Windows.Forms.Button();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.btnCallScript2 = new System.Windows.Forms.Button();
            this.btnCallScript1 = new System.Windows.Forms.Button();
            this.btnShowHtml = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.pnlFoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlHead, 0, 0);
            this.tlpMain.Controls.Add(this.webBrowser1, 0, 1);
            this.tlpMain.Controls.Add(this.pnlFoot, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(1243, 511);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblStatus);
            this.pnlHead.Controls.Add(this.btnGo);
            this.pnlHead.Controls.Add(this.txtUrl);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHead.Location = new System.Drawing.Point(3, 3);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1019, 44);
            this.pnlHead.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(824, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(11, 12);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "-";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(655, 9);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "页面浏览";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(10, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(616, 21);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://localhost:8317/TestPage001.htm";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 53);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1237, 405);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pnlFoot
            // 
            this.pnlFoot.Controls.Add(this.btnShowHtml);
            this.pnlFoot.Controls.Add(this.btnAppendScript2);
            this.pnlFoot.Controls.Add(this.btnAppendScript1);
            this.pnlFoot.Controls.Add(this.btnCallScript4);
            this.pnlFoot.Controls.Add(this.btnCallScript3);
            this.pnlFoot.Controls.Add(this.txtParamValue);
            this.pnlFoot.Controls.Add(this.btnCallScript2);
            this.pnlFoot.Controls.Add(this.btnCallScript1);
            this.pnlFoot.Location = new System.Drawing.Point(3, 464);
            this.pnlFoot.Name = "pnlFoot";
            this.pnlFoot.Size = new System.Drawing.Size(1011, 44);
            this.pnlFoot.TabIndex = 2;
            // 
            // btnAppendScript2
            // 
            this.btnAppendScript2.Location = new System.Drawing.Point(816, 12);
            this.btnAppendScript2.Name = "btnAppendScript2";
            this.btnAppendScript2.Size = new System.Drawing.Size(176, 23);
            this.btnAppendScript2.TabIndex = 6;
            this.btnAppendScript2.Text = "注入脚本获取页面动态数据";
            this.btnAppendScript2.UseVisualStyleBackColor = true;
            this.btnAppendScript2.Click += new System.EventHandler(this.btnAppendScript2_Click);
            // 
            // btnAppendScript1
            // 
            this.btnAppendScript1.Location = new System.Drawing.Point(691, 12);
            this.btnAppendScript1.Name = "btnAppendScript1";
            this.btnAppendScript1.Size = new System.Drawing.Size(110, 23);
            this.btnAppendScript1.TabIndex = 5;
            this.btnAppendScript1.Text = "注入脚本并执行";
            this.btnAppendScript1.UseVisualStyleBackColor = true;
            this.btnAppendScript1.Click += new System.EventHandler(this.btnAppendScript1_Click);
            // 
            // btnCallScript4
            // 
            this.btnCallScript4.Location = new System.Drawing.Point(567, 12);
            this.btnCallScript4.Name = "btnCallScript4";
            this.btnCallScript4.Size = new System.Drawing.Size(75, 23);
            this.btnCallScript4.TabIndex = 4;
            this.btnCallScript4.Text = "调用脚本4";
            this.btnCallScript4.UseVisualStyleBackColor = true;
            this.btnCallScript4.Click += new System.EventHandler(this.btnCallScript4_Click);
            // 
            // btnCallScript3
            // 
            this.btnCallScript3.Location = new System.Drawing.Point(470, 12);
            this.btnCallScript3.Name = "btnCallScript3";
            this.btnCallScript3.Size = new System.Drawing.Size(75, 23);
            this.btnCallScript3.TabIndex = 3;
            this.btnCallScript3.Text = "调用脚本3";
            this.btnCallScript3.UseVisualStyleBackColor = true;
            this.btnCallScript3.Click += new System.EventHandler(this.btnCallScript3_Click);
            // 
            // txtParamValue
            // 
            this.txtParamValue.Location = new System.Drawing.Point(266, 12);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(100, 21);
            this.txtParamValue.TabIndex = 2;
            this.txtParamValue.Text = "调用脚本参数";
            // 
            // btnCallScript2
            // 
            this.btnCallScript2.Location = new System.Drawing.Point(372, 12);
            this.btnCallScript2.Name = "btnCallScript2";
            this.btnCallScript2.Size = new System.Drawing.Size(75, 23);
            this.btnCallScript2.TabIndex = 1;
            this.btnCallScript2.Text = "调用脚本2";
            this.btnCallScript2.UseVisualStyleBackColor = true;
            this.btnCallScript2.Click += new System.EventHandler(this.btnCallScript2_Click);
            // 
            // btnCallScript1
            // 
            this.btnCallScript1.Location = new System.Drawing.Point(159, 12);
            this.btnCallScript1.Name = "btnCallScript1";
            this.btnCallScript1.Size = new System.Drawing.Size(75, 23);
            this.btnCallScript1.TabIndex = 0;
            this.btnCallScript1.Text = "调用脚本1";
            this.btnCallScript1.UseVisualStyleBackColor = true;
            this.btnCallScript1.Click += new System.EventHandler(this.btnCallScript1_Click);
            // 
            // btnShowHtml
            // 
            this.btnShowHtml.Location = new System.Drawing.Point(20, 9);
            this.btnShowHtml.Name = "btnShowHtml";
            this.btnShowHtml.Size = new System.Drawing.Size(75, 23);
            this.btnShowHtml.TabIndex = 7;
            this.btnShowHtml.Text = "显示 HTML";
            this.btnShowHtml.UseVisualStyleBackColor = true;
            this.btnShowHtml.Click += new System.EventHandler(this.btnShowHtml_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 511);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tlpMain.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlFoot.ResumeLayout(false);
            this.pnlFoot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlFoot;
        private System.Windows.Forms.Button btnCallScript1;
        private System.Windows.Forms.Button btnCallScript2;
        private System.Windows.Forms.TextBox txtParamValue;
        private System.Windows.Forms.Button btnCallScript3;
        private System.Windows.Forms.Button btnCallScript4;
        private System.Windows.Forms.Button btnAppendScript1;
        private System.Windows.Forms.Button btnAppendScript2;
        private System.Windows.Forms.Button btnShowHtml;
    }
}

