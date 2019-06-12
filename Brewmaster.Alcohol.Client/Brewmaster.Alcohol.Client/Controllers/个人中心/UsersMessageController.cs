using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{

    /// <summary>
    /// 个人信息
    /// </summary>
    public class UsersMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}