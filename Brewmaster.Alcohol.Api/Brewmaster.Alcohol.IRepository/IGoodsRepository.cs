using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;

using Brewmaster.Alcohol.Model.Dto;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IGoodsRepository
    {
        /// <summary>
        /// 显示商品
        /// </summary>
        /// <returns></returns>
        List<GoodsDto> getGoodslist();

        //List<GoodsDto> GetGoodsById
    }
}
