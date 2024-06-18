using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPS.Service;

namespace WPS.Controllers
{
    public class HomeController : Controller
    {
       private readonly HomeService homeService;
        public HomeController()
        {
            homeService = new HomeService();
        }
        public ActionResult Index(int? currentPage = 1, string code = null)
        {
            int page = currentPage ?? 1;
            var data = homeService.GetViewHome(page, code);
            data.code = code;
            return View(data);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Evented(int? currentPage = 1 , string code = null)
        {
            int page = currentPage ?? 1;
            var data = homeService.GetViewEvent(page, code);
            data.code = code;
            return View(data);
        }

        public ActionResult ListPost(int? currentPage = 1, string code = null)
        {
            int page = currentPage ?? 1;
            var data = homeService.GetViewPostList(page, code);
            data.code = code;
            return View(data);
        }

        public ActionResult Details(string code = null)
        {
            var data = homeService.GetViewPostDetail(code);
            return View(data);
        }
    }
}