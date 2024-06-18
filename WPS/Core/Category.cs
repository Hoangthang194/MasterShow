using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core.Common;

namespace WPS.Core
{
    public class Category: BaseEntity
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }
}