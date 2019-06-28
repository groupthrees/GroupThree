using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Brewmaster.Alcohol.Client.Models;
using Brewmaster.Alcohol.Catch;

namespace Brewmaster.Alcohol.Client
{
    /// <summary>
    /// 动作过滤器
    /// </summary>
    public class AuthorizationActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 判断是否授权
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/User/Login");

            }
            //    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    var tmpUser = RedisHelper.Get<UserInfo>(filterContext.HttpContext.User.Identity.Name);
            //    if (tmpUser != null)
            //    {
            //        //获取访问路径
            //        var path = filterContext.HttpContext.Request.Path.ToString();

            //        //验证是否有访问权限
            //        var result = tmpUser.PermissionList.Exists(m => m.Url.ToLower() == path.ToLower());
            //        if (!result)
            //        {
            //            filterContext.Result = new RedirectResult("/Account/Login");
            //        }
            //    }
            //}
            //else
            //{
            //    filterContext.Result = new RedirectResult("/Account/Login");
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}
