﻿using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto.搜索商品Dto;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IGoodsAllRepository
    {
        /// <summary>
        /// 商品按条件查询/显示/分页
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsDegree">商品度数</param>
        /// <param name="priceNow">商品现价</param>
        /// <param name="brandName">品牌名称</param>
        /// <param name="placeName">商品产地</param>
        /// <param name="aromaName">商品香型</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GoodsAllListPage GetGoodsAll(string goodsName, string goodsDegree, int priceNow, string brandName, string placeName, string aromaName, int typeId, int brandId, int pageIndex, int pageSize);

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteGoods(int id);


    }
}
