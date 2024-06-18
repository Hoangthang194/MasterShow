using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core.Common;

namespace WPS.Core
{
    public class Post : BaseEntity
    {
        public virtual string Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime Date { get; set; } = DateTime.Now;
        public virtual string Description { get; set; }
        public virtual int Month { get;set; }
        public virtual int Year { get; set; }
        public virtual string CategoryId { get; set; }
        public virtual Category Category { get; set; } = new Category();
        public virtual List<ContentModel> Contents { get; set; } = new List<ContentModel>();
        public virtual List<Image> Images { get; set; } = new List<Image>();
    }
}