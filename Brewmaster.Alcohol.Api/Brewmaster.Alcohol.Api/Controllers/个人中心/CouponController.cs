using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.个人中心
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ICouponRepository _CouponRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public CouponController(ICouponRepository CouponRepository)
        {
            _CouponRepository = CouponRepository;
        }

        /// <summary>
        /// 根据UsersId查询优惠券
        /// </summary>
        /// <returns></returns>
        [HttpGet("Getcouponlist")]
        public CouponDto Getcouponlist(int id, int pageIndex, int pageSize)
        {
            return _CouponRepository.Getcouponlist(id, pageIndex, pageSize);
        }

        /// <summary>
        /// 领取优惠券
        /// </summary>
        /// <param name="shopCart"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Insertcoupon")]
        public int Insertcoupon([FromBody]Coupon coupon)
        {
            return _CouponRepository.Insertcoupon(coupon);
        }
    }
}