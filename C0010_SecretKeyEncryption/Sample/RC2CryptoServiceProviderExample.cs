using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;


namespace C0010_SecretKeyEncryption.Sample
{

    class RC2CryptoServiceProviderExample : CommonService
    {

        protected override string GetServiceName()
        {
            return "RC2 算法";
        }

        protected override SymmetricAlgorithm GetService()
        {
            return new RC2CryptoServiceProvider();
        }
    }
}
