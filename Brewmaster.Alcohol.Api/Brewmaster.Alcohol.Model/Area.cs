using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    //地区
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName
        {
            get; set;
        }
        /// <summary>
        /// 父级Id
        /// </summary>
        public int  Pid
        {
            get; set;
        }
    }
}
