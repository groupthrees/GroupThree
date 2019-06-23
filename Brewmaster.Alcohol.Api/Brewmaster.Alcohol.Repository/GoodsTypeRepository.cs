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
    public class GoodsTypeRepository : IGoodsTypeRepository
    {

        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        /// 查询一级商品名称
        /// </summary>
        /// <returns></returns>
        public List<GoodsType> GetGoodsTypeName()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select * from GoodsType";
                var result = conn.Query<GoodsType>(sql).ToList();
                return result;
            }
        }
    }
}
