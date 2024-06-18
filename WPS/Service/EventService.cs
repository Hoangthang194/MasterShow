using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Models;
using WPS.Repository.Implement;
using WPS.Service.Common;

namespace WPS.Service
{
    public class EventService : GenericService<Event, EventRepo>
    {
        public Event GetById(string Id)
        {
            var obj = UnitOfWork.Repository<EventRepo>().Queryable().FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public List<Event> Search(EventService service)
        {
            var lstEvent = UnitOfWork.Repository<EventRepo>().Queryable().Where(x=>x.Date.Day == service.ObjDetail.Date.Day && x.Date.Month == service.ObjDetail.Date.Month && x.Date.Year == service.ObjDetail.Date.Year).ToList();
            return lstEvent;
        }

        public override void GetAll()
        {
            base.GetAll();
            foreach (var item in ObjList)
            {
                var category = UnitOfWork.Repository<CategoryProductRepo>().Queryable().FirstOrDefault(x => x.Id == item.Category_Id);
                var post = UnitOfWork.Repository<PostRepo>().Queryable().FirstOrDefault(x => x.Id == item.Id_Post);
                item.Category = category;
                item.post = post;
            }
        }

        public List<Event> GetAllEvent(ModelPaging model, string code)
        {
            var lst = UnitOfWork.Repository<EventRepo>().GetAll().ToList();

            if(code != null)
            {
                lst = lst.Where(x => x.Category_Id == code).ToList();
            }
            float totalPage = (float)lst.Count/model.pageSize;
            model.totalCount = (int)Math.Ceiling(totalPage);
            lst = lst.Skip((model.currentPage - 1) * model.pageSize).Take(model.pageSize).ToList();
            foreach (var item in lst)
            {
                var category = UnitOfWork.Repository<CategoryProductRepo>().Queryable().FirstOrDefault(x => x.Id == item.Category_Id);
                var post = UnitOfWork.Repository<PostRepo>().Queryable().FirstOrDefault(x => x.Id == item.Id_Post);
                item.Category = category;
                item.post = post;
            }
            return lst;
        }
        public List<CategoryProduct> GetCategories()
        {
            var categories = UnitOfWork.Repository<CategoryProductRepo>().GetAll().ToList();
            return categories;
        }

        public List<Post> GetPost()
        {
            var posts = UnitOfWork.Repository<PostRepo>().GetAll().ToList();
            return posts;
        }
    }
}