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
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int OrderSite { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string OrderMoney { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public string PracticalMoney { get; set; }
        /// <summary>
        /// 商品名称 
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string AddressPerson { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UsersId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public List<string> imgs { get; set; }

    }
}
