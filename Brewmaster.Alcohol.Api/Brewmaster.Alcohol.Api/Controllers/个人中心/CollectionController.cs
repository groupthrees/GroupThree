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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ICollectionRepository _collectionRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public CollectionController(ICollectionRepository CollectionRepository)
        {
            _collectionRepository = CollectionRepository;
        }
        [HttpGet("GetCollectionPageList")]
        public CollectionPageList GetCollectionPageList(int pageIndex = 1, int pageSize = 3)
        {
            var list = _collectionRepository.GetCollectionPageList(pageIndex, pageSize);
            return list;
        }
    }
}