using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace Brewmaster.Alcohol.Client.Controllers
{
    //商品搜索控制器
    public class GoodsSearch : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
