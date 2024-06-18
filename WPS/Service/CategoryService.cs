using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Implement;
using WPS.Service.Common;

namespace WPS.Service
{
    public class CategoryService : GenericService<Category, CategoryRepo>
    {
        public Category GetById(string Id)
        {
            var obj = UnitOfWork.Repository<CategoryRepo>().Queryable().FirstOrDefault(x=>x.Id == Id);
            return obj;
        }

        public List<Category> GetAllCate()
        {
            var lst = UnitOfWork.Repository<CategoryRepo>().GetAll().ToList();
            return lst;
        }

    }
}