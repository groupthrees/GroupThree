using System;
using System.Collections.Generic;
using System.Text;

using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        int Resigt(Users users);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        object Login(string UserName, string UserPwd);

        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        int AddUser(Users users);

        /// <summary>
        /// 添加验证码表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string AddCode(Code code);

        /// <summary>
        /// 验证手机号与验证码跳转到修改密码界面
        /// </summary>
        /// <param name="usersName"></param>
        /// <param name="codeNumber"></param>
        /// <returns></returns>
        object UpdatePwd(string usersName, string codeNumber);
        
    }
}
