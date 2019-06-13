using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 商品价格表
    /// </summary>
    public class Price
    {
        /// <summary>
		/// 主键Id
		/// </summary>
        public int id
        {
            get; set;
        }
        /// <summary>
        /// 原价
        /// </summary>
        public int PriceOld
        {
            get; set;
        }
        /// <summary>
        /// 现价
        /// </summary>
        public int PriceNow
        {
            get; set;
        }
        /// <summary>
        /// 商品Id(外键)
        /// </summary>
        public int Goodsid
        {
            get; set;
        }
    }
}
