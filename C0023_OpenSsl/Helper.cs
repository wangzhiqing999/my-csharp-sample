using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;




public class KeyGenerator
{

    /// <summary>

    /// 随机生成秘钥（对称算法）

    /// </summary>

    /// <param name="key">秘钥(base64格式)</param>

    /// <param name="iv">iv向量(base64格式)</param>

    /// <param name="keySize">要生成的KeySize，每8个byte是一个字节，注意每种算法支持的KeySize均有差异，实际可通过输出LegalKeySizes来得到支持的值</param>

    public static void CreateSymmetricAlgorithmKey<T>(out string key, out string iv, int keySize)

        where T : SymmetricAlgorithm, new()
    {

        using (T t = new T())
        {

#if DEBUG

            Console.WriteLine(string.Join("", t.LegalKeySizes.Select(k => string.Format("MinSize:{0} MaxSize:{1} SkipSize:{2}", k.MinSize, k.MaxSize, k.SkipSize))));

#endif

            t.KeySize = keySize;

            t.GenerateIV();

            t.GenerateKey();

            iv = Convert.ToBase64String(t.IV);

            key = Convert.ToBase64String(t.Key);

        }

    }

    /// <summary>

    /// 随机生成秘钥（非对称算法）

    /// </summary>

    /// <typeparam name="T"></typeparam>

    /// <param name="publicKey">公钥（Xml格式）</param>

    /// <param name="privateKey">私钥（Xml格式）</param>

    /// <param name="provider">用于生成秘钥的非对称算法实现类，因为非对称算法长度需要在构造函数传入，所以这里只能传递算法类</param>

    public static void CreateAsymmetricAlgorithmKey<T>(out string publicKey, out string privateKey, T provider = null)

        where T : AsymmetricAlgorithm, new()
    {

        if (provider == null)
        {

            provider = new T();

        }

        using (provider)
        {

#if DEBUG

            Console.WriteLine(string.Join("", provider.LegalKeySizes.Select(k => string.Format("MinSize:{0} MaxSize:{1} SkipSize:{2}", k.MinSize, k.MaxSize, k.SkipSize))));

#endif

            publicKey = provider.ToXmlString(false);

            privateKey = provider.ToXmlString(true);

        }

    }

}



public class AsymmetricAlgorithmHelper<T>

    where T : AsymmetricAlgorithm, new()
{

    protected static TResult Execute<TResult>(string key, Func<T, TResult> func)
    {

        using (T algorithm = new T())
        {

            algorithm.FromXmlString(key);

            return func(algorithm);

        }

    }

    /// <summary>

    /// 按默认规则生成公钥、私钥

    /// </summary>

    /// <param name="publicKey">公钥（Xml格式）</param>

    /// <param name="privateKey">私钥（Xml格式）</param>

    public static void Create(out string publicKey, out string privateKey)
    {

        KeyGenerator.CreateAsymmetricAlgorithmKey<T>(out publicKey, out privateKey);

    }

}

public class RSAHelper : AsymmetricAlgorithmHelper<RSACryptoServiceProvider>
{

    /// <summary>

    /// RSA加密

    /// </summary>

    /// <param name="publickey">公钥</param>

    /// <param name="content">加密前的原始数据</param>

    /// <param name="fOAEP">如果为 true，则使用 OAEP 填充（仅在运行 Microsoft Windows XP 或更高版本的计算机上可用）执行直接的 System.Security.Cryptography.RSA加密；否则，如果为 false，则使用 PKCS#1 1.5 版填充。</param>

    /// <returns>加密后的结果（base64格式）</returns>

    public static string Encrypt(string publickey, string content, bool fOAEP = false)
    {

        return Execute(publickey,

            algorithm => Convert.ToBase64String(algorithm.Encrypt(Encoding.UTF8.GetBytes(content), fOAEP)));

    }

    /// <summary>

    /// RSA解密

    /// </summary>

    /// <param name="privatekey">私钥</param>

    /// <param name="content">加密后的内容(base64格式)</param>

