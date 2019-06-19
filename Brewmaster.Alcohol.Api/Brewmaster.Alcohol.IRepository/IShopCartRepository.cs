using Brewmaster.Alcohol.Model.Dto.我的购物车;
using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    public interface IShopCartRepository
    {
        /// <summary>
        /// 根据UsersId查询购物车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<ShopCartDto> GetShopCartlist(int id);

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteShopCart(int id);
        /// <summary>
        /// 下订单
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        int MakeOrders(Orders orders);
    }
}
