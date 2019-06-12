using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    /// <summary>
    /// 日志表
    /// </summary>
    public class Journal
    {
        /// <summary>
		/// 主键ID
		/// </summary>
        public int Id
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
        /// 用户进行的操作
        /// </summary>
        public int Operation
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTiem
        {
            get; set;
        }
    }
}
