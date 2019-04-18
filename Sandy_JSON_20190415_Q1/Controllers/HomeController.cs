using Newtonsoft.Json;
using Sandy_JSON_20190415_Q1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
                        if (item.Locale == "US" || item.Locale == "CA")
                        {
                            item.Price = price.ToString().Replace(".00", "");
                            item.Price = item.Price.Replace(price.ToString(),string.Format("${0:N}", price));

                        }
                        else if (item.Locale == "JP")
                        {
                   
                            item.Price = price.ToString().Replace(".00", "");
                            item.Price = item.Price.Replace(price.ToString(), string.Format("¥{0:0,0}", Math.Round(price)));
                          
                        }
                        else if (item.Locale == "DE" || item.Locale == "ES" || item.Locale == "FR")
                        {
                            item.Price = price.ToString().Replace(".00", "");
                            item.Price = item.Price.Replace(price.ToString(), string.Format("€{0:N0}", price));

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
                     
                        if (item.Locale == "US" || item.Locale == "CA")
                        {
                            item.Promote_Price = promtePrice.ToString().Replace(".00", "");
                            item.Promote_Price = item.Promote_Price.Replace(promtePrice.ToString(), string.Format("${0:N}", promtePrice));

                        }
                        else if (item.Locale == "JP")
                        {
                            item.Promote_Price = promtePrice.ToString().Replace(".00", "");
                            item.Promote_Price = item.Promote_Price.Replace(promtePrice.ToString(), string.Format("¥{0:N0}", promtePrice));

                        }
                        else if (item.Locale == "DE" || item.Locale == "ES" || item.Locale == "FR")
                        {
                            item.Promote_Price = promtePrice.ToString().Replace(".00", "");
                            item.Promote_Price = item.Promote_Price.Replace(promtePrice.ToString(), string.Format("€{0:N0}", promtePrice));

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