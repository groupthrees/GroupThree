using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Brewmaster.Alcohol.Repository
{
    public class BrandRepository : IBrandRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=fantaotao;Pwd=123456;";

        /// <summary>
        /// 查询品牌名称
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetBrandName()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select BrandName from Brand";
                var result = conn.Query<Brand>(sql).ToList();
                return result;
            }
        }
    }
}
