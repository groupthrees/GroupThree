﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Back.Models;
using Brewmaster.Alcohol.Cache;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace Brewmaster.Alcohol.Back.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo LoginInfo
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = RedisHelper.Get<UserInfo>(User.Identity.Name);
                    return tmpuserInfo;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpUser"></param>
        public void WriteCookie(UserInfo tmpUser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, "UserName"));
            //identity.AddClaim(new Claim(ClaimTypes.Name, tmpUser.UserName));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            RedisHelper.Set<UserInfo>("UserName", tmpUser);
            //存储redis
            //RedisHelper.Set<UserInfo>(tmpUser.UserName, tmpUser);

            //////取Redis-测试
            //var tmpUser1 = RedisHelper.Get<UserInfo>(tmpUser.UserName);
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.LoginInfo = LoginInfo;
            base.OnActionExecuting(filterContext);
        }
    }
}