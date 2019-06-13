using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 收藏表
    /// </summary>
    public class Collection
    {
        /// <summary>
		/// 商品ID
		/// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId
        {
            get; set;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UsersId
        {
            get; set;
        }
    }
}
