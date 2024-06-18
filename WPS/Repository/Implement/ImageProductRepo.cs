using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Common;
using WPS.Repository.Interface;

namespace WPS.Repository.Implement
{
    public class ImageProductRepo : GenericRepository<ImageProduct>, IImageProductRepo
    {
        public ImageProductRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}