using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brewmaster.Alcohol.Client.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Brewmaster.Alcohol.Catch;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class UserController : Controller
    {

        #region 登录
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region 注册
        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Regist()
        {
            return View();
        }
        [HttpPost]
        public  int Regist(Users user)
        {
           
            int result = int.Parse(new ApiHelper().GetApiResult("post", "User/Resigt", user));
            return result;
        }

        #endregion

        #region 忘记密码
        public IActionResult Password()
        {
            return View();
        }
        #endregion


    
    }
}