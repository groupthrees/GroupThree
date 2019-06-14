using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto
{
    public class CouponDto
    {
        public List<Coupon> CouponList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
    }
}
