using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Models
{
    public class ViewEventModel
    {
        public int currentPage { get; set; } = 1;
        public int pageSize = 6;
        public string code { get; set; }
        public int numberPage { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();

        public List<Event> Events { get; set; } = new List<Event>();
    }
}