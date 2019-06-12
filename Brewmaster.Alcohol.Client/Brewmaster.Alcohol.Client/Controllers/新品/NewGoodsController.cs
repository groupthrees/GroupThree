using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers.新品
{
    public class NewGoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}