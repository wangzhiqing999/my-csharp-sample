using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C0010_SecretKeyEncryption.Util
{

    /// <summary>
    /// 用于输出  byte 数组中的相关信息.
    /// </summary>
    public class ByteArrayOutput
    {


        public static void Print(byte[] byteArray)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("00  01  02  03  04  05  06  07  08  09  0A  0B  0C  0D  0E  0F");
            Console.Write("--------------------------------------------------------------");
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i % 16 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0:X2}  ", byteArray[i]);
                
            }
            Console.WriteLine();
            Console.WriteLine();
        }





        public static string Hexdigest(byte[] byteArray)
        {
            StringBuilder buff = new StringBuilder();

            for (int i = 0; i < byteArray.Length; i++)
            {
                buff.AppendFormat("{0:x2}", byteArray[i]);
            }

            return buff.ToString();
        }








        public static string BytesToHexString(byte[] input)
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



    }


}
