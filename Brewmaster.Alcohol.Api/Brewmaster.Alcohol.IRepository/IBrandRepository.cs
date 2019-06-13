using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;

namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 品牌表
    /// </summary>
    public interface IBrandRepository
    {
        /// <summary>
        /// 品牌表查询
        /// </summary>
        /// <returns></returns>
        List<Brand> GetBrandName();
    }
}
