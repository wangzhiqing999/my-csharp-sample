using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace W1052_MachineKey
{
    class Program
    {

        protected static string CreateKey(int len)
        {
            byte[] bytes = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(string.Format("{0:X2}", bytes[i]));
            }
            return sb.ToString();
        }




        static void Main(string[] args)
        {
            string validationKey = CreateKey(20);
            string decryptionKey = CreateKey(24);


            string result = $"<machineKey validationKey=\"{validationKey}\" decryptionKey=\"{ decryptionKey}\" decryption=\"3DES\" validation=\"SHA1\"/>";

            Console.WriteLine(result);

            Console.ReadLine();
        }



    }
}
