using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model.Dto.订单Dto
{
    /// <summary>
    /// 分页显示
    /// </summary>
    public class IndentPageList
    {
        public List<IndentDto> IndentPageListShow { get; set; }
        public int Total { get; set; }
    }
}
