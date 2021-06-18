using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using TEST_UNGDUNG.Areas.Admin.Model;
namespace TEST_UNGDUNG.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var model = new ProductDAO().ListAll();
            return View(model);

        }
        public ActionResult Detail(int Id)
        {
            var model = new ProductDAO().ListWhere(Id);
            return View(model);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham product, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
               
                        string path = System.IO.Path.Combine(Server.MapPath("~/Asset/Admin/img"),
                                                   System.IO.Path.GetFileName(image1.FileName));
                        string path1 = System.IO.Path.Combine(Server.MapPath("~/Asset/User/images/shoe"),
                                              System.IO.Path.GetFileName(image1.FileName));
                        image1.SaveAs(path);
                        image1.SaveAs(path1);
                        var pr = new ProductDAO();
                        product.Image = image1.FileName;
                        if (pr.Insert(product) == true)
                        {
                            return RedirectToAction("Index", "Product");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thất bại");
                        }
            }
            SetViewBag(product.IDLoai);
            return View();
        }
        public void SetViewBag(int? selectedid = null)
        {
            var dao = new ProductTypeDAO();
            ViewBag.IDLoai = new SelectList(dao.ListAll(), "ID", "Name", selectedid);
        }
    }
}