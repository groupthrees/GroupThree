using Brewmaster.Alcohol.Model.Dto.我的购物车;
using System;
using System.Collections.Generic;
using System.Text;

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
        ShopCartPageList GetShopCartlist(int id, int pageIndex, int pageSize);
    }
}
