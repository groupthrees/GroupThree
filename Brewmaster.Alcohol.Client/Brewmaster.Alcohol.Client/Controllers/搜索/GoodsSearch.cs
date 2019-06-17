using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Brewmaster.Alcohol.Client.Models.Dto.搜索商品Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
