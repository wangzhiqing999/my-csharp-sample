using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;




namespace C0100_SignXML.Sample
{
    class VerifyXML
    {




        public static void DoTest()
        {
            try
            {
                // 创建 CspParameters 类的一个新实例，
                // 并将您想让密钥容器使用的名称传递给 CspParameters.KeyContainerName 字段。
                CspParameters cspParams = new CspParameters();
                cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

                // 为从 AsymmetricAlgorithm 类派生的一个类
                // （通常是 RSACryptoServiceProvider 或 DSACryptoServiceProvider）创建一个新实例，
                // 并将先前创建的 CspParameters 对象传递给其构造函数。
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                // 创建 XML 对象.
                XmlDocument xmlDoc = new XmlDocument();

                // 加载 XML 文档
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("test.xml");




                // Verify the signature of the signed XML.
                Console.WriteLine("验证 XML 文档的数字签名...");
                bool result = VerifyXml(xmlDoc, rsaKey);

                // Display the results of the signature verification to 
                // the console.
                if (result)
                {
                    Console.WriteLine("XML 签名是有效的.");
                }
                else
                {
                    Console.WriteLine("XML 签名是无效的.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }







        /// <summary>
        /// 验证 XML 文档的数字签名
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static Boolean VerifyXml(XmlDocument Doc, RSA Key)
        {
            // Check arguments.
            if (Doc == null)
                throw new ArgumentException("Doc");
            if (Key == null)
                throw new ArgumentException("Key");

            // 创建一个新的 SignedXml 对象，并将 XmlDocument 对象传递给它。
            SignedXml signedXml = new SignedXml(Doc);

            // 找到 <signature> 元素，并创建新的 XmlNodeList 对象。
            XmlNodeList nodeList = Doc.GetElementsByTagName("Signature");

            // 如果没有签名，那么抛异常.
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }

            //  如果有多个签名，那么也抛异常.
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }

            // 将第一个 <signature> 元素的 XML 加载到 SignedXml 对象中。
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // 使用 CheckSignature 方法和 RSA 公钥检查签名。 此方法将返回指示成功或失败的布尔值。
            return signedXml.CheckSignature(Key);
        }
    }
}
