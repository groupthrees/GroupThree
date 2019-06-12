using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 香型表
    /// </summary>
    public class Aroma
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 香型名称
        /// </summary>
        public string AromaName
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
