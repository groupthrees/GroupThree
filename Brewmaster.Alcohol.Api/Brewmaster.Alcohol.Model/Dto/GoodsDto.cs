using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto
{
    public class GoodsDto
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

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PictureUrl
        {
            get; set;
        }
        /// <summary>
        /// 原价
        /// </summary>
        public int PriceOld
        {
            get; set;
        }
        /// <summary>
        /// 现价
        /// </summary>
        public int PriceNow
        {

            get; set;
        }
    }
}
