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
            var list = client.GetApiResult("get", "ShopCart/GetShopCartlist?id=1", null);
            var json = JsonConvert.DeserializeObject<List<ShopCartDto>>(list);
            return View(json);
        }


        /// <summary>
        /// 订单信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderIndex()
        {

            var s = RedisHelper.Get<BuyGoods>("1");

            List<int> onePricelist = new List<int>();//单价
            List<int> pricelist = new List<int>();//小计

            var onePrice = s.onlyGoods.Split(',');
            var price = s.price.Split(',');
            foreach (var item in onePrice)
            {
                string p = item.Replace("/n", "");
                onePricelist.Add(Convert.ToInt32(p));
            }
            foreach (var item in price)
            {
                string p = item.Substring(0, item.Length - 1);
                pricelist.Add(Convert.ToInt32(p));
            }
            return View();
        }

        /// <summary>
        /// 支付界面
        /// </summary>
        /// <returns></returns>
        public IActionResult PaymentIndex()
        {
            //var s = RedisHelper.Get<BuyGoods>("1");
            //List<int> onePricelist = new List<int>();//单价
            //List<int> pricelist = new List<int>();//小计

            //var onePrice = s.onlyGoods.Split(',');
            //var price = s.price.Split(',');
            //foreach (var item in onePrice)
            //{
            //    string p = item.Replace("/n","");
            //    onePricelist.Add(Convert.ToInt32(p));
            //}
            //foreach (var item in price)
            //{
            //    string p = item.Substring(0, item.Length - 1);
            //    pricelist.Add(Convert.ToInt32(p));
            //}

            var s = RedisHelper.Get<BuyGoods>("1");

            List<int> onePricelist = new List<int>();//单价
            List<int> pricelist = new List<int>();//小计

            var onePrice = s.onlyGoods.Split(',');
            var price = s.price.Split(',');
            foreach (var item in onePrice)
            {
                string p = item.Replace("/n", "");
                onePricelist.Add(Convert.ToInt32(p));
            }
            foreach (var item in price)
            {
                string p = item.Substring(0, item.Length - 1);
                pricelist.Add(Convert.ToInt32(p));
            }

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
            int userId = 1;
            RedisHelper.Set<BuyGoods>(userId.ToString(), new BuyGoods
            {
                ids = ids,
                price = price,
                num = num,
                onlyGoods = onlyGoods,
                sum = sum
            });
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