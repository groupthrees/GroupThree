using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace Brewmaster.Alcohol.Repository
{
    public class GoodscollectReposity : IGoodsCollectReposity
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=wangsenyu;Pwd=123456;";
        /// <summary>
        /// 商品详情页显示
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public  GoodscollectDto GetGoodscollectDto(int id, int goodsId)
        {
            //是否收藏
            string sql1 = $"select * from collect where GoodsId={goodsId} and UserId={id}";
            //根据商品Id查询该商品的图片
            string sql2 = $"select pictureUrl from prcture where GoodsId={goodsId} ";
            string sql3 = $"select * from ";
            using (MySqlConnection con=new MySqlConnection(connStr))
            {

            }
            return null;
        }

    }
}
