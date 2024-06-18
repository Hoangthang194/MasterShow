using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core.Common;

namespace WPS.Core
{
    public class Event: BaseEntity
    {

        public virtual string Id { get;set; }
        public virtual string Id_Post { get; set; }
        public virtual string Title { get; set; }

        public virtual DateTime Date { get; set; }
        public virtual string Id_Image { get; set; }
        public virtual CategoryProduct Category { get; set; } = new CategoryProduct();
        public virtual Post post { get; set; } = new Post();

        public virtual string Category_Id {  get; set; }
    }
}