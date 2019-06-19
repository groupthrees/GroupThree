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
        public CouponDto Getcouponlist(int id, int pageIndex, int pageSize, int statuid=1)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select count(1) from coupon where UsersId={0} and CouponStatu ={1}", id, statuid);
                var total = conn.ExecuteScalar<int>(strSql1);

                int index = (pageIndex - 1) * pageSize;
                  var strSql2 = string.Format("select * from coupon where UsersId={0} and CouponStatu ={1}  limit  {2},{3}", id, statuid,index, pageSize);

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

        /// <summary>
        /// 领取优惠券
        /// </summary>
        /// <param name="shopCart"></param>
        /// <returns></returns>
        public int Insertcoupon(Coupon coupon)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strsql = string.Format("insert into coupon values({0},'{1}',{2},'{3}','{4}',{5},{6},{7})", coupon.Id, coupon.CouponName, coupon.CouponMoney, coupon.CouponBeginTime, coupon.CouponEndTime, coupon.CouponCondition, coupon.CouponStatu, coupon.UsersId);
                var result = conn.Execute(strsql);
                return result;
            }
        }
    }
}

