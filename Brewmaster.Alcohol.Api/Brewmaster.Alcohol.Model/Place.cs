using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    ///  商品产地表
    /// </summary>

    public class Place
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 产地名称
        /// </summary>
        public string PlaceName
        {
            get; set;
        }
        /// <summary>
        /// 商品类型ID
        /// </summary>
        public int GoodsTypeId
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
    }
}
