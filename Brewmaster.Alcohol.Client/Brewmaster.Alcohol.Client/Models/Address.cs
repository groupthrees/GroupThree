using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 收货地址表
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 收货人
        /// </summary>
        public string AddressPerson
        {
            get; set;
        }
        /// <summary>
        /// 地区Id（外键）
        /// </summary>
        public int AreaId
        {
            get; set;
        }
        /// <summary>
        /// 用户Id（外键）
        /// </summary>
        public int UsersId
        {
            get; set;
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress
        {
            get; set;
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode
        {
            get; set;
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string AddressPhone
        {
            get; set;
        }
    }
}
