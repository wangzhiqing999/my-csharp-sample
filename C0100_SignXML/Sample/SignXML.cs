using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;


namespace C0100_SignXML.Sample
{
    class SignXML
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


                Console.WriteLine("初始 XML 文件");
                // 输出内容
                Console.WriteLine(xmlDoc.OuterXml);




                // 对 XML 文件做签名.
                SignXml(xmlDoc, rsaKey);


                Console.WriteLine("XML 文件签名处理完毕！");



                // 保存文件.
                xmlDoc.Save("test.xml");


                // 输出内容
                Console.WriteLine(xmlDoc.OuterXml);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }






        // 给一个 xml 文件做签名的处理.
        // This document cannot be verified unless the verifying 
        // code has the key with which it was signed.
        public static void SignXml(XmlDocument Doc, RSA Key)
        {
            // Check arguments.
            if (Doc == null)
                throw new ArgumentException("Doc");
            if (Key == null)
                throw new ArgumentException("Key");

            // 创建一个新的 SignedXml 对象，并将 XmlDocument 对象传递给它。
            SignedXml signedXml = new SignedXml(Doc);

            // 将签名 RSA 密钥添加到 SignedXml 对象。
            signedXml.SigningKey = Key;

            // 创建说明签名内容的 Reference 对象。 若要对整个文档进行签名，请将 Uri 属性设置为 ""。
            Reference reference = new Reference();
            reference.Uri = "";

            // 将 XmlDsigEnvelopedSignatureTransform 对象添加到 Reference 对象中。 
            // 变换使验证工具可以使用与签名工具所用的相同方式表示 XML 数据。 
            // XML 数据可以用不同方式表示，因此这一步对于验证来说至关重要。
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // 将 Reference 对象添加到 SignedXml 对象中。
            signedXml.AddReference(reference);

            // 通过调用 ComputeSignature 方法计算签名。
            signedXml.ComputeSignature();

            // 检索签名（一个 <Signature> 元素）的 XML 表示形式，并将它保存到一个新的 XmlElement 对象中。
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // 将元素追加到 XmlDocument 对象中。
            Doc.DocumentElement.AppendChild(Doc.ImportNode(xmlDigitalSignature, true));

        }

    }
}
