using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;




namespace C0010_SecretKeyEncryption.Sample
{
    class TripleDESCryptoServiceProviderExample : CommonService
    {

        protected override string GetServiceName()
        {
            return "TripleDES 算法的加密服务提供程序 (CSP) 版本";
        }

        protected override SymmetricAlgorithm GetService()
        {
            return new TripleDESCryptoServiceProvider();
        }
    }


}
