using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Security.Cryptography;


namespace C0023_OpenSsl
{


    /// <summary>
    /// http://www.cnblogs.com/mangohappy/archive/2016/04/08/5368012.html
    /// 
    /// 通过简单引用 System.Extended Nuget 包
    /// 直接使用 RSACryptoServiceProvider，会发现多出几个扩展方法
    /// 
    /// 
    /// 导出的文件：
    /// 
    /// X509 公钥  -----BEGIN PUBLIC KEY-----
    /// 非加密 PKCS#8 私钥  -----BEGIN PRIVATE KEY-----
    /// PKCS#1 私钥  -----BEGIN RSA PRIVATE KEY-----
    /// </summary>
    class Program
    {

        
        static void Main(string[] args)
        {

            Test3();
            Test4();
            Console.ReadKey();

        }




        static void Test1()
        {

            var private_key = @"MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAJGHu8qruvoSFKD3
            LqIPfxXLTzO6YQleE1MgZ7y9GN2kTXXw27Vw9FnQBT0VswjHxydC2AKoaBbcM8Mu
            PhWaWZ2cnw9wUcEFaCHzk/WGJy/wFDScsuOp7NoFxL0SY7ULvOF041Wu8wXIdzWP
            vp74W/5d8LoJG/Ap+pf6Pk4yZa2jAgMBAAECgYBxgvu5M4Xd9Che/S5Efe3UZAZd
            BK0Xj2dnWUlQ7/XrO3Kn4bydo4MUYqsTYE+LM7hlKUAvooe9/Pfq77DBTOlETcSJ
            fvZdL+mX5b3v8hnknWdpiyhfB2yaYbNTOUWMHboekwtqjP5C5yA5IObGcDFFPVZA
            /tRa50XNq3PATS1jIQJBAPi7U+zhFG/QKI4IlUYymwKlsa7ZMHJjXX8508ZxD0az
            YDfFsZEWquAdPPXj9lVlXD7uMBzewAx/gn2wTBLtr1sCQQCVyGRyTarXFaqdImEe
            +7/o6hCIdVvCBUuyIkd0WUPTkbizpUpUrzu9oy1UbvWlI2r4QqjoMh8eq05zlU+s
            J9VZAkEA6mDCzZSuiEoy3NvzpYksDguKagNYpoFBahBYoUaKKYn/Ya6VCu28KKEE
            f4PG7GMt0FLr3Vh8yYohsUQ9+xwjvwJAGDB8yFjytjmxjB75QF+35o2mjeMmJndk
            eig/EfM4mPp3scuH7ZU/OKkZsQEaesj1hZJ+ZMFzdSiFSvVaIJtuQQJAH3sXQ3DV
            EoeSW40TyYviq2K1pEpz9fGcS1TrjI+Yt1Mf0mvO6eupNZCfuhiAqJ5ZGRzTv1Pu
            G7pgz+ey5sWBcA==";

            var public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCRh7vKq7r6EhSg9y6iD38Vy08z
           umEJXhNTIGe8vRjdpE118Nu1cPRZ0AU9FbMIx8cnQtgCqGgW3DPDLj4VmlmdnJ8P
           cFHBBWgh85P1hicv8BQ0nLLjqezaBcS9EmO1C7zhdONVrvMFyHc1j76e+Fv+XfC6
           CRvwKfqX+j5OMmWtowIDAQAB";

            var rsa = new RSACryptoServiceProvider();

            rsa.FromX509PublicKey(Convert.FromBase64String(public_key));

            var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes("mangohappy"), false);

            rsa.FromPKCS8PrivateKey(Convert.FromBase64String(private_key));

            Console.WriteLine(Encoding.UTF8.GetString(rsa.Decrypt(bytes, false)));


        }



        static void Test2()
        {
            string sourceTxt = File.ReadAllText("TestKey.txt");
            sourceTxt = sourceTxt.Replace("——BEGIN PRIVATE KEY——", "");
            sourceTxt = sourceTxt.Replace("——END PRIVATE KEY——", "");

            var rsa = new RSACryptoServiceProvider();
            rsa.FromPKCS8PrivateKey(Convert.FromBase64String(sourceTxt));


            Console.WriteLine(rsa.ToXmlString(true));
            File.WriteAllText("私钥.xml", rsa.ToXmlString(true));

            string test = "FLR+5Q9C97fLUatkXDGCF8sMKlfgrYZ2HwRDiJ8Eu8rk1Xhi4QpLd/Knz/+U9PqETaSy1ARAuji1q2+Nua1wBvZE79hCp1kTSmnAMoS08tbr0HXyNxoFHKattFGnKRAldEOxUD/vRv/od5Jxc77qsRpTS7PDLIsz+tXYU4ScfrM=";
            byte[] data = Convert.FromBase64String(test);

            byte[] result = rsa.Decrypt(data, false);
            Console.WriteLine(Encoding.UTF8.GetString(result));


        }




