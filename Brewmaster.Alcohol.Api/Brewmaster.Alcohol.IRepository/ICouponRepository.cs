﻿using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.IRepository
{
    public interface ICouponRepository
    {

        /// <summary>
        /// 根据UserId查询优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        CouponDto Getcouponlist(int id, int pageIndex, int pageSize, int statuid = 1);

        /// <summary>
        /// 领取优惠券
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        int Insertcoupon(Coupon coupon);
    }
}
