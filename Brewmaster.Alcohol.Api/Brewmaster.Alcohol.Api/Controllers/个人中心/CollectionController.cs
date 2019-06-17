using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto.收藏表;
using Brewmaster.Alcohol.Model.Dto.订单Dto;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.个人中心
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ICollectionRepository _CollectionRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public CollectionController(ICollectionRepository CollectionRepository)
        {
            _CollectionRepository = CollectionRepository;
        }

        /// <summary>
        /// 根据UserId,GoodsId查询收藏的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetCollectionlist")]
        public CollectionPageList GetCollectionlist(int id, int pageIndex, int pageSize)
        {
            return _CollectionRepository.GetCollectionlist(id, pageIndex, pageSize);
        }
    }
}