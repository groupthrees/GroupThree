using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brewmaster.Alcohol.Repository
{
    public class CouponRepository: ICouponRepository
    {
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        /// <summary>
        /// 根据UsersId查询优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public CouponDto Getcouponlist(int id, int pageIndex, int pageSize)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select count(1) from coupon where UsersId={0}", id);
                var total = conn.ExecuteScalar<int>(strSql1);

                int index = (pageIndex - 1) * pageSize;
                  var strSql2 = string.Format("select * from coupon where UsersId={0} limit  {1},{2}", id, index, pageSize);

                var couponlist = conn.Query<Coupon>(strSql2);
                if (couponlist == null)
                {
                    return new CouponDto();
                }
                var couponDto = new CouponDto
                {
                    CouponList = couponlist.ToList(),
                    Total = total
                };
                return couponDto;
            }
        }
    }
}
// sql = string.Format("select OrderNo,OrderSite,OrderDate,OrderMoney,PracticalMoney,GoodsName,GoodsImg from Goods inner join OrderGoods on Goods.Id = OrderGoods.GoodId inner join Orders on Orders.Id = OrderGoods.OrdersId where OrderSite={0} limit {1},{2}  ", orderSite, sum, pageSize);
//                sqlCount = string.Format("select (Goods.Id) from Goods inner join OrderGoods on Goods.Id = OrderGoods.GoodId inner join Orders on Orders.Id = OrderGoods.OrdersId where OrderSite={0}", orderSite);
//                var result = conn.Query<IndentPageList>(sql).ToList();
//                indentPageList.IndentPageListShow = result;
//                indentPageList.Total = conn.ExecuteScalar<int>(sqlCount);
//                return indentPageList;


