using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Repository.Mapping
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap() {
            Table("Post");
            Id(m => m.Id);
            Map(m => m.Title);
            Map(m => m.Address);
            Map(m => m.Date);
            Map(m => m.Description);
            Map(m=>m.Month);
            Map(m => m.Year);
            Map(m => m.CategoryId);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}