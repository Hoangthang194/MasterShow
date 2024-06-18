using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Common;
using WPS.Repository.Interface;

namespace WPS.Repository.Implement
{
    public class CategoryRepo : GenericRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}