using Brewmaster.Alcohol.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IAromaRepository
    {
        /// <summary>
        /// 商品香型
        /// </summary>
        /// <returns></returns>
        List<Aroma> GetAroma();
    }
}
