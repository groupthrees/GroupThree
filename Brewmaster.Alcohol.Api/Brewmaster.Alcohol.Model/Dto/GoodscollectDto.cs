using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    //商品详情页 Dto
    /// <summary>
    /// 详情页 dto
    /// </summary>
    public class Picture_carousel
    {
        public List<img> Imgs;
        public int Conllect { get; set; }
    }
    public class img
    {
        public string Image_Url { get; set; }
    }
}
