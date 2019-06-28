using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewmaster.Alcohol.Back.Models
{
    /// <summary>
    /// 用户实体对象类
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Permission> PermissionList { get; set; }
    }

    /// <summary>
    /// 权限实体对象类
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
        public int Pid { get; set; }
    }
}
