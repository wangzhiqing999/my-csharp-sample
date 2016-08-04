namespace B0300_zxing
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
            this.txtEncoderContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEncode = new System.Windows.Forms.Button();
            this.picEncodedBarCode = new System.Windows.Forms.PictureBox();
            this.cmbEncoderType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEncodeDecode = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEncoderContent
            // 
            this.txtEncoderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncoderContent.Location = new System.Drawing.Point(284, 85);
            this.txtEncoderContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncoderContent.Multiline = true;
            this.txtEncoderContent.Name = "txtEncoderContent";
            this.txtEncoderContent.Size = new System.Drawing.Size(230, 129);
            this.txtEncoderContent.TabIndex = 0;
            this.txtEncoderContent.Text = "1234567890";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据：";
            // 
            // btnEncode
            // 
            this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncode.Location = new System.Drawing.Point(555, 85);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(119, 34);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "生成";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // picEncodedBarCode
            // 
            this.picEncodedBarCode.Location = new System.Drawing.Point(26, 19);
            this.picEncodedBarCode.Name = "picEncodedBarCode";
            this.picEncodedBarCode.Size = new System.Drawing.Size(214, 196);
            this.picEncodedBarCode.TabIndex = 4;
            this.picEncodedBarCode.TabStop = false;
            // 
            // cmbEncoderType
            // 
            this.cmbEncoderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoderType.FormattingEnabled = true;
            this.cmbEncoderType.Location = new System.Drawing.Point(284, 29);
            this.cmbEncoderType.Name = "cmbEncoderType";
            this.cmbEncoderType.Size = new System.Drawing.Size(231, 24);
            this.cmbEncoderType.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "类型：选择 QR_CODE输出2维码";
            // 
            // btnEncodeDecode
            // 
            this.btnEncodeDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncodeDecode.Location = new System.Drawing.Point(51, 308);
            this.btnEncodeDecode.Name = "btnEncodeDecode";
            this.btnEncodeDecode.Size = new System.Drawing.Size(119, 34);
            this.btnEncodeDecode.TabIndex = 13;
            this.btnEncodeDecode.Text = "识别二维码";
            this.btnEncodeDecode.UseVisualStyleBackColor = true;
            this.btnEncodeDecode.Click += new System.EventHandler(this.btnEncodeDecode_Click);
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(285, 279);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(230, 129);
            this.txtContent.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 421);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnEncodeDecode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEncoderType);
            this.Controls.Add(this.picEncodedBarCode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEncoderContent);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "一维码、二维码生成";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEncoderContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.PictureBox picEncodedBarCode;
        private System.Windows.Forms.ComboBox cmbEncoderType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEncodeDecode;
        private System.Windows.Forms.TextBox txtContent;
    }
}

