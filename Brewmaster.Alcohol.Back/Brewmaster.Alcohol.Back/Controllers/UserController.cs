using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Back.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult AddRole()
        {
            return View();
        }
        public IActionResult AddPermission()
        {
            return View();
        }
        public IActionResult UpdateUser()
        {
            return View();
        }
        public IActionResult UpdateRole()
        {
            return View();
        }
        public IActionResult UpdatePermission()
        {
            return View();
        }
    }
}