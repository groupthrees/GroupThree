using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 品牌表
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 品牌名
        /// </summary>
        public string BrandName
        {
            get; set;
        }
        /// <summary>
        /// 商品类型Id
        /// </summary>
        public int GoodsTypeId
        {
            get; set;
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId
        {
            get; set;
        }
    }
}