        static void Test3()
        {
            Console.WriteLine("-----Test3-----");

            string publicJavaKey, privateJavaKey, content, publicCSharpKey, privateCSharpKey, signData;

            //java的base64格式秘钥

            privateJavaKey = TestSHA1withRSA.privatestr;

            publicJavaKey = TestSHA1withRSA.publicstr;

            content = "1234567890,1234567890,1234567890,1234567890,1234567890";

            //转成C#的xml格式

            publicCSharpKey = RSAConverter.RSAPublicKeyJava2DotNet(publicJavaKey);

            privateCSharpKey = RSAConverter.RSAPrivateKeyJava2DotNet(privateJavaKey);

            Console.WriteLine("转换得到的C#公钥：" + publicCSharpKey);

            Console.WriteLine("转换得到的C#私钥：" + privateCSharpKey);



            //RSAHelper.Create(out publicCSharpKey, out privateCSharpKey, 1024);

            string encData = RSAHelper.Encrypt(publicCSharpKey, content);

            Console.WriteLine("公钥加密结果：" + encData);

            Console.WriteLine("私钥解密结果：" + RSAHelper.Decrypt(privateCSharpKey, encData));

            //下面是java通过SHA1WithRSA生成的签名

            //Dv67xT5SgGQ9q+bKVWuyyxljx28cxNkIMDk5ro8cMopsiPf7Z8/n/02yaN/SVUQPmWJk/f+cjwydikVStwjkll49/D4PrTW+nd4XWr5hea8n7c6JTdRvaOGwFG3Do1n8Sndj7aqxuUWUmlLiC1dYEHeZhSwm9BCMJJSvF8n34CY=

            //下面是JAVA通过MD5withRSA生成的签名

            //MUXPVxxNZOlzDY03hOXQgQLQnJ/SrJa0lxQAx8Kl+H+pLBcL6cqdLupVwK6mwKZ1mRP2CCwGaQC8wHkOVRafPdkOSRsnKnkAjRv1iqHBxJtPCG83XlrB7AofzqHi/VULCA9KdWqmvnarVCV+lVwwUVCXP5cK1nwEJN258T/eV8M=

            //下面是JAVA通过SHA256WithRSA生成的签名

            //qPfkIAITcKW452/NacSQHjNbBUtJNhel4SpTMp1T/nGaY0Z4I3Xx13/aVl001ZKwBfdFf7cIPAKlbqmywm3sqEzVpBQlVOYMZBARlHAoOexTCZk50tgrCFUlXXa2pWt+jRS2lGUX5esbo6cKS0Yk1fdkYlm+4S4NRKYgEAXO+lY=

            string halg = "SHA1";//SHA1 MD5 SHA256

            signData = RSAHelper.SignData(privateCSharpKey, content, halg);//SHA1

            Console.WriteLine("生成签名：" + signData);



            byte[] signArray = Convert.FromBase64String(signData);
            foreach (var x in signArray)
            {
                Console.Write("{0:X2}", x);
            }
            Console.WriteLine();

            Console.WriteLine("签名一致：" + RSAHelper.VerifyData(publicCSharpKey, content, signData, halg));




            halg = "SHA256";

            signData = RSAHelper.SignData(privateCSharpKey, content, halg);

            Console.WriteLine("### SHA256 ### 生成签名：" + signData);

            signArray = Convert.FromBase64String(signData);
            foreach (var x in signArray)
            {
                Console.Write("{0:X2}", x);
            }
            Console.WriteLine();
            Console.WriteLine("### SHA256 ### 签名一致：" + RSAHelper.VerifyData(publicCSharpKey, content, signData, halg));


            Console.WriteLine();
        }





        static void Test4() {

            Console.WriteLine("-----Test4-----");

            string publicJavaKey, privateJavaKey, content, signData;

            privateJavaKey = TestSHA1withRSA.privatestr;

            publicJavaKey = TestSHA1withRSA.publicstr;

            content = "1234567890,1234567890,1234567890,1234567890,1234567890";

            signData = TestSHA1withRSA.signWhole(privateJavaKey, content);
            Console.WriteLine("私钥生成签名结果 = {0}", signData);
            byte[] signArray = Convert.FromBase64String(signData);
            foreach (var x in signArray)
            {
                Console.Write("{0:X2}", x);
            }
            Console.WriteLine();



            Console.WriteLine("公钥验证签名结果：" + TestSHA1withRSA.verifyWhole(content, signData, publicJavaKey));

        }


    }
}
