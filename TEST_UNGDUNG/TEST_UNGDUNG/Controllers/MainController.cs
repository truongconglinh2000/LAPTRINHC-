using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
namespace TEST_UNGDUNG.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProductDAO().ListAll();
            return View(model);
        }

    }
}