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
        [HttpGet("Login")]
        public List<Users> Login(string UsersName, string UsersPwd)
        {
            var result = _UserRepository.Login(UsersName, UsersPwd);
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

        /// <summary>
        /// 验证表添加数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost("AddCode")]
        public string AddCode([FromBody] Code code)
        {
            string result = _UserRepository.AddCode(code);
            return result;
        }

        /// <summary>
        /// 跳转到修改密码界面
        /// </summary>
        /// <param name="usersName"></param>
        /// <param name="codeNumber"></param>
        /// <returns></returns>
        [HttpPost("LocationToPwd")]
        public object LocationToPwd(string usersName, string codeNumber)
        {
            object result = _UserRepository.LocationToPwd(usersName, codeNumber);
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="usersPwd"></param>
        /// <param name="usersName"></param>
        /// <returns></returns>
        [HttpPost("UpdatePwd")]
        public int UpdatePwd(string usersPwd, string usersName)
        {
            int resule = _UserRepository.Update(usersPwd, usersName);
            return resule;
        }

        /// <summary>
        /// 验证手机号码是否存在
        /// </summary>
        /// <param name="usersName"></param>
        /// <returns></returns>
        [HttpGet("IsNotUserTel")]
        public object IsNotUserTel(string usersName)
        {
            object result = _UserRepository.IsNotUserTel(usersName);
            return result;
        }
    }
}