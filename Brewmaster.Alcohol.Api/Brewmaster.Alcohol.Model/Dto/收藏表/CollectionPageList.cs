using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.收藏表
{
    public class CollectionPageList
    {
        public List<CollectionDto> CollectionList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }

    }
}
