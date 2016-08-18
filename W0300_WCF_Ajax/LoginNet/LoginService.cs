using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.LoginNet
{
    public class LoginService
    {


        public static bool DoLogin(string userName, string password)
        {
            return (userName == "test" && password == "test");
        }


    }
}