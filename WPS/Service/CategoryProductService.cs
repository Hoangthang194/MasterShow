using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Implement;
using WPS.Service.Common;

namespace WPS.Service
{
    public class CategoryProductService : GenericService<CategoryProduct, CategoryProductRepo>, ICategoryProductService
    {
        public CategoryProduct GetById(string Id)
        {
            var obj = UnitOfWork.Repository<CategoryProductRepo>().Queryable().FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public List<CategoryProduct> GetAllCatePro()
        {
            var lst = UnitOfWork.Repository<CategoryProductRepo>().GetAll().ToList();
            return lst;
        }
    }

    public interface ICategoryProductService : IGenericService<CategoryProduct>
    {

    }
}