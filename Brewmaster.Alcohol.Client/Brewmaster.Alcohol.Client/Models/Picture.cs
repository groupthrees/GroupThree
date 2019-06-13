using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 图片表
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int id
        {
            get; set;
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PictureUrl
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
