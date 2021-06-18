using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_UNGDUNG.Areas.Admin.Model;
using ModelEF.DAO;
using ModelEF;
namespace TEST_UNGDUNG.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginn)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var rs = user.login(loginn.username, loginn.password);
                if (rs == 1)
                {
                    Session.Add(Constants.USER_SESSION, loginn);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}