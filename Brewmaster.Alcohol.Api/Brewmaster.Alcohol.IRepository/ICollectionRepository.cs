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
        /// 收藏界面借口
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        CollectionPageList GetCollectionPageList(int pageIndex,int pageSize);

    }
}
