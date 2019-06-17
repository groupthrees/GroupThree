using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.收藏表
{
    public class CollectionDto
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int Id
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
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UsersId
        {
            get; set;
        }

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
