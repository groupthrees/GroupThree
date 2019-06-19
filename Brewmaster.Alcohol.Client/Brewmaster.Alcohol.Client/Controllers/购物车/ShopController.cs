using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Brewmaster.Alcohol.Client.Controllers.购物车
{
    public class ShopController : Controller
    {
        ApiHelper client = new ApiHelper();
        /// <summary>
        /// 购物车界面
        /// </summary>
        /// <returns></returns>
        public IActionResult ShopIndex()
        {
            var list = client.GetApiResult("get","ShopCart/GetShopCartlist?id=1", null);
            var json = JsonConvert.DeserializeObject<List<ShopCartDto>>(list);
            return View(json);
        }

        /// <summary>
        /// 升级的购物车界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 购物车界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index2()
        {
            var list = client.GetApiResult("get", "ShopCart/GetShopCartlist?id=1", null);
            var json=JsonConvert.DeserializeObject<List<ShopCartDto>>(list);
            return View(json);
        }

        /// <summary>
        /// 订单信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderIndex()
        {
            return View();
        }

        /// <summary>
        /// 支付界面
        /// </summary>
        /// <returns></returns>
        public IActionResult PaymentIndex()
        {
            return View();
        }

    }
}