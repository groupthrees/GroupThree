using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{

    /// <summary>
    /// 价位表
    /// </summary>
    public class Valence
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 最小价格
        /// </summary>
        public int MinValence
        {
            get; set;
        }
        /// <summary>
        /// 最大价格
        /// </summary>
        public int MaxValence
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
        /// 商品Id
        /// </summary>
        public int GoodsId
        {
            get; set;
        }
    }
}
