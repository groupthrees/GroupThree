using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    //商品详情页 Dto
    public class GoodscollectDto
    {
        //是否收藏
        public int IsCollect { get; set; }
        //下方图片放大
        public imgs img { get; set; }
    }
  public  class imgs
    {

        public List<string> img { get; set; }
    }
}
