using Brewmaster.Alcohol.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 商品价位
    /// </summary>
    public interface IValenceRepository
    {
        /// <summary>
        /// 品牌表查询
        /// </summary>
        /// <returns></returns>
        List<Valence> GetValence();
    }
}
