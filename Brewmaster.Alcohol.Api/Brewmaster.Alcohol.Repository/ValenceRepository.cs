using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brewmaster.Alcohol.Repository
{
    /// <summary>
    /// 商品价位
    /// </summary>
    public class ValenceRepository: IValenceRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";


        /// <summary>
        /// 查询商品价位
        /// </summary>
        /// <returns></returns>
        public List<Valence> GetValence()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select * from Valence";
                var result = conn.Query<Valence>(sql).ToList();
                return result;
            }
        }
    }
}
