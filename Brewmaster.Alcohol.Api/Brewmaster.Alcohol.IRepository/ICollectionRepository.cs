using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model.Dto.收藏表;
using Brewmaster.Alcohol.Model.Dto.订单Dto;

namespace Brewmaster.Alcohol.IRepository
{
    public interface ICollectionRepository
    {
        /// <summary>
        /// 根据UserId,GoodsId查询收藏的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
         CollectionPageList GetCollectionlist(int id, int pageIndex, int pageSize);

    }
}
