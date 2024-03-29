﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


using Brewmaster.Alcohol.Client.Models;
namespace Brewmaster.Alcohol.Client.Controllers.购物车
{
    public class ShopController : Controller
    {
        //取Redis
        Users tmpUser1 = RedisHelper.Get<Users>("UsersName");
        ApiHelper client = new ApiHelper();
        /// <summary>
        /// 购物车界面
        /// </summary>
        /// <returns></returns>
        [AuthorizationActionFilter]
        public IActionResult ShopIndex()
        {

            var list = client.GetApiResult("get", $"ShopCart/GetShopCartlist?id={tmpUser1.Id}", null);
            var json = JsonConvert.DeserializeObject<List<ShopCartDto>>(list);
            return View(json);
        }

        /// <summary>
        /// 订单信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderIndex()
        {

            var s = RedisHelper.Get<BuyGoods>((tmpUser1.Id).ToString());
            List<int> onePricelist = new List<int>();//单价
            List<int> pricelist = new List<int>();//小计
            List<string> numlist = new List<string>();//小计
            var onePrice = s.onlyGoods.Split(',');
            var price = s.price.Split(',');
            var num = s.num.Split(',');
            //foreach (var item in onePrice)
            //{
            //    string p = item.Replace("/n", "");
            //    onePricelist.Add(Convert.ToInt32(p));
            //}
            //foreach (var item in price)
            //{
            //    string p = item.Replace("/n", "");

            //    pricelist.Add(Convert.ToInt32(p));
            //}
            ViewBag.sum = s.sum;
            ViewBag.num = num;
            ViewBag.price = price;
            ViewBag.onlyGoods = onePrice;
            ViewBag.id = s.ids;
            var list = client.GetApiResult("get", $"Indent/GetIndentById?id={ViewBag.id}");

            var json = JsonConvert.DeserializeObject<List<Goods>>(list);
            ViewBag.list = json;
            return View(json);
          
        }

        /// <summary>
        /// 支付界面
        /// </summary>
        /// <returns></returns>
        public IActionResult PaymentIndex()
        {
          

            var s = RedisHelper.Get<BuyGoods>("1");

            ViewBag.sum = s.sum;


            //List<int> onePricelist = new List<int>();//单价
            //List<int> pricelist = new List<int>();//小计

            //var onePrice = s.onlyGoods.Split(',');
            //var price = s.price.Split(',');
            //foreach (var item in onePrice)
            //{
            //    string p = item.Replace("/n", "");
            //    onePricelist.Add(Convert.ToInt32(p));
            //}
            //foreach (var item in price)
            //{
            //    string p = item.Substring(0, item.Length - 1);
            //    pricelist.Add(Convert.ToInt32(p));
            //}


            return View();
        }

 

        /// <summary>
        /// 把该用户购物车选中的商品和数量存储到redis中
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="num"></param>
        public void redis(string ids, string price, string num, string onlyGoods, int sum)
        {
            //模拟从redis中取出登录用户的id
            int userId = tmpUser1.Id;
            RedisHelper.Set<BuyGoods>(userId.ToString(), new BuyGoods
            {
                
                ids = ids,
                price = price,
                num = num,
                onlyGoods = onlyGoods,
                sum = sum
            });
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AddOrder(int addressId)
        {
            var s = RedisHelper.Get<BuyGoods>((tmpUser1.Id).ToString());
            Orders orders = new Orders();
            orders.addressId = addressId;
            orders.OrderMoney = s.sum.ToString();
            orders.GoodsId = s.ids;
            orders.PracticalMoney= s.sum.ToString();
            orders.OrderSite = 0;
            orders.Price = s.price;
            orders.UserId = tmpUser1.Id;
            orders.OrderNo = "doooo1";
            orders.BuyNums = s.num;
            orders.ApplyMethod = "在线支付";
            orders.CouponMoney = "0";
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.GetApiResult("post", "ShopCart/MakeOrders",orders);
            return 1;
           
        }
    }
    public class BuyGoods
    {
        //商品id
        public string ids { get; set; }
        //小计
        public string price { get; set; }
        //价格
        public string onlyGoods { get; set; }
        //数量
        public string num { get; set; }
        //总价
        public int sum { get; set; }
    }
}