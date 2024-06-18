using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Repository.Mapping
{
    public class ImageProductMap : ClassMap<ImageProduct>
    {
        public ImageProductMap()
        {
            Table("ImageProduct");
            Id(m => m.Id);
            Map(m => m.Description);
            Map(m => m.Url);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}