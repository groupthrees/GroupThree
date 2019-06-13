using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.Model;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IPlaceRepository
    {
        /// <summary>
        /// 查询产地
        /// </summary>
        /// <returns></returns>
        List<Place> GetPlaceName();
    }
}
