using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers.个人中心
{
    public class MyCouponController : Controller
    {
        //我的优惠券

        public IActionResult Index()
        {
            return View();
        }
    }
}