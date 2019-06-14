using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.收藏表
{
    public class CollectionPageList
    {
        public List<CollectionDto> GetCollectionDto { get; set; }
        public int total { get; set; }

    }
}
