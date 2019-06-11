using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IRepository;
using System.Net.Http;
using System.Net.Http.Headers;
using Model;

namespace Brewmaster.Alcohol.Api.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //测试HttpClient调用Api
            var i = GetProductById();

            //测试mvc直接调用数据
            var result = _productRepository.GetProduct(4);

            return View();
        }

        [MyActionFilter]
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

        [MyActionFilter]
        public IActionResult Contact()
        {
            ViewData["Message"] = "测试页面";
            return View();
        }

        [MyActionFilter]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 按照id查询订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById()
        {
            //定义提供api的服务地址对象
            Uri uri = new Uri("http://localhost:50449/");

            //定义HttpClient对象，用于发送http请求
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;//设置http请求的地址
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//设置请求的数据传输格式

            var strVal = "";
            //接收http请求返回的结果信息
            HttpResponseMessage response = client.GetAsync("/api/values/" + 4).Result;
            if (response.IsSuccessStatusCode)
            {
                //将文本数据流转为传输的json数据格式
                strVal = response.Content.ReadAsStringAsync().Result;
            }

            //释放掉http请求对象
            client.Dispose();
            var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(strVal);
            return product;
        }

        public ActionResult Hotel()
        {
            return View();
        }
    }
}