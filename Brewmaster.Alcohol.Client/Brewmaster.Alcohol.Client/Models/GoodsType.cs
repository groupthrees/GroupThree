using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 商品类型名称
        /// </summary>
        public string TypeName
        {
            get; set;
        }
    }
}
