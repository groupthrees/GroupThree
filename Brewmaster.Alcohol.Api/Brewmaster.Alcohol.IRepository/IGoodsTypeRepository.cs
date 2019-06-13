using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;

namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 一级商品表
    /// </summary>
    public interface IGoodsTypeRepository
    {
        List<GoodsType> GetGoodsTypeName();
    }
}
