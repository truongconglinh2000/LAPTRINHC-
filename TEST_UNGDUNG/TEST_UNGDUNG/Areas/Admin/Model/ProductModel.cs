using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST_UNGDUNG.Areas.Admin.Model
{
    public class ProductModel
    {
      [Required]
        public string name { get; set; }
        public int unicost { get; set; }
        public int quanity { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int idloai { get; set; }
    }
}