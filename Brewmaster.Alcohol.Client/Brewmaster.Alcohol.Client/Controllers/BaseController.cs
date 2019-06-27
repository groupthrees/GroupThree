using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public Users LoginInfo
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = RedisHelper.Get<Users>(User.Identity.Name);
                    return tmpuserInfo;
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpUser"></param>
        public void WriteCookie(Users tmpUser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, tmpUser.UsersName));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //存储redis
            RedisHelper.Set<Users>(tmpUser.UsersName, tmpUser);

            //取Redis-测试
            var tmpUser1 = RedisHelper.Get<Users>(tmpUser.UsersName);
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