using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class HomeController : Controller
    {
        ApiHelper client = new ApiHelper();
        public IActionResult HomePage()
        {

            return View(); 
        }
        public IActionResult Index()
        {
            var list = client.GetApiResult("get", "Goods/getgoodslist", null);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new DefaultContractResolver();
            return Json(list, settings);
        }
    }
}

