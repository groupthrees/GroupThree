using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.Model;
using MySql.Data.MySqlClient;

namespace Brewmaster.Alcohol.Repository
{

    public class GoodsRepository : IGoodsRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public List<GoodsDto> getGoodslist()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                var sql = "select * from goods join price on goods.Id=price.Goodsid";
                var query = conn.Query<GoodsDto>(sql).ToList();
                return query;
            }
        }

    }

}
