using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models.Dto.订单Dto
{

    /// <summary>
    /// 订单显示Dto
    /// </summary>
    public class IndentDto
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int OrderSite { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderMoney { get; set; }
        public string PracticalMoney { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImg { get; set; }
        public int UsersId { get; set; }

    }
}
