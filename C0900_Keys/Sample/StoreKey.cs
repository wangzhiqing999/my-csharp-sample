using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Security.Cryptography;



namespace C0900_Keys.Sample
{


    /// <summary>
    /// 将非对称密钥存储在密钥容器中的例子
    /// </summary>
    public class StoreKey
    {

        public static void DoTest()
        {

            Console.WriteLine("##### 将非对称密钥存储在密钥容器中的例子!");

            try
            {
                // 创建非对称密钥并将其保存在密钥容器中.
                GenKey_SaveInContainer("MyKeyContainer");

                // 从密钥容器中查询密钥.
                GetKeyFromContainer("MyKeyContainer");

                // 从密钥容器中删除密钥.
                DeleteKeyFromContainer("MyKeyContainer");




                // 创建非对称密钥并将其保存在密钥容器中.
                GenKey_SaveInContainer("MyKeyContainer");

                // 从密钥容器中删除密钥.
                DeleteKeyFromContainer("MyKeyContainer");
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

        }


        /// <summary>
        /// 生成一个密钥, 然后存储到容器中.
        /// </summary>
        /// <param name="ContainerName"> 密钥容器名称 </param>
        public static void GenKey_SaveInContainer(string ContainerName)
        {
            // 创建 CspParameters 类的一个新实例，并将您想让密钥容器使用的名称传递给 CspParameters.KeyContainerName 字段。
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // 为从 AsymmetricAlgorithm 类派生的一个类
            // （通常是 RSACryptoServiceProvider 或 DSACryptoServiceProvider）创建一个新实例，
            // 并将先前创建的 CspParameters 对象传递给其构造函数。
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // 输出.
            Console.WriteLine("已添加到容器中的密钥： \n  {0}", rsa.ToXmlString(true));
        }


        /// <summary>
        /// 从容器中获取密钥.
        /// </summary>
        /// <param name="ContainerName"> 密钥容器名称 </param>
        public static void GetKeyFromContainer(string ContainerName)
        {
            // 创建 CspParameters 类的一个新实例，并将您想让密钥容器使用的名称传递给 CspParameters.KeyContainerName 字段。
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // 为从 AsymmetricAlgorithm 类派生的一个类
            // （通常是 RSACryptoServiceProvider 或 DSACryptoServiceProvider）创建一个新实例，
            // 并将先前创建的 CspParameters 对象传递给其构造函数。
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // 输出.
            Console.WriteLine("从容器中检索到的密钥： \n {0}", rsa.ToXmlString(true));
        }


        /// <summary>
        /// 从容器中删除 密钥
        /// </summary>
        /// <param name="ContainerName"> 密钥容器名称 </param>
        public static void DeleteKeyFromContainer(string ContainerName)
        {
            // 创建 CspParameters 类的一个新实例，并将您想让密钥容器使用的名称传递给 CspParameters.KeyContainerName 字段。
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // 为从 AsymmetricAlgorithm 类派生的一个类
            // （通常是 RSACryptoServiceProvider 或 DSACryptoServiceProvider）创建一个新实例，
            // 并将先前创建的 CspParameters 对象传递给其构造函数。
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // 将从 AsymmetricAlgorithm 中派生的类的 PersistKeyInCSP 属性设置为 false
            rsa.PersistKeyInCsp = false;

            // 调用从 AsymmetricAlgorithm 派生的类的 Clear 方法。 该方法释放该类所有的资源并清除密钥容器。
            rsa.Clear();

            // 输出.
            Console.WriteLine("密钥已删除.");
        }


    }


}
