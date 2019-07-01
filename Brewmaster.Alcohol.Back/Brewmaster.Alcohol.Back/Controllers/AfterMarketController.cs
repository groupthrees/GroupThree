using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Back.Controllers
{
    /// <summary>
    /// 售后服务控制器
    /// </summary>
    public class AfterMarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}