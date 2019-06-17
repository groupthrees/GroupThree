using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto.我的购物车;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.个人中心
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IShopCartRepository _ShopCartRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public ShopCartController(IShopCartRepository ShopCartRepository)
        {
            _ShopCartRepository = ShopCartRepository;
        }

        [HttpGet("GetShopCartlist")]
        public ShopCartPageList GetShopCartlist(int id, int pageIndex, int pageSize)
        {
            return _ShopCartRepository.GetShopCartlist(id, pageIndex, pageSize);
        }
    }
}