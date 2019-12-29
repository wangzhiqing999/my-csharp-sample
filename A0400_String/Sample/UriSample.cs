using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0401_String.Sample
{
    public class UriSample
    {


        /// <summary>
        /// 一个 URI 的基本属性.
        /// </summary>
        public void ShowBasicProp(string url)
        {
            Uri uri = new Uri(url);

            Console.WriteLine("--- {0} ---", url);

            Console.WriteLine("AbsolutePath: {0}", uri.AbsolutePath);
            Console.WriteLine("AbsoluteUri: {0}", uri.AbsoluteUri);
            Console.WriteLine("Authority: {0}", uri.Authority);
            
            Console.WriteLine("DnsSafeHost: {0}", uri.DnsSafeHost);
            Console.WriteLine("Fragment: {0}", uri.Fragment);
            Console.WriteLine("Host: {0}", uri.Host);

            Console.WriteLine("HostNameType: {0}", uri.HostNameType);
            Console.WriteLine("LocalPath: {0}", uri.LocalPath);
            Console.WriteLine("OriginalString: {0}", uri.OriginalString);

            Console.WriteLine("PathAndQuery: {0}", uri.PathAndQuery);
            Console.WriteLine("Port: {0}", uri.Port);
            Console.WriteLine("Query: {0}", uri.Query);

            Console.WriteLine("Scheme: {0}", uri.Scheme);
            Console.WriteLine("Segments: {0}", uri.Segments);
            Console.WriteLine("UserInfo: {0}", uri.UserInfo);
        }




    }
}
