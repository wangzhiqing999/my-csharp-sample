using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace RSALoginTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginResult = "";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            if (string.Compare(Request.RequestType, "get", true)==0)
            {
                //将私钥存Session中
                Session["private_key"] = rsa.ToXmlString(true);
            }
            else
            {
                bool bLoginSucceed = false;
                try
                {
                    // 取得未加密的数据.
                    string strUserName = Request.Form["txtUserName"];
                    postbackUserName = strUserName;


                    // 取得已加密的数据.
                    string strPwdToDecrypt = Request.Form["encrypted_pwd"];

                    // 取得密钥.
                    rsa.FromXmlString((string)Session["private_key"]);

                    // 用私钥解密.
                    byte[] result = rsa.Decrypt(HexStringToBytes(strPwdToDecrypt), false);

                    // 字符编码处理.
                    System.Text.ASCIIEncoding enc = new ASCIIEncoding();
                    string strPwd = enc.GetString(result);

                    LoginResult = String.Format(@"后台接收到的字符串信息：{0}
RSA 解密后，得到的结果：{1}
", strPwdToDecrypt, strPwd);
                }
                catch (Exception)
                {
                    LoginResult = "处理过程中发生了异常！！！";
                }
                
            }

            //把公钥适当转换，准备发往客户端
            RSAParameters parameter = rsa.ExportParameters(true);
            strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            strPublicKeyModulus = BytesToHexString(parameter.Modulus);
        }

        protected string strPublicKeyExponent = "";
        protected string strPublicKeyModulus = "";
        protected string LoginResult = "";
        protected string postbackUserName = "";
    }
}
