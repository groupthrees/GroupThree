﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.订单Dto
{
    public class orderImg
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int ordersid { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int id { get; set; }
    }
}
