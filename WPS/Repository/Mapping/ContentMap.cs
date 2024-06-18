using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WPS.Core;

namespace WPS.Repository.Mapping
{
    public class ContentMap: ClassMap<ContentModel>
    {
        public ContentMap()
        {
            Table("Content");
            Id(m => m.Id);
            Map(m => m.Title);
            Map(m => m.Description);
            Map(m=>m.Id_Post);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}