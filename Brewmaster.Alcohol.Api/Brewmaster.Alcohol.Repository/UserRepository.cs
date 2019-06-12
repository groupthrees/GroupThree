using System;

using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace Brewmaster.Alcohol.Repository
{
    /// <summary>
    /// 用户实现接口层
    /// </summary>
    public class UserRepository : UserIRepository
    {

        //数据库连接
        private static string connStr = "Server=127.0.0.1;Database=tvData;Uid=root;Pwd=root;";

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int Resigt(Users users)
        {
           
        }
    }
}