    /// <param name="fOAEP">如果为 true，则使用 OAEP 填充（仅在运行 Microsoft Windows XP 或更高版本的计算机上可用）执行直接的 System.Security.Cryptography.RSA加密；否则，如果为 false，则使用 PKCS#1 1.5 版填充。</param>

    /// <returns></returns>

    public static string Decrypt(string privatekey, string content, bool fOAEP = false)
    {

        return Execute(privatekey,

            algorithm => Encoding.UTF8.GetString(algorithm.Decrypt(Convert.FromBase64String(content), fOAEP)));

    }

    /// <summary>

    /// RSA签名

    /// </summary>

    /// <param name="privatekey">私钥</param>

    /// <param name="content">需签名的原始数据(utf-8)</param>

    /// <param name="halg">签名采用的算法，如果传null，则采用MD5算法</param>

    /// <returns>签名后的值(base64格式)</returns>

    public static string SignData(string privatekey, string content, object halg = null)
    {

        return Execute(privatekey,

            algorithm => Convert.ToBase64String(algorithm.SignData(Encoding.UTF8.GetBytes(content), GetHalg(halg))));

    }

    /// <summary>

    /// RSA验签

    /// </summary>

    /// <param name="publicKey">公钥</param>

    /// <param name="content">需验证签名的数据(utf-8)</param>

    /// <param name="signature">需验证的签名字符串(base64格式)</param>

    /// <param name="halg">签名采用的算法，如果传null，则采用MD5算法</param>

    /// <returns></returns>

    public static bool VerifyData(string publicKey, string content, string signature, object halg = null)
    {

        return Execute(publicKey,

            algorithm => algorithm.VerifyData(Encoding.UTF8.GetBytes(content), GetHalg(halg), Convert.FromBase64String(signature)));

    }

    private static object GetHalg(object halg)
    {

        if (halg == null)
        {

            halg = "MD5";

        }

        return halg;

    }

    /// <summary>

    /// 生成公钥、私钥

    /// </summary>

    /// <param name="publicKey">公钥（Xml格式）</param>

    /// <param name="privateKey">私钥（Xml格式）</param>

    /// <param name="keySize">要生成的KeySize，支持的MinSize:384 MaxSize:16384 SkipSize:8</param>

    public static void Create(out string publicKey, out string privateKey, int keySize = 1024)
    {

        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(keySize);

        KeyGenerator.CreateAsymmetricAlgorithmKey(out publicKey, out privateKey, provider);

    }

}

public class DSAHelper : AsymmetricAlgorithmHelper<DSACryptoServiceProvider>
{

    /// <summary>

    /// DSA签名

    /// </summary>

    /// <param name="privatekey">私钥</param>

    /// <param name="content">需签名的原始数据(utf-8)</param>

    /// <returns>签名后的值(base64格式)</returns>

    public static string SignData(string privatekey, string content)
    {

        return Execute(privatekey,

            algorithm => Convert.ToBase64String(algorithm.SignData(Encoding.UTF8.GetBytes(content))));

    }

    /// <summary>

    /// DSA验签

    /// </summary>

    /// <param name="publicKey">公钥</param>

    /// <param name="content">需验证签名的数据(utf-8)</param>

    /// <param name="signature">需验证的签名字符串(base64格式)</param>

    /// <returns></returns>

    public static bool VerifyData(string publicKey, string content, string signature)
    {

        return Execute(publicKey,

            algorithm => algorithm.VerifyData(Encoding.UTF8.GetBytes(content), Convert.FromBase64String(signature)));

    }

    /// <summary>

    /// 生成公钥、私钥

    /// </summary>

    /// <param name="publicKey">公钥（Xml格式）</param>

    /// <param name="privateKey">私钥（Xml格式）</param>

    /// <param name="keySize">要生成的KeySize，支持的MinSize:512 MaxSize:1024 SkipSize:64</param>

    public static void Create(out string publicKey, out string privateKey, int keySize = 1024)
    {

        DSACryptoServiceProvider provider = new DSACryptoServiceProvider(keySize);

        KeyGenerator.CreateAsymmetricAlgorithmKey(out publicKey, out privateKey, provider);

    }

}
