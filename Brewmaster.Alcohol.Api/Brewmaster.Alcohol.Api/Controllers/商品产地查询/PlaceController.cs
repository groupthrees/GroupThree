using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.商品产地查询
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IPlaceRepository _placeRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public PlaceController(IPlaceRepository PlaceRepository)
        {
            _placeRepository = PlaceRepository;
        }

        /// <summary>
        /// 查询品牌名称
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("GetPlaceName")]
        public List<Place> GetPlaceName()
        {
            var list = _placeRepository.GetPlaceName();
            return list;
        }
    }
}