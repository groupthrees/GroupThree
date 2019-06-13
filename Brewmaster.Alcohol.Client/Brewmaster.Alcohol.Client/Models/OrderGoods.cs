using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 订单商品关联表
    /// </summary>
    public class OrderGoods
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodId
        {
            get; set;
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrdersId
        {
            get; set;
        }
    }
}
