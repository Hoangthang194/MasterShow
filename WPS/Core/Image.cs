using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core.Common;

namespace WPS.Core
{
    public class Image : BaseEntity
    {
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string Url { get; set; }
        public virtual string Id_Post { get; set; }
    }
}