using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 优惠券
    /// </summary>
    public class Coupon
    {
        /// <summary>
		/// 主键ID
		/// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public int CouponMoney
        {
            get; set;
        }
        /// <summary>
        /// 领取时间  
        /// </summary>
        public DateTime CouponBeginTime
        {
            get; set;
        }
        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime CouponEndTime
        {
            get; set;
        }
        /// <summary>
        /// 用券条件
        /// </summary>
        public int CouponCondition
        {
            get; set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int CouponStatu
        {
            get; set;
        }
        /// <summary>
        /// 用户Id（外键）
        /// </summary>
        public int UsersId
        {
            get; set;
        }
    }
}
