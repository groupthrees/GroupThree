using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ITestRepository _TestRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public DefaultController(ITestRepository TestRepository)
        {
            _TestRepository = TestRepository;
        }
        [HttpGet]
        public int Get(int id)
        {
            return _TestRepository.test(id);
        }
    }
}