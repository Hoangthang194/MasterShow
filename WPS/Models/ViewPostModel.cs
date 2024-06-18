using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Models
{
    public class ViewPostModel
    {
        public int currentPage { get; set; } = 1;
        public int pageSize = 6;
        public int numberPage { get; set; }

        public string code { get;set; }
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set;}
    }
}