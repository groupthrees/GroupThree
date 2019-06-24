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
    public class AromaRepository: IAromaRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        /// 查询商品香型
        /// </summary>
        /// <returns></returns>
        public List<Aroma> GetAroma()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select * from Aroma";
                var result = conn.Query<Aroma>(sql).ToList();
                return result;
            }
        }
    }
}
