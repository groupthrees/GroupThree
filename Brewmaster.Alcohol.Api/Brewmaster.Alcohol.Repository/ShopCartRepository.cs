using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
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
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";


        /// <summary>
        /// 根据UserId查询购物车的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ShopCartDto> GetShopCartlist(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format(@"select shopcart.Num,goods.GoodsImg,goods.GoodsName,price.PriceNow,shopcart.Id,goods.Id 
                AS Goodsid from shopcart join goods on shopcart.GoodsId = goods.Id
                join price on goods.Id = price.Goodsid  where  UsersId ={0}", id);
                var result = conn.Query<ShopCartDto>(strSql1).ToList();
                return result;
            }
        }
        /// <summary>
        /// 下订单
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public int MakeOrders(Orders orders)
        {
                       int i = 0;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strOrder = $@"INSERT into orders(OrderNo,OrderSite,OrderMoney,PracticalMoney,usersId,addressId,CouponMoney,ApplyMethod)
                  values('{orders.OrderNo}', {orders.OrderSite}, '{orders.OrderMoney}', {orders.PracticalMoney}, {orders.UserId}, {orders.addressId}, {orders.CouponMoney},  '{orders.ApplyMethod}')";
                 i= conn.Execute(strOrder);
                if (i > 0)
                {
                    var BuyNums = orders.BuyNums.Split(',');
                    var GoodsId= orders.GoodsId.Split(',');
                    var Price = orders.Price.Split(',');
                    for (int j = 0; j < BuyNums.Length; j++)
                    {
                        string str = $"INSERT into ordergoods(GoodsId, OrdersId, BuyNum, usersId,price) values({orders.GoodsId}, {Convert.ToInt32(GoodsId[j])}, {Convert.ToInt32(BuyNums[j]) },1,{Convert.ToDecimal(Price[j])})";
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// 删除购物车商品
        /// </summary>

        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        public int DeleteShopCart(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql = string.Format("delete  from shopcart where Id IN ({0})", id);
                int result = conn.Execute(strSql);
                return result;


            }
        }

    }
}
