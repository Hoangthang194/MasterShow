using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPS.Models
{
    public class ModelPaging
    {
        public int currentPage { get; set; } = 1;
        public int pageSize = 6;
        public int totalCount { get; set; }
    }
}