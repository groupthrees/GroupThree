using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 订单表
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
    }
}
