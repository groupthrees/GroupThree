using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Back.Controllers
{
    /// <summary>
    /// 库存控制器
    /// </summary>
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}