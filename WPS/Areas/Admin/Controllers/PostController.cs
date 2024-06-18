using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPS.Core;
using WPS.Service;

namespace WPS.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _service;
        public PostController()
        {
            _service = new PostService();
        }
        // GET: Admin/Post
        public ActionResult Index()
        {
            _service.GetAll();
            return View(_service);
        }


        public ActionResult Search(PostService service)
        {
            _service.ObjList = _service.Search(service);
            return View("Index", _service);
        }

        public ActionResult Create()
        {
            _service.GetAll();
            var data = _service.GetCategories();
            ViewBag.Data = data;
            return View(_service);
        }

        [HttpPost]

        public ActionResult Create(PostService service, string Category, IEnumerable<HttpPostedFileBase> files)
        {
            service.ObjDetail.Id = Guid.NewGuid().ToString();
            service.ObjDetail.Month = service.ObjDetail.Date.Month;
            service.ObjDetail.Year = service.ObjDetail.Date.Year;
            service.ObjDetail.CategoryId = Category;

            var ImageService = new ImageService();
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    var FilePath = "~/Uploads/" + fileName;
                    if (System.IO.File.Exists(path))
                    {
                        var image = new Image
                        {
                            Id = Guid.NewGuid().ToString(),
                            Url = FilePath,
                            Id_Post = service.ObjDetail.Id
                        };
                        ImageService.ObjDetail = image;
                        ImageService.Create();
                    }
                    else
                    {
                        file.SaveAs(path);
                        var image = new Image
                        {
                            Id = Guid.NewGuid().ToString(),
                            Url = FilePath,
                            Id_Post = service.ObjDetail.Id
                        };
                        ImageService.ObjDetail = image;
                        ImageService.Create();
                    }
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
            ViewBag.Data = data;
            return View(_service);
        }

        [HttpPost]
        public ActionResult Update(PostService service, string Category)
        {
            try
            {
                service.ObjDetail.Month = service.ObjDetail.Date.Month;
                service.ObjDetail.Year = service.ObjDetail.Date.Year;
                service.ObjDetail.CategoryId = Category;
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