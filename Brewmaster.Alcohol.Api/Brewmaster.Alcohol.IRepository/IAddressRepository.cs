using System;
using System.Collections.Generic;
using System.Text;

using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    /// <summary>
    /// 收货地址接口
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        int AddAddress(Address address);
    }
}
