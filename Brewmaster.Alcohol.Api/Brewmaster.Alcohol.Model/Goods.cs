using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    public class Goods
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get; set;
        }
        /// <summary>
        /// 商品度数
        /// </summary>
        public int GoodsDegree
        {
            get; set;
        }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsImg
        {
            get; set;
        }
    }
}
