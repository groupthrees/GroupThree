using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Cache;
using Brewmaster.Alcohol.Back.Models;

namespace Brewmaster.Alcohol.Back
{
    /// <summary>
    /// 动作过滤器
    /// </summary>
    public class MyAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 判断是否授权
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var tmpUser = RedisHelper.Get<UserInfo>(filterContext.HttpContext.User.Identity.Name);
                //var tmpUser = RedisHelper.Get<UserInfo>("UserName");
                if (tmpUser != null)
                {
                    //获取访问路径
                    string tempAction = filterContext.RouteData.Values["action"].ToString();
                    string tempController = filterContext.RouteData.Values["controller"].ToString();
                    var path = "/" + tempController  + "/" + tempAction;
                    //验证是否有访问权限
                    var result = tmpUser.PermissionList.Exists(m => m.Url.ToLower() == path.ToLower());
                    if (!result)
                    {
                        filterContext.Result = new RedirectResult("/test/Login");
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/test/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
