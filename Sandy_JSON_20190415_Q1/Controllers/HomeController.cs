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
            List<ViewModel> list = JsonConvert.DeserializeObject<List<ViewModel>>(json);

            foreach (var item in list)
            {

                if (!string.IsNullOrEmpty(item.Price))
                {
                    if (decimal.TryParse(item.Price, out decimal number))
                    {
                        float price = Convert.ToSingle(item.Price);
                        item.Price = string.Format(new CultureInfo(GetLocale(item.Locale)), "{0:c}", price);

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
                        item.Promote_Price = string.Format(new CultureInfo(GetLocale(item.Locale)), "{0:c}", promtePrice);

                    }
                    else { item.Promote_Price = item.Promote_Price.Replace(item.Promote_Price, "-"); }

                }

                item.Promote_Price = (!string.IsNullOrEmpty(item.Promote_Price)) ? item.Promote_Price : "-";
            }


            return View(list);
        }



        public string GetLocale(string locale)
        {
            string result = "";

            switch (locale)
            {
                case "US":
                    result = "en-US";
                    break;
                case "CA":
                    result = "en-CA";
                    break;
                case "JP":
                    result = "ja-JP";
                    break;
                case "ES":
                    result = "es-ES";
                    break;
                case "DE":
                    result = "de-DE";
                    break;
                case "FR":
                    result = "fr-FR";
                    break;
            }


            return result;
        }

    }

}