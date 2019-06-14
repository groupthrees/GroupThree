using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto.订单Dto;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.个人中心
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndentController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IIndentRepository _indentRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public IndentController(IIndentRepository IndentRepository)
        {
            _indentRepository = IndentRepository;
        }
        [HttpGet("GetIndentPageList")]
        public IndentPageList GetIndentPageList(int orderSite, int userId, int pageIndex = 1, int pageSize = 3)
        {
            var list = _indentRepository.GetIndentPageList(orderSite, userId, pageIndex, pageSize);
            return list;
        }
    }
}