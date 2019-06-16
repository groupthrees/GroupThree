using System;
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
        public IActionResult Index()
        {
            int id = 1;
            ApiHelper apiHelper = new ApiHelper();
            string str=  apiHelper.GetApiResult("get", "Goodscollect/GetGoodscollectDto?id=1&goodsId="+id,null);
            GoodscollectDto GoodscollectDto = JsonConvert.DeserializeObject<GoodscollectDto>(str);
            ViewBag.goods = GoodscollectDto.Goods;
            ViewBag.imgs = GoodscollectDto.Imgs;
            ViewBag.conllect = GoodscollectDto.Conllect;
            return View();
        }
    }
}