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
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=fantaotao;Pwd=123456;";

        /// <summary>
        /// 订单状态查询
        /// </summary>
        /// <param name="orderSite"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IndentPageList GetIndentPageList(int orderSite, int userId, int pageIndex, int pageSize)
        {
            IndentPageList indentPageList = new IndentPageList();
            var sql = "";
            var sqlCount = "";
            int sum = (pageIndex - 1) * pageSize;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                sql = string.Format("select OrderNo,OrderSite,OrderDate,OrderMoney,PracticalMoney,GoodsName,GoodsImg from Goods inner join OrderGoods on Goods.Id = OrderGoods.GoodId inner join Orders on Orders.Id = OrderGoods.OrdersId inner join Users on Users.Id=Orders.UsersId where OrderSite={0} and UsersId={1} limit {2},{3}  ", orderSite, userId, sum, pageSize);
                sqlCount = string.Format("select count(Goods.Id) from Goods inner join OrderGoods on Goods.Id = OrderGoods.GoodId inner join Orders on Orders.Id = OrderGoods.OrdersId inner join Users on Users.Id=Orders.UsersId where OrderSite={0} and UsersId={1}", orderSite, orderSite);
                var result = conn.Query<IndentDto>(sql).ToList();
                indentPageList.IndentPageListShow = result;
                indentPageList.Total = conn.ExecuteScalar<int>(sqlCount);
                return indentPageList;
            }
        }
    }
}
