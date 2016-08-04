using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Security.Cryptography;


namespace C0021_RsaWithJava
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 私钥生成公钥.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPublic_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa_Y = new RSACryptoServiceProvider();
            rsa_Y.FromXmlString(this.txtPrivateKey.Text);

            this.txtPublicKey.Text = rsa_Y.ToXmlString(false);
        }


        /// <summary>
        /// 解密.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            RSACryptoServiceProvider rsa_Y = new RSACryptoServiceProvider();
            rsa_Y.FromXmlString(this.txtPrivateKey.Text);


            byte[] encryptedData = Convert.FromBase64String(this.txtSource.Text);

            // 解密  (私钥解密)
            byte[] decryptedData = rsa_Y.Decrypt(encryptedData, false);

            string text = Encoding.UTF8.GetString(decryptedData);

            this.lblResult.Text = text;
        }


    }
}
