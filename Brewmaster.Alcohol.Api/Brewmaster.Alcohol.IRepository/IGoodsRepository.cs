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
        /// <param name="goodsName"></param>
        /// <param name="typeName"></param>
        /// <param name="goodsDegree"></param>
        /// <param name="priceNow"></param>
        /// <param name="brandName"></param>
        /// <param name="placeName"></param>
        /// <param name="aromaName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<Goods> GetGoodsAll(string goodsName, string typeName, string goodsDegree, int priceNow, string brandName,
            string placeName, string aromaName, int pageIndex, int pageSize, ref int totalCount);

    }
}
