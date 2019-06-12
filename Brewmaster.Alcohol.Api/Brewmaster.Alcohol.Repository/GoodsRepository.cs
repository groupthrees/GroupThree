using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Brewmaster.Alcohol.Repository
{



    public class GoodsRepository:IGoodsRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=wangsenyu;Pwd=123456;";


        public List<GoodsDto> getGoodslist()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var sql = "select * from goods join price on goods.Id=price.Goodsid join picture on goods.Id=picture.Goodsid";
                var query = conn.Query<GoodsDto>(sql).ToList();
                return query;

            }
        }
    }
}
