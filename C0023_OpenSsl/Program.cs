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

            Test2();
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

    }
}
