using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers.值得买
{
    public class BuyController : Controller
    {
        public IActionResult BuyIndex()
        {
            return View();
        }
    }
}