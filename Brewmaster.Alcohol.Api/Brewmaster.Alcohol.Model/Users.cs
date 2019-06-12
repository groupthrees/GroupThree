using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Model
{
    public class Users
    {
        /// <summary>
		/// 主键Id
		/// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        ///用户名称
        /// </summary>
        public string UsersName
        {
            get; set;
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UsersPwd
        {
            get; set;
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UsersNickname
        {
            get; set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UsersRealName
        {
            get; set;
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int UsersSex
        {
            get; set;
        }
        /// <summary>
        /// 生日
        /// </summary>
        public string UsersBirthday
        {
            get; set;
        }
        /// <summary>
        ///  详细地址
        /// </summary>
        public string UsersDetailedAddress
        {
            get; set;
        }
        /// <summary>
        /// 地区id(外键）
        /// </summary>
        public int UsersAreaId
        {
            get; set;
        }
        /// <summary>
        /// 头像Url
        /// </summary>
        public string UsersHeadPortrait
        {
            get; set;
        }

    }
}
