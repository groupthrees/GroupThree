using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.我的购物车
{
    public class ShopCartPageList
    {
        public List<ShopCartDto> ShopCartList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
    }
}
