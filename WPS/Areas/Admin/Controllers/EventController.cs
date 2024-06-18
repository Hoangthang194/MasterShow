using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WPS.Core;
using WPS.Service;

namespace WPS.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _service;
        public EventController()
        {
            _service = new EventService();
        }
        // GET: Admin/Event
        public ActionResult Index()
        {
            _service.GetAll();
            _service.ObjDetail.Date = DateTime.Now;
            return View(_service);
        }

        public ActionResult Search(EventService service)
        {
            _service.ObjList = _service.Search(service);
            return View("Index", _service);
        }
        public ActionResult Create()
        {
            _service.GetAll();
            var data = _service.GetCategories();
            var post = _service.GetPost();
            ViewBag.Data = data;
            ViewBag.Post = post;    
            return View(_service);
        }
        [HttpPost]
        public ActionResult Create(EventService service, string Category, string Id_post, HttpPostedFileBase file)
        {
            service.ObjDetail.Id = Guid.NewGuid().ToString();
            service.ObjDetail.Date = DateTime.Now;
            service.ObjDetail.Category_Id = Category;
            service.ObjDetail.Id_Post = Id_post;
            var ImageService = new ImageProductService();
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                var FilePath = "~/Uploads/" + fileName;
                if (System.IO.File.Exists(path))
                {
                    service.ObjDetail.Id_Image = FilePath;
                }
                else
                {
                    file.SaveAs(path);
                    service.ObjDetail.Id_Image = FilePath;
                }
            }

            service.Create();
            if (service.State)
            {
                ViewBag.Error = false;
                return RedirectToAction("Index", new { check = 1 });
            }
            else
            {
                ViewBag.Error = "Lỗi thêm mới";
                return RedirectToAction("Index", new { check = 0 });
            }
        }

        public ActionResult Update(string id)
        {
            _service.ObjDetail.Id = id;
            var obj = _service.GetById(id);
            _service.ObjDetail = obj;
            var data = _service.GetCategories();
            var post = _service.GetPost();
            ViewBag.Post = post;
            ViewBag.Data = data;
            return View(_service);
        }

        [HttpPost]
        public ActionResult Update(EventService service, string Category, string Id_post)
        {
            try
            {
                service.ObjDetail.Category_Id = Category;
                service.ObjDetail.Id_Post = Id_post;
                service.ObjDetail.Date = DateTime.Now;
                service.Update();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return RedirectToAction("Index", new { check = 1 });
                }
                else
                {
                    ViewBag.Error = "Lỗi cập nhật";
                    return RedirectToAction("Index", new { check = 0 });
                }
            }
            catch
            {
                return RedirectToAction("Index", new { check = 0 });
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                _service.Delete(id);
                if (_service.State)
                {
                    ViewBag.Error = false;
                    return RedirectToAction("Index", new { check = 1 });
                }
                else
                {
                    ViewBag.Error = "Lỗi xóa";
                    return RedirectToAction("Index", new { check = 0 });
                }
            }
            catch
            {
                return RedirectToAction("Index", new { check = 0 });
            }
        }
    }
}