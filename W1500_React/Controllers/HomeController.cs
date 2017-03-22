using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

using W1500_React.Models;


namespace W1500_React.Controllers
{
    public class HomeController : Controller
    {

        private static readonly IList<CommentModel> _comments;


        static HomeController()
        {

            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!    **Server-side-Data**"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment    **Server-side-Data**"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment    **Server-side-Data**"
                },
            };


        }





        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }







        /// <summary>
        /// 获取列表.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 新增.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }




    }
}
