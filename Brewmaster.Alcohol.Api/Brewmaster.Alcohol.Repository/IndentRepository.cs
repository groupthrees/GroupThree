
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto;
using Brewmaster.Alcohol.Model.Dto.订单Dto;
using Dapper;
using MySql.Data.MySqlClient;

namespace Brewmaster.Alcohol.Repository
{
    public class IndentRepository : IIndentRepository
    {

        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        /// <summary>
        ///订单显示
        /// </summary>
        /// <param name="orderSite"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IndentPageList GetIndentPageList( int userId, int OrderSite, int pageIndex, int pageSize)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select count(1)  from orders join address on orders.addressId = address.Id join ordergoods on ordergoods.OrdersId = orders.Id join goods on goods.Id = ordergoods.GoodId where orders.usersId = {0} and orders.OrderSite={1} ",userId,OrderSite);
                var total = conn.ExecuteScalar<int>(strSql1);
                int index = (pageIndex - 1) * pageSize;
                var strSql2 = string.Format("select  orders.Id,goods.GoodsName,goods.GoodsImg,orders.ApplyMethod,orders.PracticalMoney,address.AddressPerson from orders join address on orders.addressId = address.Id join ordergoods on ordergoods.OrdersId = orders.Id join goods on goods.Id = ordergoods.GoodId where orders.usersId = {0} and orders.OrderSite = {1} limit  {2},{3}",userId,OrderSite,pageIndex,pageSize);

                var orderlist = conn.Query<IndentDto>(strSql2);
                if (orderlist == null)
                {
                    return new IndentPageList();
                }
                var IndentDto = new IndentPageList
                {
                    IndentPageListShow = orderlist.ToList(),
                    Total = total
                };
                return IndentDto;
            }

        }

     


    }
}
