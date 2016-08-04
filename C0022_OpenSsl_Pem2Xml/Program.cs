using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Runtime.InteropServices;




namespace C0022_OpenSsl_Pem2Xml
{


    /// <summary>
    /// Openssl 生成的RSA秘钥被C#使用解密
    /// 
    /// 来源页面：
    /// http://blog.csdn.net/jiayanhui2877/article/details/47154747
    /// </summary>
    class Program
    {




        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: C0022_OpenSsl_Pem2Xml.exe  pemFileName  xmlFileName");
                Console.ReadKey();
                return;
            }


            // OpenSsl 私钥文件.
            string pemFileName = args[0];

            // Xml 文件.
            string xmlFileName = args[1];


            if (!File.Exists(pemFileName))
            {
                Console.WriteLine("{0} File Not Found ！", pemFileName);
                Console.ReadKey();
                return;
            }

            // 读取 秘钥源文本.
            string priKey = File.ReadAllText(pemFileName);

            // 干掉头部和尾部的无用字符
            priKey = priKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "")
                .Replace("-----END RSA PRIVATE KEY-----", "");

            
            RSACryptoServiceProvider rsaProvider = DecodeRSAPrivateKey(priKey);
            String PrivateKey = rsaProvider.ToXmlString(true);

            // 导出结果文件.
            File.WriteAllText(xmlFileName, PrivateKey);


            Console.WriteLine("Finish!");
            Console.ReadKey();
            return;
        }





        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)        //expect integer
                return 0;
            bt = binr.ReadByte();


            if (bt == 0x81)
                count = binr.ReadByte();    // data size in next byte
            else
                if (bt == 0x82)
                {
                    highbyte = binr.ReadByte();    // data size in next 2 bytes
                    lowbyte = binr.ReadByte();
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    count = BitConverter.ToInt32(modint, 0);
                }
                else
                {
                    count = bt;        // we already have the data size
                }


            while (binr.ReadByte() == 0x00)
            {    //remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);        //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }



        public static RSACryptoServiceProvider DecodeRSAPrivateKey(string priKey)
        {
            var privkey = Convert.FromBase64String(priKey);
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;


            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();        //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();       //advance 2 bytes
                else
                    return null;


                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;




                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);


                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);


                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);




                return RSA;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

    }
}
