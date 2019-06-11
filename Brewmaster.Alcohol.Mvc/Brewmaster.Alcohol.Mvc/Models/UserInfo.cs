using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewmaster.Alcohol.Mvc.Models
{

        /// <summary>
        /// 用户实体对象类
        /// </summary>
        public class UserInfo
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public List<Permission> PermissionList { get; set; }

            public UserInfo()
            {

            }

            public UserInfo(string username, string password)
            {
                this.UserName = username;
                this.Password = password;
            }

            /// <summary>
            /// 模拟权限列表数据
            /// </summary>
            private List<Permission> Permissions => new List<Permission>() {
                            new Permission { Id = 1, Name = "Contact",Url="/home/contact"},
                            new Permission { Id = 2, Name = "Privacy",Url="/home/Members"}
                        };

            /// <summary>
            /// 模拟用户数据
            /// </summary>
            /// <returns></returns>
            public List<UserInfo> GetUserList()
            {
                var Users = new List<UserInfo>() {
                            new UserInfo { UserName = "qqq", Password = "111",PermissionList=Permissions },
                            new UserInfo{ UserName = "www", Password = "111" ,PermissionList=Permissions }
                        };
                return Users;
            }
        }

        /// <summary>
        /// 权限实体对象类
        /// </summary>
        public class Permission
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }
        }
    }

