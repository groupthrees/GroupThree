using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
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
        public List<ShopCartDto> GetShopCartlist(int id)
        {
            return _ShopCartRepository.GetShopCartlist(id);
        }


        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("DeleteShopCart")]
        public int DeleteShopCart(int id)
        {
            return _ShopCartRepository.DeleteShopCart(id);
        }
        [HttpPost("MakeOrders")]
        public int MakeOrders(Orders orders)
        {
            return _ShopCartRepository.MakeOrders(orders);
        }
    }
}