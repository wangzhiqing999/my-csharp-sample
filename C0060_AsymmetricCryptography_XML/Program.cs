using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;



namespace C0060_AsymmetricCryptography_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建 XML 对象.
            XmlDocument xmlDoc = new XmlDocument();

            // 加载 XML 文档
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("test.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // 创建 CspParameters 类的一个新实例，
            // 并将您想让密钥容器使用的名称传递给 CspParameters.KeyContainerName 字段。
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";


            // 为从 AsymmetricAlgorithm 类派生的一个类
            // （通常是 RSACryptoServiceProvider 或 DSACryptoServiceProvider）创建一个新实例，
            // 并将先前创建的 CspParameters 对象传递给其构造函数。
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);


            // 输出密钥.
            Console.WriteLine("容器中的密钥： \n  {0}", rsaKey.ToXmlString(true));



            try
            {
                //  加密 XML 文件中的 "creditcard" 元素.
                Encrypt(xmlDoc, "creditcard", "EncryptedElement1", rsaKey, "rsaKey");

                // 保存 XML 文件.
                xmlDoc.Save("test.xml");

                // 显示 XML 文件中的数据.
                Console.WriteLine("加密后的 XML:");
                Console.WriteLine();
                Console.WriteLine(xmlDoc.OuterXml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Clear the RSA key.
                rsaKey.Clear();
            }






            // 加载 XML 文档
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("test.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            rsaKey = new RSACryptoServiceProvider(cspParams);

            try
            {

                // 解密 XML 文件.
                Decrypt(xmlDoc, rsaKey, "rsaKey");


                // Save the XML document.
                xmlDoc.Save("test.xml");


                // 显示 XML 文件中的数据.
                Console.WriteLine();
                Console.WriteLine("解密后的 XML:");
                Console.WriteLine();
                Console.WriteLine(xmlDoc.OuterXml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Clear the RSA key.
                rsaKey.Clear();
            }








            Console.ReadLine();
        }



        /// <summary>
        /// 加密 XML 文件
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="ElementToEncrypt"></param>
        /// <param name="EncryptionElementID"></param>
        /// <param name="Alg"></param>
        /// <param name="KeyName"></param>
        public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, RSA Alg, string KeyName)
        {
            // Check the arguments.
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (EncryptionElementID == null)
                throw new ArgumentNullException("EncryptionElementID");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElemnt object.
            ////////////////////////////////////////////////
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }
            RijndaelManaged sessionKey = null;

            try
            {
                //////////////////////////////////////////////////
                // Create a new instance of the EncryptedXml class
                // and use it to encrypt the XmlElement with the
                // a new random symmetric key.
                //////////////////////////////////////////////////

                // Create a 256 bit Rijndael key.
                sessionKey = new RijndaelManaged();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();

                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
                ////////////////////////////////////////////////
                // Construct an EncryptedData object and populate
                // it with the desired encryption information.
                ////////////////////////////////////////////////

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.Id = EncryptionElementID;
                // Create an EncryptionMethod element so that the
                // receiver knows which algorithm to use for decryption.

                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
                // Encrypt the session key and add it to an EncryptedKey element.
                EncryptedKey ek = new EncryptedKey();

                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

                ek.CipherData = new CipherData(encryptedKey);

                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                // Create a new DataReference element
                // for the KeyInfo element.  This optional
                // element specifies which EncryptedData
                // uses this key.  An XML document can have
                // multiple EncryptedData elements that use
                // different keys.
                DataReference dRef = new DataReference();

                // Specify the EncryptedData URI.
                dRef.Uri = "#" + EncryptionElementID;

                // Add the DataReference to the EncryptedKey.
                ek.AddReference(dRef);
                // Add the encrypted key to the
                // EncryptedData object.

                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
                // Set the KeyInfo element to specify the
                // name of the RSA key.

                // Create a new KeyInfo element.
                edElement.KeyInfo = new KeyInfo();

                // Create a new KeyInfoName element.
                KeyInfoName kin = new KeyInfoName();

                // Specify a name for the key.
                kin.Value = KeyName;

                // Add the KeyInfoName element to the
                // EncryptedKey object.
                ek.KeyInfo.AddClause(kin);


                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

                // Add the encrypted element data to the
                // EncryptedData object.
                edElement.CipherData.CipherValue = encryptedElement;
                ////////////////////////////////////////////////////
                // Replace the element from the original XmlDocument
                // object with the EncryptedData element.
                ////////////////////////////////////////////////////
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            catch (Exception e)
            {
                // re-throw the exception.
                throw e;
            }
            finally
            {
                if (sessionKey != null)
                {
                    sessionKey.Clear();
                }
            }
        }







        /// <summary>
        /// 解密 XML 文件
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Alg"></param>
        /// <param name="KeyName"></param>
        public static void Decrypt(XmlDocument Doc, RSA Alg, string KeyName)
        {
            // Check the arguments.
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml(Doc);

            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping(KeyName, Alg);

            // Decrypt the element.
            exml.DecryptDocument();

        }



    }
}
