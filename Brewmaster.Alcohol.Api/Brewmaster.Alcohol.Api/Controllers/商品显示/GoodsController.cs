using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.商品显示
{
    //商品显示
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoodsRepository _GoodsRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public GoodsController(IGoodsRepository GoodsRepository)
        {
            _GoodsRepository = GoodsRepository;
        }

        /// <summary>
        /// 首页商品显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("getGoodslist")]
        public List<GoodsDto> getGoodslist()
        {
            return _GoodsRepository.getGoodslist();
        }

    }
}