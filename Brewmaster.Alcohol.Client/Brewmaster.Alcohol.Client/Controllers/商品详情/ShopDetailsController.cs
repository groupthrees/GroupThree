﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brewmaster.Alcohol.Catch;
using Newtonsoft.Json;
using Brewmaster.Alcohol.Client.Models;
namespace Brewmaster.Alcohol.Client.Controllers
{
    public class ShopDetailsController : Controller
    {
        //取Redis
        Users tmpUser1 = RedisHelper.Get<Users>("UsersName");
        /// <summary>
        /// 商品详情页
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <param name="usersId">用户id</param>
        /// <returns></returns>
        public IActionResult Index2(int goodsId, int usersId)
        {
            ViewBag.usersId = tmpUser1.Id;
            goodsId = goodsId == 0 ? 1 : goodsId;
            ApiHelper apiHelper = new ApiHelper();
            string str = apiHelper.GetApiResult("get", $"Goodscollect/GetGoodscollectDto?id={tmpUser1.Id}&goodsId=" + goodsId, null);
            GoodscollectDto GoodscollectDto = JsonConvert.DeserializeObject<GoodscollectDto>(str);
            ViewBag.goods = GoodscollectDto.Goods;
            ViewBag.imgs = GoodscollectDto.Imgs;

            ViewBag.conllect = GoodscollectDto.Conllect;
            return View();
        }
    }
}