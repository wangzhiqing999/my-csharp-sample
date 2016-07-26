namespace A5300_UDP_P2P
{
    partial class FormBase
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnFunc1 = new System.Windows.Forms.Button();
            this.btnFunc2 = new System.Windows.Forms.Button();
            this.btnFunc3 = new System.Windows.Forms.Button();
            this.btnFunc4 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 70);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(431, 35);
            label3.TabIndex = 9;
            label3.Text = "用户名";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(431, 35);
            label2.TabIndex = 2;
            label2.Text = "服务器端口";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(431, 35);
            label1.TabIndex = 0;
            label1.Text = "服务器ip地址";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.btnFunc4, 1, 5);
            this.tlpMain.Controls.Add(this.btnFunc3, 0, 5);
            this.tlpMain.Controls.Add(this.txtUserName, 1, 2);
            this.tlpMain.Controls.Add(label3, 0, 2);
            this.tlpMain.Controls.Add(this.btnLogout, 0, 6);
            this.tlpMain.Controls.Add(label2, 0, 1);
            this.tlpMain.Controls.Add(label1, 0, 0);
            this.tlpMain.Controls.Add(this.txtServerIP, 1, 0);
            this.tlpMain.Controls.Add(this.nudServerPort, 1, 1);
            this.tlpMain.Controls.Add(this.txtResult, 0, 7);
            this.tlpMain.Controls.Add(this.btnLogin, 0, 3);
            this.tlpMain.Controls.Add(this.btnFunc1, 0, 4);
            this.tlpMain.Controls.Add(this.btnFunc2, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 8;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(875, 521);
            this.tlpMain.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(440, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(432, 21);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Text = "Test_1";
            // 
            // btnLogout
            // 
            this.tlpMain.SetColumnSpan(this.btnLogout, 2);
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Location = new System.Drawing.Point(3, 213);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(869, 29);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIP.Location = new System.Drawing.Point(440, 7);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(432, 21);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // nudServerPort
            // 
            this.nudServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudServerPort.Location = new System.Drawing.Point(440, 42);
            this.nudServerPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(432, 21);
            this.nudServerPort.TabIndex = 3;
            this.nudServerPort.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // txtResult
            // 
            this.tlpMain.SetColumnSpan(this.txtResult, 2);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 248);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(869, 270);
            this.txtResult.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.tlpMain.SetColumnSpan(this.btnLogin, 2);
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Location = new System.Drawing.Point(3, 108);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(869, 29);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnFunc1
            // 
            this.btnFunc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunc1.Location = new System.Drawing.Point(3, 143);
            this.btnFunc1.Name = "btnFunc1";
            this.btnFunc1.Size = new System.Drawing.Size(431, 29);
            this.btnFunc1.TabIndex = 11;
            this.btnFunc1.Text = "Func1";
            this.btnFunc1.UseVisualStyleBackColor = true;
            this.btnFunc1.Click += new System.EventHandler(this.btnFunc1_Click);
            // 
            // btnFunc2
            // 
            this.btnFunc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunc2.Location = new System.Drawing.Point(440, 143);
            this.btnFunc2.Name = "btnFunc2";
            this.btnFunc2.Size = new System.Drawing.Size(432, 29);
            this.btnFunc2.TabIndex = 12;
            this.btnFunc2.Text = "Func2";
            this.btnFunc2.UseVisualStyleBackColor = true;
            this.btnFunc2.Click += new System.EventHandler(this.btnFunc2_Click);
            // 
            // btnFunc3
            // 
            this.btnFunc3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunc3.Location = new System.Drawing.Point(3, 178);
            this.btnFunc3.Name = "btnFunc3";
            this.btnFunc3.Size = new System.Drawing.Size(431, 29);
            this.btnFunc3.TabIndex = 13;
            this.btnFunc3.Text = "Func3";
            this.btnFunc3.UseVisualStyleBackColor = true;
            this.btnFunc3.Visible = false;
            this.btnFunc3.Click += new System.EventHandler(this.btnFunc3_Click);
            // 
            // btnFunc4
            // 
            this.btnFunc4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunc4.Location = new System.Drawing.Point(440, 178);
            this.btnFunc4.Name = "btnFunc4";
            this.btnFunc4.Size = new System.Drawing.Size(432, 29);
            this.btnFunc4.TabIndex = 14;
            this.btnFunc4.Text = "Func4";
            this.btnFunc4.UseVisualStyleBackColor = true;
            this.btnFunc4.Visible = false;
            this.btnFunc4.Click += new System.EventHandler(this.btnFunc4_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 521);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormBase";
            this.Text = "FormBase";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnLogin;
        protected System.Windows.Forms.Button btnFunc1;
        protected System.Windows.Forms.Button btnFunc2;
        protected System.Windows.Forms.Button btnFunc4;
        protected System.Windows.Forms.Button btnFunc3;
    }
}