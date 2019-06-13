using System;

using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
namespace Brewmaster.Alcohol.Repository
{
    /// <summary>
    /// 用户实现接口层
    /// </summary>
    public class UserRepository : IUserRepository
    {

        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=wangsenyu;Pwd=123456;";

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int Resigt(Users users)
        {
            using (MySqlConnection conn =new MySqlConnection(connStr))
            {
                string sql = string.Format("insert into Users(UsersName,UsersPwd)  values ('{0}','{1}')",users.UsersName,users.UsersPwd);
                var result = conn.Execute(sql);
                return result;
            }
        }
    }
}
