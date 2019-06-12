using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class CouponController : Controller
    {
        public IActionResult CouponIndex()
        {
            return View();
        }
    }
}