using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Brewmaster.Alcohol.Client.Models;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult HomePage()
        {
            return View();
        }


        public IActionResult test()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            //测试HttpClient调用Api
            //var i = GetProductById();
            //ViewBag.l = i;
            return View();
        }

        public IActionResult Members()
        {
            var name = LoginInfo.UserName;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Cors()
        {
            var name = LoginInfo.UserName;
            ViewData["Message"] = "允许匿名登录的页面";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "测试页面";
            return View();
        }

        public IActionResult Test1()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 按照id查询订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetProductById()
        {
            //定义提供api的服务地址对象
            Uri uri = new Uri("http://localhost:50169/");

            //定义HttpClient对象，用于发送http请求
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;//设置http请求的地址
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//设置请求的数据传输格式

            var strVal = "";
            //接收http请求返回的结果信息
            HttpResponseMessage response = client.GetAsync("/api/Default/Get?id=1").Result;
            if (response.IsSuccessStatusCode)
            {
                //将文本数据流转为传输的json数据格式
                strVal = response.Content.ReadAsStringAsync().Result;
            }

            //释放掉http请求对象
            client.Dispose();
            //var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(strVal);
            return 0;
        }
    }
}