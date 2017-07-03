using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoNHibernate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ISession _S = MvcApplication.SF.GetCurrentSession();

            TestTable t1 = new TestTable();
            t1.Name = "aaaa";
            t1.Age = 12;
            t1.City = "bbb";
            _S.Save(t1);


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}