using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto
{
    /// <summary>
    /// 搜素框输入对应条件所查询的商品
    /// </summary>
    public class GoodsAll
    {
        public int Id { get; set; }
        public string GoodsName { get; set; }
        public string TypeName { get; set; }
        public string GoodsDegree { get; set; }
        public int PriceNow { get; set; }
        public string BrandName { get; set; }
        public string PlaceName { get; set; }
        public string AromaName { get; set; }
        public string GoodsImg { get; set; }

    }
}
