using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography.X509Certificates;
using System.Net;

using MyWCFService.DataContract;
using MyWCFService.ServiceContract;


namespace MyWCFService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PermissionCertificatePolicy.Enact("CN=HTTPS-Server"); 


            CallWcfService("BasicHttpBinding_ICalculator");



            Console.WriteLine("按回车键结束！");


            Console.ReadLine();
        }



        /// <summary>
        /// 测试调用 WCF 服务.
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        private static void CallWcfService(string endpointConfigurationName)
        {
            using (CalculatorClient service = new CalculatorClient(endpointConfigurationName))
            {

                Console.WriteLine("调用 WCF 服务 ( {0} )  开始！", endpointConfigurationName);

                Console.WriteLine("service.Add(1, 2) = {0}", service.Add(1, 2));
                Console.WriteLine("service.Sub(2, 3) = {0}", service.Sub(2, 3));
                Console.WriteLine("service.Mul(3, 4) = {0}", service.Mul(3, 4));

                DivResult divResult = service.Div(5, 2);
                Console.WriteLine("service.Div(5, 2) = {0} 余 {1} ", divResult.DivData, divResult.ModData);

                Console.WriteLine("调用 WCF 服务 ( {0} )  结束！", endpointConfigurationName);

                Console.WriteLine();
            }
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
