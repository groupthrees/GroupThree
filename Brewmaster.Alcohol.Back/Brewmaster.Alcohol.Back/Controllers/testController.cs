using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Back.Controllers;
using Brewmaster.Alcohol.Back.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Back.Controllers
{
    public class testController : BaseController
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
            var tmpUser = new UserInfo
            {
                Id = 1,
                Password = "1",
                UserName = "1",
                PermissionList = new List<Permission>() {

                     new Permission{  Id=2, Name="订单管理", Pid=0, Url="/Order/Index"},
                     new Permission{  Id=3, Name="产品管理", Pid=0, Url="/Goods/Index"},
                     new Permission{  Id=4, Name="库存管理", Pid=0, Url="/Stock/Index"},
                     new Permission{  Id=1, Name="用户管理", Pid=0, Url="/User/Index"},
                     new Permission{  Id=5, Name="售后管理", Pid=0, Url="/AfterMarket/Index"},

                     new Permission{  Id=6, Name="添加用户", Pid=1, Url="/AfterMarket/index"},
                     new Permission{  Id=7, Name="添加角色", Pid=1, Url="/Stock/index"},
                     new Permission{  Id=8, Name="添加权限", Pid=1, Url="/test/test"},
                     new Permission{  Id=9, Name="订单查询", Pid=2, Url="/User/index"},

                     new Permission{  Id=10, Name="商品列表", Pid=3, Url="/test/test"},
                     new Permission{  Id=11, Name="库存查询", Pid=3, Url="/Home/index"},
                }
             };
            ViewBag.PermissionList = tmpUser.PermissionList;

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

            //return RedirectToAction(nameof(testController.test), "test");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(testController.Login),"test");

        }
        [MyAuthorizeAttribute]
        public IActionResult test()
        {
            return View();
        }
    }
}