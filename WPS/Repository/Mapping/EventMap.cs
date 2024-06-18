using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Repository.Mapping
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Table("Event");
            Id(m => m.Id);
            Map(m => m.Id_Post);
            Map(m => m.Title);
            Map(m => m.Id_Image).Not.Update();
            Map(m=>m.Category_Id);
            Map(m => m.Date);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}