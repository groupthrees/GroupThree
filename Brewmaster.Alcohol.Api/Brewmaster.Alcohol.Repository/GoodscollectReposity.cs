using System;
using System.Collections.Generic;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Dapper;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Brewmaster.Alcohol.Repository
{
    public class GoodscollectReposity : IGoodsCollectReposity
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";
        /// <summary>
        /// 商品详情页显示
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public  GoodscollectDto GetGoodscollectDto(int id, int goodsId)
        {
            GoodscollectDto goodscollectDto = new GoodscollectDto();
            //是否收藏
            string sql1 = $"select * from collection where GoodsId={goodsId} and UsersId={id}";
            //根据商品Id查询该商品的图片
            string sql2 = $"select pictureUrl from picture where GoodsId={goodsId} ";
            string sql3 = $@"select goods.*,Aroma.AromaName,place.PlaceName,brand.BrandName from goods 
                            join price on goods.Id = price.Goodsid
                            join Aroma ON Aroma.GoodsId = goods.Id
                            join Place on Place.GoodsId = goods.Id
                            join brand on brand.GoodsId = goods.Id  where goods.id={goodsId} ";
            using (MySqlConnection con=new MySqlConnection(connStr))
            {
                goodscollectDto.Conllect = con.ExecuteScalar<int>(sql1);
                goodscollectDto.Imgs = con.Query<img>(sql2).ToList();
                goodscollectDto.Goods = con.QueryFirst<GoodsDto1>(sql3);
            }
            return goodscollectDto;
        }
        /// <summary>
        /// 添加收藏；返回1为收藏；返回2为取消收藏
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>     
        public int SetCollect(int goodsId, int userId)
         {
            using (MySqlConnection Conn =new MySqlConnection(connStr))
            {
                    var result = 1;
                    var sql = $"select * from collection where goodsId={goodsId} and usersId={userId}";
                    var query = Conn.ExecuteScalar<int>(sql);
                    if (query > 0)
                    {
                        result = 2;
                        sql = "delete from collection where usersId=" + userId + " and  goodsId=" + goodsId;
                    }
                    else
                    {
                        sql = $@"insert into collection (usersId,goodsId) values('{userId}','{goodsId}')";
                    }
                    Conn.Execute(sql);
                    return result;
             }
         }

    }
}
