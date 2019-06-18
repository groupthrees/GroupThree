using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.IRepository;

namespace Brewmaster.Alcohol.Api.Controllers.收货地址
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IAddressRepository  _addressRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="addressRepository"></param>
        public AddressController(IAddressRepository  addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("AddAddress")]
        public int AddAddress([FromBody]Address address)
        {
            int result = _addressRepository.AddAddress(address);
            return result;
        }

        /// <summary>
        /// 显示所有地址
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAddressesList")]
        public List<Address> GetAddressesList()
        {
            var result = _addressRepository.GetAddressesList();
            return result;
        }

        /// <summary>
        /// 绑定地区
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("GetAreaList")]
        public List<Area> GetAreaList(int pid)
        {
            var arealist = _addressRepository.GetAreaList(pid);
            return arealist;
        }


        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DelAddress")]
        public int DelAddress(int id)
        {
            int result = _addressRepository.DelAddress(id);
            return result;
        }

        /// <summary>
        /// 反填地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAddressById")]
        public Address GetAddressById(int id)
        {
            var result = _addressRepository.GetAddressById(id);
            return result;
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("UpdateAddress")]
        public int UpdateAddress([FromBody]Address address)
        {
            int result = _addressRepository.UpdateAddress(address);
            return result;
        }


    }
}