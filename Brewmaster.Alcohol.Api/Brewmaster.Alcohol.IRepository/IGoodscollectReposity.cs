using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 商品详情页接口
    /// </summary>
 public   interface IGoodscollectReposity
    {
        /// <summary>
        /// 商品详情页显示
        /// </summary>
        /// <returns></returns>
        GoodscollectDto GetGoodscollectDto();
    }
}
