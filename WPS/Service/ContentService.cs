using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;
using WPS.Repository.Implement;
using WPS.Service.Common;

namespace WPS.Service
{
    public class ContentService : GenericService<ContentModel, ContentRepo>
    {
        public List<ContentModel> GetByPost(string postId)
        {
            var contents = UnitOfWork.Repository<ContentRepo>().Queryable().Where(x=>x.Id_Post == postId).ToList();
            return contents;
        }

        public ContentModel GetById (string Id)
        {
            var content = UnitOfWork.Repository<ContentRepo>().Queryable().FirstOrDefault(x => x.Id == Id);
            return content;
        }
    }
}