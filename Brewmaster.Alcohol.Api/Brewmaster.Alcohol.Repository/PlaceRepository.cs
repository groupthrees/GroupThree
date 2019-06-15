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
    public class PlaceRepository : IPlaceRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        /// <summary>
        /// 查询商品产地
        /// </summary>
        /// <returns></returns>
        public List<Place> GetPlaceName()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "select * from Place";
                var result = conn.Query<Place>(sql).ToList();
                return result;
            }
        }
    }
}
