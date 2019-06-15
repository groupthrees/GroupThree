using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brewmaster.Alcohol.Catch;
namespace Brewmaster.Alcohol.Client.Controllers.商品详情
{
    public class ShopDetailsController : Controller
    {
        public IActionResult Index()
        {
            int id = 1;
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.GetApiResult("get", "Goodscollect/GetGoodscollectDto?id=1&goodsId="+id,null);
            return View();
        }
    }
}