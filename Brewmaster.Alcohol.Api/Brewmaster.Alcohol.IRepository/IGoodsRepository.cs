using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IGoodsRepository
    {
        /// <summary>
        /// 商品按条件查询/显示/分页
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <param name="typeName">商品类型</param>
        /// <param name="goodsDegree">商品度数</param>
        /// <param name="priceNow">商品现价</param>
        /// <param name="brandName">品牌名称</param>
        /// <param name="placeName">商品产地</param>
        /// <param name="aromaName">商品香型</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<Goods> GetGoodsAll(string goodsName, string goodsDegree, int priceNow, string brandName,
            string placeName, string aromaName, int pageIndex, int pageSize, ref int totalCount);

    }
}
