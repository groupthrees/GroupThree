using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Back.Models;
using Brewmaster.Alcohol.Cache;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Back.Controllers
{
    public class HomeController : Controller
    {
        [MyAuthorizeAttribute]
        public IActionResult Index()
        {
            var tmpUser1 = RedisHelper.Get<UserInfo>("UserName");
            if (tmpUser1 != null)
            {
                ViewBag.list = tmpUser1.PermissionList;
                ViewData["Modules"]= tmpUser1.PermissionList;
            }

            return View();
        }
    }
}