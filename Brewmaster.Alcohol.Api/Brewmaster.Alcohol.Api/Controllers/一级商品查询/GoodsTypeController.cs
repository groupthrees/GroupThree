using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.一级商品查询
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodsTypeController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoodsTypeRepository _goodsTypeRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public GoodsTypeController(IGoodsTypeRepository GoodsTypeRepository)
        {
            _goodsTypeRepository = GoodsTypeRepository;
        }

        /// <summary>
        /// 查询品牌名称
        /// </summary>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeName()
        {
            var list = _goodsTypeRepository.GetGoodsTypeName();
            return list;
        }

    }
}