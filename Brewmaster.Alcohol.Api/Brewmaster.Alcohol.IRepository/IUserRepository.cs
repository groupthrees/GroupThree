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
    }
}
