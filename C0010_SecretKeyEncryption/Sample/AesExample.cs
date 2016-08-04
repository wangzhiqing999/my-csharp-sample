using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;




namespace C0010_SecretKeyEncryption.Sample
{
    class AesExample : CommonService
    {

        protected override string GetServiceName()
        {
            return "高级加密标准 (AES) 对称算法";
        }

        protected override SymmetricAlgorithm GetService()
        {
            return new AesManaged();
        }
    }
}
