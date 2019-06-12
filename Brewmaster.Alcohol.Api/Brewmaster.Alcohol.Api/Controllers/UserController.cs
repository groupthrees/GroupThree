using System;
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
    [Route("api/[controller]/[action]")]
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
        [HttpPost]
        public int Resigt(Users users)
        {
            int result = _UserRepository.Resigt(users);
            return result;
        }
    }
}