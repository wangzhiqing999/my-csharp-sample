using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using W0800_MVVM_Knockout.Models;
using W0800_MVVM_Knockout.DataAccess;



namespace W0800_MVVM_Knockout.Controllers
{

    public class HomeController : Controller
    {

        public const int PageSize = 5;



        public ActionResult Index()
        {
            return View();
        }





        public ActionResult GetContacts(string firstName, string lastName, string orderBy, int pageIndex = 1, bool isAsc = true)
        {
            using (TestContext context = new TestContext())
            {
                var query =
                    from data in context.Contacts
                    select data;

                if (!String.IsNullOrEmpty(firstName))
                {
                    query = query.Where(p => p.FirstName.Contains(firstName));
                }
                if (!String.IsNullOrEmpty(lastName))
                {
                    query = query.Where(p => p.LastName.Contains(lastName));
                }


                int count = query.Count();
                int totalPages = count / PageSize + (count % PageSize > 0 ? 1 : 0);

                if (orderBy == "FirstName")
                {
                    if (isAsc)
                    {
                        query = query.OrderBy(p => p.FirstName);
                    }
                    else
                    {
                        query = query.OrderByDescending(p => p.FirstName);
                    }
                }
                if (orderBy == "LastName")
                {
                    if (isAsc)
                    {
                        query = query.OrderBy(p => p.LastName);
                    }
                    else
                    {
                        query = query.OrderByDescending(p => p.LastName);
                    }
                }
                if (orderBy == "EmailAddress")
                {
                    if (isAsc)
                    {
                        query = query.OrderBy(p => p.EmailAddress);
                    }
                    else
                    {
                        query = query.OrderByDescending(p => p.EmailAddress);
                    }
                }
                if (orderBy == "PhoneNo")
                {
                    if (isAsc)
                    {
                        query = query.OrderBy(p => p.PhoneNo);
                    }
                    else
                    {
                        query = query.OrderByDescending(p => p.PhoneNo);
                    }
                }

                query = query.Skip((pageIndex - 1) * PageSize).Take(PageSize);
                return Json(new { Data = query.ToArray(), TotalPages = totalPages }, JsonRequestBehavior.AllowGet);
            }
        }





        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.OnSuccess = "viewModel.onDataAdded";
            return View("ContactPartial", new Contact { Id = Guid.NewGuid() });
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            using (TestContext context = new TestContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
            return Json(contact);
        }





        public ActionResult Update(Guid id)
        {
            Contact data = null;

            using (TestContext context = new TestContext())
            {
                data = context.Contacts.Find(id);
            }

            ViewBag.Action = "Update";
            ViewBag.OnSuccess = "viewModel.onDataUpdated";
            return View("ContactPartial", data);
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {

            using (TestContext context = new TestContext())
            {
                Contact oldContact = context.Contacts.Find(contact.Id);

                // 先从上下文中的旧实体获取跟踪
                DbEntityEntry entry = context.Entry(oldContact);

                // 把新值设置到旧实体上
                entry.CurrentValues.SetValues(contact);

                // 物理保存.
                context.SaveChanges();
            }
            return Json(contact);
        }




        public ActionResult Delete(Guid id)
        {
            using (TestContext context = new TestContext())
            {
                Contact oldContact = context.Contacts.Find(id);

                if (oldContact != null)
                {
                    // 删除数据.
                    context.Contacts.Remove(oldContact);
                }

                // 物理保存.
                context.SaveChanges();


                return Json(oldContact, JsonRequestBehavior.AllowGet);
            }           
        }


    }
}
