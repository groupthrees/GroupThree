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
        /// 根据UserId,GoodsId查询购物车的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ShopCartDto> GetShopCartlist(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select * from shopcart join goods on shopcart.GoodsId = goods.Id join price on goods.Id=price.Goodsid where  UsersId={0}", id);

                var result = conn.Query<ShopCartDto>(strSql1).ToList();
                return result;
            }
        }

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteShopCart(string[] goodsid)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql = string.Format("delete  from shopcart where goodsid IN ()", id);
                int result = conn.Execute(strSql);
                return result;

              
            }
        }

    }
}
