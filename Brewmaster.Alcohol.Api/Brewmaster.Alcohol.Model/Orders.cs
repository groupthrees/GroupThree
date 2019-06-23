using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 订单表 dto
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        {
            get; set;
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderSite
        {
            get; set;
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? OrderDate
        {
            get; set;
        }
        /// <summary>
        ///  订单金额
        /// </summary>
        public string OrderMoney
        {
            get; set;
        }
        /// <summary>
        /// 实际支付金额
        /// </summary>
        public string PracticalMoney
        {
            get; set;
        }
        /// <summary>
        /// 订单地址id
        /// </summary>
        public int addressId { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string ApplyMethod { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public string CouponMoney { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 商品（多个）id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 购买数量（多个）
        /// </summary>
        public string BuyNums { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public string Price { get; set; }
    }
}
