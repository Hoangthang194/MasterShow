using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Models;
using WPS.Repository.Implement;
using WPS.Service.Common;

namespace WPS.Service
{
    public class PostService : GenericService<Post, PostRepo>
    {
        public Post GetById(string Id)
        {
            var obj = UnitOfWork.Repository<PostRepo>().Queryable().FirstOrDefault(x => x.Id == Id);
            if(obj == null)
            {
                return obj;
            }
            var listImag = UnitOfWork.Repository<ImageRepo>().Queryable().Where(x=>x.Id_Post == obj.Id).ToList();
            var listContent = UnitOfWork.Repository<ContentRepo>().Queryable().Where(x=>x.Id_Post == Id).ToList();
            obj.Images = listImag;
            obj.Contents = listContent;
            return obj;
        }

        public override void GetAll()
        {
            base.GetAll();
            foreach(var item in ObjList)
            {
                var category = UnitOfWork.Repository<CategoryRepo>().Queryable().FirstOrDefault(x=>x.Id == item.CategoryId);
                item.Category = category;
            }
        }

        public List<Post> Search(PostService service)
        {
            var lstPost = UnitOfWork.Repository<PostRepo>().Queryable().Where(x => x.Date.Day == service.ObjDetail.Date.Day && x.Date.Month == service.ObjDetail.Date.Month && x.Date.Year == service.ObjDetail.Date.Year).ToList();
            return lstPost;
        }
        public List<Category> GetCategories()
        {
            var categories = UnitOfWork.Repository<CategoryRepo>().GetAll().ToList();
            return categories;
        }

        public List<Post> GetPosts()
        {
            var posts = UnitOfWork.Repository<PostRepo>().GetAll().ToList();
            foreach(var item in  posts)
            {
                var category = UnitOfWork.Repository<CategoryRepo>().Queryable().FirstOrDefault(x => x.Id == item.Id);
                var images = UnitOfWork.Repository<ImageRepo>().Queryable().FirstOrDefault(x => x.Id_Post == item.Id);
                item.Images.Add(images);
                item.Category = category;
            }
            return posts;
        }

        public List<Post> GetPostsHome(ModelPaging model, string code)
        {
            var posts = UnitOfWork.Repository<PostRepo>().GetAll().ToList();
            if (code != null)
            {
                posts = posts.Where(x => x.CategoryId == code).ToList();
            }
            decimal totalPage = (decimal)posts.Count / model.pageSize;
            model.totalCount = (int)Math.Ceiling(totalPage);
            posts = posts.Skip((model.currentPage - 1) * model.pageSize).Take(model.pageSize).ToList();
            foreach (var item in posts)
            {
                var Image = UnitOfWork.Repository<ImageRepo>().Queryable().Where(x => x.Id_Post == item.Id).ToList();
                item.Images = Image;
            }
            return posts;
        }

        public override void Delete(string strLstSelected)
        {
            try
            {
                var lstContent = UnitOfWork.Repository<ContentRepo>().Queryable().Where(x => x.Id_Post == strLstSelected).ToList();
                var lstImage = UnitOfWork.Repository<ImageRepo>().Queryable().Where(x => x.Id_Post == strLstSelected).ToList();
                var contentService = new ContentService();
                var imageService = new ImageService();
                foreach(var item in lstContent)
                {
                    contentService.Delete(item.Id);
                }
                foreach (var item in lstImage)
                {
                    imageService.Delete(item.Id);
                }

                base.Delete(strLstSelected);
                this.State = true;
            }
            catch
            {
                this.State = false;
            }
        }

    }
}