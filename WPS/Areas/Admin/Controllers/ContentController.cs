using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WPS.Core;
using WPS.Service;

namespace WPS.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentService _sevice;
        public ContentController()
        {
            _sevice = new ContentService();
        }
        // GET: Admin/Content
        public ActionResult Index(string id)
        {
            _sevice.ObjList = _sevice.GetByPost(id);
            _sevice.ObjDetail.Id_Post = id;
            return View(_sevice);
        }

        public ActionResult AddContent(string Id)
        {
            _sevice.ObjDetail.Id_Post = Id;
            return View(_sevice);
        }
        [HttpPost]
        public ActionResult AddContent(ContentService service)
        {
            service.ObjDetail.Id = Guid.NewGuid().ToString();
            service.Create();
            if (service.State)
            {
                ViewBag.Error = false;
                return RedirectToAction("Index", "Post", new { check = 1 });
            }
            else
            {
                ViewBag.Error = "Lỗi thêm mới";
                return RedirectToAction("Index", "Post", new { check = 0 });
            }
        }

        public ActionResult Delete (string id)
        {
            _sevice.Delete(id);
            if (_sevice.State)
            {
                ViewBag.Error = false;
                return RedirectToAction("Index", "Post", new { check = 1 });
            }
            else
            {
                ViewBag.Error = "Lỗi xóa";
                return RedirectToAction("Index", "Post", new { check = 0 });
            }
        }
    }
}