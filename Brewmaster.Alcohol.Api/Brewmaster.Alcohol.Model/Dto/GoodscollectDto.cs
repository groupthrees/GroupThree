using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    //商品详情页 Dto
    /// <summary>
    /// 详情页 dto
    /// </summary>
    public class GoodscollectDto
    {
        //图片
        public List<img> Imgs;
        //是否收藏
        public int Conllect { get; set; }
        //商品详情页Model
        public GoodsDto1 Goods { get; set; }
    }
    public class img
    {
        public string Image_Url { get; set; }
    }
    public class GoodsDto1
    {
        public int id { get; set; }
        public string GoodsName { get; set; }
        public int GoodsDegree { get; set; }
        public string GoodsImg { get; set; }
        public string AromaName { get; set; }
        public string PlaceName { get; set; }
        public string BrandName { get; set; }
    }
}
