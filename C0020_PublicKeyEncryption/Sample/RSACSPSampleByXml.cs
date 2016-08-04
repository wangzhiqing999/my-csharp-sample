using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;



namespace C0020_PublicKeyEncryption.Sample
{


    /// <summary>
    /// 通过 XML 指定  公钥 与 私钥
    /// </summary>
    class RSACSPSampleByXml : RSACSPSample
    {


        public static void DoTestByXml()
        {

            Console.WriteLine("使用 RSACryptoServiceProvider 类将一个字符串加密为一个字节数组，然后将这些字节解密为字符串。");


            try
            {
                // Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();


                string source = "Data to Encrypt  这个是一个用于测试加密的文本信息！";


                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes(source);
                byte[] encryptedData;
                byte[] decryptedData;


                Console.WriteLine("原始文本信息：{0}", source);
                Console.WriteLine("原始数据！");
                ByteArrayOutput.Print(dataToEncrypt);

                // 加密  (公钥加密).
                encryptedData = RSAEncrypt(dataToEncrypt, GetPublicKey(), false);

                Console.WriteLine("公钥加密后的数据！");
                ByteArrayOutput.Print(encryptedData);



                // 解密  (私钥解密)
                decryptedData = RSADecrypt(encryptedData, GetPrivateKey(), false);

                Console.WriteLine("私钥解密后的数据！");
                ByteArrayOutput.Print(decryptedData);


                // 输出.
                Console.WriteLine("解密后的文本: {0}", ByteConverter.GetString(decryptedData));
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");

            }
        }









        /// <summary>
        /// 取得公钥
        /// </summary>
        /// <returns></returns>
        static RSAParameters GetPublicKey()
        {
            RSACryptoServiceProvider rsa_Y = new RSACryptoServiceProvider();
            rsa_Y.FromXmlString("<RSAKeyValue><Modulus>r6ivWiCnl7NY23RSGzskbYrjxwsbU2/is5INqNhxG3hpDv2ZIW56J5oiJBo1oJ5B3rJWfhjE4oEHbyZTZI0KWlmY3IIqPeFfS+nf7L4e6aGEk//guTZB/+b6SlS9OGLgOSuJHk2C+CmeBpuCSrvC6R/F6ItG+Rt1+EwMBqyG4T8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");


            RSAParameters result = rsa_Y.ExportParameters(false); 

            Console.WriteLine("---------- 公钥信息 ----------");
            PrintRSAParameters(result);

            return result;
        }



        /// <summary>
        /// 取得私钥
        /// </summary>
        /// <returns></returns>
        static RSAParameters GetPrivateKey()
        {
            RSACryptoServiceProvider rsa_Y = new RSACryptoServiceProvider();
            rsa_Y.FromXmlString("<RSAKeyValue><Modulus>r6ivWiCnl7NY23RSGzskbYrjxwsbU2/is5INqNhxG3hpDv2ZIW56J5oiJBo1oJ5B3rJWfhjE4oEHbyZTZI0KWlmY3IIqPeFfS+nf7L4e6aGEk//guTZB/+b6SlS9OGLgOSuJHk2C+CmeBpuCSrvC6R/F6ItG+Rt1+EwMBqyG4T8=</Modulus><Exponent>AQAB</Exponent><P>6omR0xLp/ikA8csXNjPEZFJz2I0uTw/GJGpkKfK7HVdtuEX1kj3fgALbgyLQMA0SNfKFagxHc+/po90Yfqq9Rw==</P><Q>v7vJ/4lZD3slkiQz4VCsTV9aqB99KwWbDICxXUaWeFpoMEjs2OIFNryUVTYeke1lNOvefxgjQqO6ThNDtkXYSQ==</Q><DP>acsoRifP+N+SF39etwpe2kn/C32TmAIrhJ2hFPLyyGd5jJeyEAds25duYRbBBgu/XSpKV+22BWwA3fOLawelXQ==</DP><DQ>hD3vuvJunQDhDwUtS1CrJsqH6sGdQVkiceMpch5Hlkc06WjDA2wREInM/WDQgPHuBixRT/PEDiiDTWp4H3XZEQ==</DQ><InverseQ>Z/BWBn5OMwZdaC5bQyIvPxAruuAP5cv7qhzY6d3Yd0rVIAcA1PhqffJqjEGS9ws+2ZkCE/xMDI1CZIUmWCO3vg==</InverseQ><D>ZZl5ovWUOeggEv6apul0Tm+xA2VnLsFeLGLjx6847Jyel28S7QVLXjCGYr9OGVKv4rDf2htVdXUP6bgPL+9r9pOiBqKDynpAmob1wWntmtmL3XOPlgoq/Lls3iuoiQxQMlWBCrYMfClKmYTUHUDCMRJjfpGQzy+GwSdFLTnyEmE=</D></RSAKeyValue>");


            RSAParameters result = rsa_Y.ExportParameters(true); 



            Console.WriteLine("---------- 私钥信息 ----------");
            PrintRSAParameters(result);

            return result;
        }





    }
}
