using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Client.Models
{
    /// <summary>
    /// 商品评价表
    /// </summary>
    public class Evaluate
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 评价名称
        /// </summary>
        public string EvaluateName
        {
            get; set;
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId
        {
            get; set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UsersId
        {
            get; set;
        }
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime EvaluateTime
        {
            get; set;
        }
    }
}
