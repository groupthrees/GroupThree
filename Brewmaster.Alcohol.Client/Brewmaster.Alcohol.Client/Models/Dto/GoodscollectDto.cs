using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models.Dto
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
        public Goods Goods { get; set; }
    }
    public class img
    {
        public string Image_Url { get; set; }
    }
}
