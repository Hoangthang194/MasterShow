using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Common;
using WPS.Repository.Interface;

namespace WPS.Repository.Implement
{
    public class ImageRepo : GenericRepository<Image>, IImageRepo
    {
        public ImageRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}