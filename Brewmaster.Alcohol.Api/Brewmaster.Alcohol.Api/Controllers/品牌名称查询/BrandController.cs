using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto.搜索商品Dto;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Api.Controllers.品牌名称查询
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IBrandRepository _brandRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public BrandController(IBrandRepository BrandRepository)
        {
            _brandRepository = BrandRepository;
        }

        /// <summary>
        /// 查询品牌名称
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetBrandName()
        {
            var list = _brandRepository.GetBrandName();
            return list;
        }
    }
}