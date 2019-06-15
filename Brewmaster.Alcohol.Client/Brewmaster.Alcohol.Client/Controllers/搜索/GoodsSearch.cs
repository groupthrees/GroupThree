using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Brewmaster.Alcohol.Client.Models.Dto.搜索商品Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Brewmaster.Alcohol.Client.Controllers
{
    //商品搜索控制器
    public class GoodsSearch : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.data=GetBrand();
            ViewBag.list=GetGoodsType();
            ViewBag.goodsAll = GetGoodsAllListPage();
            return View();
        }

        public List<Brand> GetBrand()
        {
            ApiHelper apiHelper=new ApiHelper();
            var str= apiHelper.GetApiResult("get", "Brand/GetBrandName",null);
            List<Brand> list = JsonConvert.DeserializeObject<List<Brand>>(str);
            return list;
        }

        public List<GoodsType> GetGoodsType()
        {
            ApiHelper apiHelper = new ApiHelper();
            var str = apiHelper.GetApiResult("get", "GoodsType/GetGoodsTypeName", null);
             List<GoodsType> list = JsonConvert.DeserializeObject<List<GoodsType>>(str);
            return list;
        }

        public List<GoodsAllListPage> GetGoodsAllListPage(string goodsName = "", string goodsDegree = "", int priceNow = 789, string brandName = "", string placeName = "", string aromaName = "", string typeName = "", int pageIndex = 1, int pageSize = 3)
        {
            ApiHelper apiHelper = new ApiHelper();
            var str = apiHelper.GetApiResult("get",
                "GoodsAll/GoodsAllListPage/?GoodsName=" + goodsName + "&goodsDegree=" + goodsDegree + "&priceNow" +
                priceNow + "&BrandName=" + brandName + "&placeName=" + placeName + "&pageSize=" + pageSize +
                "&pageIndex=" + pageIndex,null);
            List<GoodsAllListPage> list = JsonConvert.DeserializeObject<List<GoodsAllListPage>>(str);
            return list;
        }

    }
}
