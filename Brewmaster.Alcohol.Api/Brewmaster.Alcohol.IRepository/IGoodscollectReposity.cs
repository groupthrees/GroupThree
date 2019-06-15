using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 商品详情页接口
    /// </summary>
 public   interface IGoodsCollectReposity
    {
        /// <summary>
        /// 商品详情页显示
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        GoodscollectDto GetGoodscollectDto(int id,int goodsId);
        int SetCollect(int goodsId, int userId);
    }
}
