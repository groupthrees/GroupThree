using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodscollectController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoodsCollectReposity _GoodsCollectReposity;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public GoodscollectController(IGoodsCollectReposity GoodsCollectReposity)
        {
            _GoodsCollectReposity = GoodsCollectReposity;
        }
        /// <summary>
        /// 详情页查询
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        [HttpGet("GetGoodscollectDto")]
        public GoodscollectDto GetGoodscollectDto(int id,int goodsId)
        {
           var GoodscollectDtos=  _GoodsCollectReposity.GetGoodscollectDto(id,goodsId);
           return GoodscollectDtos;
        }
        [HttpGet("SetCollect")]
        public int SetCollect(int goodsId, int userId)
        {
            var GoodscollectDtos = _GoodsCollectReposity.SetCollect(goodsId,userId);
            return GoodscollectDtos;
        }
    }
}