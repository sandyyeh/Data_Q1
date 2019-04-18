using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sandy_JSON_20190415_Q1.Models
{
    public class ViewModel
    {

       public string Locale { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime Date1 { get; set; }
        public string Product_Name { get; set; }
        public string Price { get; set; }
        public string Promote_Price { get; set; }
    }
}