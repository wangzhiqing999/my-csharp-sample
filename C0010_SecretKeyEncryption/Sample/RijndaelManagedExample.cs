using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;



namespace C0010_SecretKeyEncryption.Sample
{
    class RijndaelManagedExample : CommonService
    {

        protected override string GetServiceName()
        {
            return " Rijndael 算法的托管版本";
        }

        protected override SymmetricAlgorithm GetService()
        {
            return new RijndaelManaged();
        }
    }
}
