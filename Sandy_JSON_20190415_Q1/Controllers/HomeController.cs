using Newtonsoft.Json;
using Sandy_JSON_20190415_Q1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Sandy_JSON_20190415_Q1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            string file = Server.MapPath("~/App_Data/data.json");
            //deserialize JSON from file  
            string json = System.IO.File.ReadAllText(file);

          
            List<ViewModel> _list = JsonConvert.DeserializeObject<List<ViewModel>>(json);
  
            foreach (var item in _list)
            {
              
                if (!string.IsNullOrEmpty(item.Price))
                {               
                    if (decimal.TryParse(item.Price, out decimal number))
                    {
                        float price = Convert.ToSingle(item.Price);
                        if (item.Locale == "US" )
                        {                          
                            item.Price = string.Format(new CultureInfo("en-US"), "{0:c}", price);
                        }
                        else if (item.Locale == "CA")
                        {                          
                            item.Price = string.Format(new CultureInfo("en-CA"), "{0:c}", price);
                        }                  
                        else if (item.Locale == "JP")
                        {
                            item.Price = string.Format(new CultureInfo("ja-JP"), "{0:c}", price);
                        }
                        else if (item.Locale == "ES")
                        {                     
                            item.Price = string.Format(new CultureInfo("es-ES"), "{0:c}", price);
                        }
                        else if (item.Locale == "DE")
                        {
                            item.Price = string.Format(new CultureInfo("de-DE"), "{0:c}", price);
                        }
                        else if (item.Locale == "FR")
                        {
                            item.Price = string.Format(new CultureInfo("fr-FR"), "{0:c}", price);
                        }
                    }
                    else
                    {
                        item.Price = item.Price.Replace(item.Price, "-");
                    }
                }
                else
                {
                    item.Price = (!string.IsNullOrEmpty(item.Price)) ? item.Price : "-";
                }
                    



                if (!string.IsNullOrEmpty(item.Promote_Price))
                {                   
                    if (decimal.TryParse(item.Promote_Price, out decimal number2))
                    {
                        float promtePrice = Convert.ToSingle(item.Promote_Price);
                     
                        if (item.Locale == "US")
                        {
                            item.Promote_Price = string.Format(new CultureInfo("en-US"), "{0:c}", promtePrice);
                        }
                        else if (item.Locale == "CA")
                        {
                            item.Promote_Price = string.Format(new CultureInfo("en-CA"), "{0:c}", promtePrice);
                        }
                        else if (item.Locale == "JP")
                        {
                            item.Promote_Price = string.Format(new CultureInfo("ja-JP"), "{0:c}", promtePrice);
                        }
                        else if (item.Locale == "ES")
                        {
                            item.Promote_Price = string.Format(new CultureInfo("es-ES"), "{0:c}", promtePrice);
                        }
                        else if (item.Locale == "DE")
                        {
                            item.Promote_Price = string.Format(new CultureInfo("de-DE"), "{0:c}", promtePrice);
                        }
                        else if (item.Locale == "FR")
                        {
                            item.Promote_Price=string.Format(new CultureInfo("fr-FR"), "{0:c}", promtePrice);
                        }
                    }
                    else { item.Promote_Price = item.Promote_Price.Replace(item.Promote_Price, "-"); }
                
                }
                item.Promote_Price = (!string.IsNullOrEmpty(item.Promote_Price)) ? item.Promote_Price : "-";
            }


                return View(_list);
        }
          
    }

}