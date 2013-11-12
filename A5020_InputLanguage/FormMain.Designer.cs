namespace A5020_InputLanguage
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
            this.lblCurrentInputLanguage = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInstalledInputLanguages = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblWarn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentInputLanguage
            // 
            this.lblCurrentInputLanguage.AutoSize = true;
            this.lblCurrentInputLanguage.Location = new System.Drawing.Point(34, 26);
            this.lblCurrentInputLanguage.Name = "lblCurrentInputLanguage";
            this.lblCurrentInputLanguage.Size = new System.Drawing.Size(143, 12);
            this.lblCurrentInputLanguage.TabIndex = 0;
            this.lblCurrentInputLanguage.Text = "lblCurrentInputLanguage";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(216, 134);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(187, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(216, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(187, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "已安装输入法";
            // 
            // cboInstalledInputLanguages
            // 
            this.cboInstalledInputLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstalledInputLanguages.FormattingEnabled = true;
            this.cboInstalledInputLanguages.Location = new System.Drawing.Point(135, 57);
            this.cboInstalledInputLanguages.Name = "cboInstalledInputLanguages";
            this.cboInstalledInputLanguages.Size = new System.Drawing.Size(268, 20);
            this.cboInstalledInputLanguages.TabIndex = 6;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(441, 53);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "修改输入法";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Font = new System.Drawing.Font("宋体", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWarn.ForeColor = System.Drawing.Color.Red;
            this.lblWarn.Location = new System.Drawing.Point(79, 226);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(480, 16);
            this.lblWarn.TabIndex = 8;
            this.lblWarn.Text = "注意：当前Caps lock是大写，请注意，密码是区分大小西的。";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 297);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.cboInstalledInputLanguages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblCurrentInputLanguage);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入法相关处理";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentInputLanguage;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboInstalledInputLanguages;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblWarn;
    }
}

