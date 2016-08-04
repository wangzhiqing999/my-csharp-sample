using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;



namespace C0010_SecretKeyEncryption.Sample
{
    class DESCryptoServiceProviderExample : CommonService
    {

        protected override string GetServiceName()
        {
            return "数据加密标准 (DES)算法";
        }

        protected override SymmetricAlgorithm GetService()
        {
            return new DESCryptoServiceProvider();
        }


    }
}
