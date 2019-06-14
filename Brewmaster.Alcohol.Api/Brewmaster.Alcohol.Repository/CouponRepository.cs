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
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=huakunkun;Pwd=123456;";
        public CouponDto Getcouponlist(int id, int pageIndex, int pageSize)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql = string.Format("select count(1) from coupon where UsersId={0}",id);
                var total = conn.Query<int>(strSql, null);

                strSql = string.Format("select count(1) from coupon where UsersId={0} limit ( {1}- 1) * {2},{3}",id, pageIndex, pageSize, pageSize);
                var couponlist = conn.Query<Coupon>(strSql);
                if (couponlist==null)
                {
                    return new CouponDto();
                }
                var couponDto = new CouponDto
                {
                    CouponList = couponlist.ToList(),
                    Total = total.First<int>()
                };
                return couponDto;
            }
        }
    }
}
