using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class CouponController : Controller
    {
        //取Redis
        Users tmpUser1 = RedisHelper.Get<Users>("UsersName");
        /// <summary>
        /// 领券中心
        /// </summary>
        /// <returns></returns>
        public IActionResult CouponIndex()
        {
            ViewBag.id = tmpUser1.Id;
            return View();
        }
    }
}