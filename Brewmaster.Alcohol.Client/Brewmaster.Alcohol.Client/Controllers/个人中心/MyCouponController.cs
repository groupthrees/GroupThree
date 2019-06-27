using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers.个人中心
{
    //我的优惠券
    public class MyCouponController : Controller
    {
        //取Redis
        Users tmpUser1 = RedisHelper.Get<Users>("UsersName");
        /// <summary>
        /// 优惠券界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.id = tmpUser1.Id;
            return View();
        }
    }
}