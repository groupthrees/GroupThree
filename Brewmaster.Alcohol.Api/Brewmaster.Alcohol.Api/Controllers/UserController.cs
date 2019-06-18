﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Repository;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IUserRepository _UserRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("Resigt")]
        public int Resigt([FromBody]Users users)
        {
            int result = _UserRepository.Resigt(users);
            return result;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public object Login(string UsersName, string UsersPwd)
        {
            object result = _UserRepository.Login(UsersName, UsersPwd);
            return result;
        }

        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public int AddUser([FromBody]Users users)
        {
            int result = _UserRepository.AddUser(users);
            return result;
        }

        ///// <summary>
        ///// 验证表添加数据
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //[HttpPost("AddCode")]
        //public int AddCode([FromBody] Code code)
        //{
        //    int result = _UserRepository.AddCode(code);
        //    return result;
        //}
    }
}