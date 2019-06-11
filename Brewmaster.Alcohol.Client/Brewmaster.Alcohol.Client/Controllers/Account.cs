using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult LoginDo(UserInfo user, string returnUrl = null)
        {
            //验证用户是否登录
            const string errorMessage = "用户名或密码错误！";
            if (user == null)
            {
                return BadRequest(errorMessage);
            }
            var tmpUser = new UserInfo().GetUserList().FirstOrDefault(m => m.UserName == user.UserName && m.Password == user.Password);
            if (tmpUser?.Password != user.Password)
            {
                return BadRequest(errorMessage);
            }

            //写入缓存
            WriteCookie(tmpUser);

            //判断是否返回前页
            if (returnUrl == null)
            {
                returnUrl = TempData["returnUrl"]?.ToString();
            }
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }
        public IActionResult test()
        {
            return View(); 
        }

        public IActionResult Jiu()
        {
            return View();
        }
    }
}