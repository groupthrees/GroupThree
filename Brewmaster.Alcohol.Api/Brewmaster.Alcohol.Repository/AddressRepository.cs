using System;
using System.Collections.Generic;
using System.Text;

using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace Brewmaster.Alcohol.Repository
{
    /// <summary>
    /// 收货地址的实现接口层
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int AddAddress(Address address)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("insert into address(Id,AddressPerson,AreaId,UsersId,DetailAddress,PostalCode,AddressPhone) values(null,'{0}',{1},{2},'{3}','{4}','{5}')",address.AddressPerson,address.AreaId,address.UsersId,address.DetailAddress,address.PostalCode,address.AddressPhone);
                int result = conn.Execute(sql);
                return result;
            }
        }


        /// <summary>
        /// 绑定地区
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Area> GetAreaList(int pid)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select * from Area where pid={0}", pid);
                var areaList = conn.Query<Area>(strSql1).ToList();
                return areaList;
            }
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelAddress(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("delete  from address where Id={0}", id);
                int result = conn.Execute(strSql1);
                return result;
            }
        }

        /// <summary>
        /// 反填地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address GetAddressById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select  AddressPerson,DetailAddress,AddressPhone from address where Id={0}", id);
                var result = conn.Query<Address>(strSql1).SingleOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int UpdateAddress(Address address)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("update address  set AddressPerson='{0}',DetailAddress='{1}',AddressPhone='{2}' where Id={3}", address.AddressPerson, address.DetailAddress, address.AddressPhone, address.Id);
                int result = conn.Execute(sql);
                return result;
            }
        }

        /// <summary>
        /// 显示所有地址
        /// </summary>
        /// <returns></returns>
        public List<Address> GetAddressesList()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select  Id,AddressPerson,DetailAddress,AddressPhone from address";
                var result = conn.Query<Address>(sql).ToList();
                return result;
            }
        }






     
    }
}
