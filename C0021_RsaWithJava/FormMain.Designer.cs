namespace C0021_RsaWithJava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnGetPublic = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Java加密后数据";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(32, 392);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(937, 125);
            this.txtSource.TabIndex = 1;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(32, 549);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "C# 解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(163, 560);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(11, 12);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "私钥数据";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(32, 34);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivateKey.Size = new System.Drawing.Size(937, 149);
            this.txtPrivateKey.TabIndex = 5;
            this.txtPrivateKey.Text = resources.GetString("txtPrivateKey.Text");
            // 
            // btnGetPublic
            // 
            this.btnGetPublic.Location = new System.Drawing.Point(32, 199);
            this.btnGetPublic.Name = "btnGetPublic";
            this.btnGetPublic.Size = new System.Drawing.Size(128, 23);
            this.btnGetPublic.TabIndex = 6;
            this.btnGetPublic.Text = "私钥生成公钥";
            this.btnGetPublic.UseVisualStyleBackColor = true;
            this.btnGetPublic.Click += new System.EventHandler(this.btnGetPublic_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(32, 239);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublicKey.Size = new System.Drawing.Size(937, 84);
            this.txtPublicKey.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.btnGetPublic);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Java 公钥加密， C# 私钥解密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnGetPublic;
        private System.Windows.Forms.TextBox txtPublicKey;
    }
}

