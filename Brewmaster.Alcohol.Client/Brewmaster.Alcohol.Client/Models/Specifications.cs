using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{

    /// <summary>
    /// 商品规格表
    /// </summary>
    public class Specifications
    {
        /// <summary>
		/// 主键Id
		/// </summary>
        public int id
        {
            get; set;
        }
        /// <summary>
        ///商品规格
        /// </summary>
        public string SpecificationsName
        {
            get; set;
        }
        /// <summary>
        /// 商品Id(外键)
        /// </summary>
        public int GoodsId
        {
            get; set;
        }
    }
}
