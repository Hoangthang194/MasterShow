using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPS.Core;

namespace WPS.Models
{
    public class ViewDetailModel
    {
        public Post Post { get; set; }
        public List<Post> lstPost {  get; set; }   = new List<Post> { };
    }
}