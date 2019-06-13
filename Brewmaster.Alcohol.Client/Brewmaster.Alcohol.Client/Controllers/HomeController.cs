using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Microsoft.AspNetCore.Mvc;

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
            return Json(list);
        }
    }
}