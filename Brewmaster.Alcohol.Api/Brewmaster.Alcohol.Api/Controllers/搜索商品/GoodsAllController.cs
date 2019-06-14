using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto;
using Brewmaster.Alcohol.Model.Dto.搜索商品Dto;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Brewmaster.Alcohol.Api.Controllers.搜索商品
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsAllController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoodsAllRepository _goodsAllRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public GoodsAllController(IGoodsAllRepository GoodsAllRepository)
        {
            _goodsAllRepository = GoodsAllRepository;
        }

        [HttpGet("GetGoodsAllListPage")]
        public GoodsAllListPage GetGoodsAllListPage(string goodsName = "", string goodsDegree = "", int priceNow = 789, string brandName = "", string placeName = "", string aromaName = "", string typeName = "", int pageIndex = 1, int pageSize = 3)
        {
            var list = _goodsAllRepository.GetGoodsAll(goodsName, goodsDegree, priceNow, brandName, placeName, aromaName, typeName, pageIndex, pageSize);
            return list;
        }
    }
}