using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model.Dto.订单Dto;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IIndentRepository
    {
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <param name="orderSite"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IndentPageList GetIndentPageList(int orderSite,int userId,int pageIndex,int pageSize);

    }
}
