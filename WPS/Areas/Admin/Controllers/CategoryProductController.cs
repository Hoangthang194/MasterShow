using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPS.Service;

namespace WPS.Areas.Admin.Controllers
{
    public class CategoryProductController : Controller
    {
        private readonly CategoryProductService _service;
        public CategoryProductController()
        {
            _service = new CategoryProductService();
        }


        // GET: Admin/CategoryProduct
        public ActionResult Create()
        {
            _service.GetAll();
            return View(_service);
        }

        [HttpPost]
        public ActionResult Create(CategoryProductService service)
        {
            try
            {
                service.ObjDetail.Id = Guid.NewGuid().ToString();
                service.ObjDetail.Type = service.ObjDetail.Type;
                service.Create();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return RedirectToAction("Create", new { check = 1 });
                }
                else
                {
                    ViewBag.Error = "Lỗi thêm mới";
                    return RedirectToAction("Create", new { check = 0 });
                }
            }
            catch
            {
                return RedirectToAction("Create", new { check = 0 });
            }
        }
        public ActionResult Update(string id)
        {
            var Obj = _service.GetById(id);
            _service.ObjDetail = Obj;
            _service.GetAll();
            return View(_service);
        }

        [HttpPost]
        public ActionResult Update(CategoryProductService service)
        {
            try
            {
                service.Update();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return RedirectToAction("Create", new { check = 1 });
                }
                else
                {
                    ViewBag.Error = "Lỗi cập nhật";
                    return RedirectToAction("Create", new { check = 0 });
                }
            }
            catch
            {
                return RedirectToAction("Create", new { check = 0 });
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
                    return RedirectToAction("Create", new { check = 1 });
                }
                else
                {
                    ViewBag.Error = "Lỗi xóa";
                    return RedirectToAction("Create", new { check = 0 });
                }
            }
            catch
            {
                return RedirectToAction("Create", new { check = 0 });
            }
        }

    }
}