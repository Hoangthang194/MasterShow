using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Models;

namespace WPS.Service
{
    public class HomeService
    {
        private readonly CategoryProductService categoryProductService;
        private readonly CategoryService categoryService;
        private readonly EventService eventService;
        private readonly PostService postService;
        public HomeService()
        {
            categoryProductService = new CategoryProductService();
            categoryService = new CategoryService();
            eventService = new EventService();
            postService = new PostService();
        }

        public ViewHomeModelcs GetViewHome(int currentPage, string code)
        {
            var data = new ViewHomeModelcs();
            data.currentPage = currentPage;
            var lstCatePro = categoryProductService.GetAllCatePro();
            data.CategoryProducts = lstCatePro;
            var paging = new ModelPaging();
            paging.currentPage = currentPage;
            var lstEvent = eventService.GetAllEvent(paging, code);
            data.Events = lstEvent;

            var lstPost = postService.GetPostsHome(paging, null);
            data.Posts = lstPost;
            return data;
        }

        public ViewEventModel GetViewEvent(int currentPage, string code)
        {
            var data = new ViewEventModel();
            var paging = new ModelPaging();
            var lstCatePro = categoryProductService.GetAllCatePro();
            data.CategoryProducts = lstCatePro;
            paging.currentPage = currentPage;
            var lstEvent = eventService.GetAllEvent(paging, code);
            data.Events = lstEvent;
            data.numberPage = paging.totalCount;
            return data;
        }

        public ViewDetailModel GetViewPostDetail(string code)
        {
            var Obj = postService.GetById(code);
            var lstPost = postService.GetPosts();
            var data = new ViewDetailModel();
            data.Post = Obj;
            data.lstPost = lstPost;
            return data;
        }

        public ViewPostModel GetViewPostList(int currentPage, string code)
        {
            var lstCate = categoryService.GetAllCate();
            var paging = new ModelPaging();
            paging.currentPage = currentPage;
            var data = new ViewPostModel();
            data.Categories = lstCate;
            var lstPost = postService.GetPostsHome(paging, code);
            data.Posts = lstPost;
            data.numberPage = paging.totalCount;
            return data;
        }
    }
}