using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using W1050_Mvc5.Common;
using W1050_Mvc5.Models;


namespace W1050_Mvc5.Controllers
{
    public class TestAuthenticationController : Controller
    {


        protected IAuthenticationProcesser _AuthenticationProcesser;



        public TestAuthenticationController()
        {
            this._AuthenticationProcesser = new DefaultAuthenticationProcesser();
        }

        // GET: TestAuthentication
        public ActionResult Index()
        {
            CommonServiceResult<string> result = this._AuthenticationProcesser.IsLogin(this);
            return View(model: result);

        }

        public ActionResult Login(string userName)
        {
            this._AuthenticationProcesser.Login(this, userName);
            return RedirectToAction("Index");
        }

        public ActionResult Logoff()
        {
            this._AuthenticationProcesser.Logoff(this);
            return RedirectToAction("Index");
        }


    }
}