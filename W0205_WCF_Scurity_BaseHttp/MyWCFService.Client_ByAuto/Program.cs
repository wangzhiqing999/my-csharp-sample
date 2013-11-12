using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography.X509Certificates;
using System.Net;


namespace MyWCFService.Client_ByAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            PermissionCertificatePolicy.Enact("CN=HTTPS-Server");


            using (ServiceReference1.CalculatorClient service = new ServiceReference1.CalculatorClient("BasicHttpBinding_ICalculator"))
            {
                service.ClientCredentials.UserName.UserName = "testwcf";
                service.ClientCredentials.UserName.Password = "testwcf12345";


                Console.WriteLine("调用 WCF 服务 ( {0} )  开始！", "BasicHttpBinding_ICalculator");

                Console.WriteLine("service.Add(1, 2) = {0}", service.Add(1, 2));
                Console.WriteLine("service.Sub(2, 3) = {0}", service.Sub(2, 3));
                Console.WriteLine("service.Mul(3, 4) = {0}", service.Mul(3, 4));

                ServiceReference1.DivResult divResult = service.Div(5, 2);
                Console.WriteLine("service.Div(5, 2) = {0} 余 {1} ", divResult.DivData, divResult.ModData);

                Console.WriteLine("调用 WCF 服务 ( {0} )  结束！", "BasicHttpBinding_ICalculator");

                Console.WriteLine();
            }


            Console.WriteLine("按回车键结束！");


            Console.ReadLine();
        }
    }





    class PermissionCertificatePolicy
    {
        string subjectName;
        static PermissionCertificatePolicy currentPolicy;

        PermissionCertificatePolicy(string subjectName)
        {
            this.subjectName = subjectName;
            ServicePointManager.ServerCertificateValidationCallback +=
            new System.Net.Security.RemoteCertificateValidationCallback(RemoveCertValidate);
        }

        public static void Enact(string subjectName)
        {
            currentPolicy = new PermissionCertificatePolicy(subjectName);
        }

        bool RemoveCertValidate(object sender, X509Certificate cert,
        X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            if (currentPolicy.subjectName == subjectName)
                return true;
            return false;
        }
    }



}
