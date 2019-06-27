using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    //我的订单

    public class MyIndentController : Controller
    {

        public IActionResult Index()
        {
            //取Redis
            Users tmpUser1 = RedisHelper.Get<Users>("UsersName");
            ViewBag.UserId = tmpUser1.Id;
            return View();
        }
    }
}