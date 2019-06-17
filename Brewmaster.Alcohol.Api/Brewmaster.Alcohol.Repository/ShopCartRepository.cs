using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto.我的购物车;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brewmaster.Alcohol.Repository
{
    public class ShopCartRepository: IShopCartRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        /// <summary>
        /// 根据UserId,GoodsId查询收藏的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ShopCartPageList GetShopCartlist(int id, int pageIndex, int pageSize)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select count(1) from shopcart join goods on shopcart.GoodsId = goods.Id join price on goods.Id=price.Goodsid where  UsersId={0}", id);
                var total = conn.ExecuteScalar<int>(strSql1);
                int index = (pageIndex - 1) * pageSize;
                var strSql2 = string.Format("select * from shopcart join goods on shopcart.GoodsId = goods.Id join price on goods.Id=price.Goodsid where UsersId={0} limit  {1},{2}", id, index, pageSize);

                var shopcartlist = conn.Query<ShopCartDto>(strSql2);
                if (shopcartlist == null)
                {
                    return new ShopCartPageList();
                }
                var shopcartDto = new ShopCartPageList
                {
                    ShopCartList = shopcartlist.ToList(),
                    Total = total
                };
                return shopcartDto;
            }
        }
    }
}
