using System;

using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;

namespace Brewmaster.Alcohol.Repository
{
    /// <summary>
    /// 用户实现接口层
    /// </summary>
    public class UserRepository : IUserRepository
    {

        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int AddUser(Users users)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("insert into users(Id,UsersName,UsersNickname,UsersRealName,UsersSex,UsersBirthday,UsersAreaId,UsersHeadPortrait,UsersDetailedAddress) values(null,'{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}')",users.UsersName, users.UsersNickname, users.UsersRealName, users.UsersSex, users.UsersBirthday, users.UsersAreaId,users.UsersHeadPortrait,users.UsersDetailedAddress);
                int result = conn.Execute(sql);
                return result;
            }
        }

        /// <summary>
        /// 添加验证码表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string AddCode(Code code)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                Random rn=new Random();
                string str = "";
                for (int i = 0; i < 6; i++)
                {
                  str+=rn.Next(0,10);                    
                }
                string sql =
                    string.Format(
                        "insert into codes(Id,usersName,codeNumber) values(null,'{0}','{1}')",
                        code.UserName,str);
                int result = conn.Execute(sql);
                if (result == 1)
                {
                    return str;
                }
                return "失败";
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public List<Users> Login(string UsersName, string UsersPwd)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("select * from Users where UsersName='{0}' and UsersPwd='{1}'", UsersName,UsersPwd);
                //var result = Convert.ToInt32( conn.ExecuteScalar<int>(sql));


                var result = conn.Query<Users>(sql).ToList();
                if (result == null)
                {
                    return new List<Users>();
                }

                return result;
            }
        }

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

        /// <summary>
        /// 验证手机号与验证码跳转到修改密码界面
        /// </summary>
        /// <param name="usersName"></param>
        /// <param name="codeNumber"></param>
        /// <returns></returns>
        public object LocationToPwd(string usersName, string codeNumber)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("select count(1) from codes where usersName='{0}' and codeNumber='{1}'", usersName, codeNumber);
                object result = conn.ExecuteScalar(sql);
                return result;
            }
        }

        /// <summary>
        /// 通过输入手机号查询并修改对应密码
        /// </summary>
        /// <param name="usersPwd"></param>
        /// <param name="usersName"></param>
        /// <returns></returns>
        public int Update(string usersPwd,string usersName)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("Update users set UsersPwd='{0}' where UsersName='{1}'", usersPwd, usersName);
                int result = conn.Execute(sql);
                return result;
            }
        }

        /// <summary>
        /// 验证手机号码是否存在
        /// </summary>
        /// <param name="usersName"></param>
        /// <returns></returns>
        public object IsNotUserTel(string usersName)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = string.Format("select count(1) from users where usersName='{0}'", usersName);
                object result = conn.ExecuteScalar(sql);
                return result;
            }
        }

    }
}
