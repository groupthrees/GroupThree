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


        /// <summary>
        /// 绑定区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Area> GetAreaList(int id);


        /// <summary>
        /// 显示所有地址
        /// </summary>
        /// <returns></returns>
        List<Address> GetAddressesList();


        /// <summary>
        /// 反填地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Address GetAddressById(int id);


        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        int UpdateAddress(Address address);


        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelAddress(int id);


    }
}
