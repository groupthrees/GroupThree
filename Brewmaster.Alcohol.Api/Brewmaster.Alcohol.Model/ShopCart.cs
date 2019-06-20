using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShopCart
    {
        public int Id { get; set; }

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

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Num
        {
            get; set;
        }
    }
}
