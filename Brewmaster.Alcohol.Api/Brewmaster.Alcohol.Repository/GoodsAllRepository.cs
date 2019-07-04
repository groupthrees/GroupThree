using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
using Brewmaster.Alcohol.Model.Dto;
using Brewmaster.Alcohol.Model.Dto.搜索商品Dto;
using Dapper;
using MySql.Data.MySqlClient;
namespace Brewmaster.Alcohol.Repository
{
    public class GoodsAllRepository : IGoodsAllRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGoods(int id)
        {
            GoodsAllListPage goodsAllListPage = new GoodsAllListPage();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "delete from Goods where Id=" + id;
                int i = conn.Execute(sql, null);
                return i;
            }
        }

        /// <summary>
        /// 商品查询显示分页
        /// </summary>
        /// <param name="goodsName"></param>
        /// <param name="goodsDegree"></param>
        /// <param name="priceNow"></param>
        /// <param name="brandName"></param>
        /// <param name="placeName"></param>
        /// <param name="aromaName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GoodsAllListPage GetGoodsAll(string goodsName, string goodsDegree, int priceNow, string brandName, string placeName, string aromaName, int typeId, int brandId, int pageIndex, int pageSize)
        {
            GoodsAllListPage goodsAllListPage = new GoodsAllListPage();
            using (MySqlConnection conn = new MySqlConnection(connStr))

            {
                var orderByPriceSql = "";
                string sql = "select Goods.Id,Brand.Id as BrandId,GoodsType.Id as GoodsTypeId,GoodsName,PriceNow,GoodsImg ,BrandName, PlaceName,AromaName ,TypeName ,SpecificationsName from Goods inner join Price on Goods.Id=Price.GoodsId inner join Brand on Brand.GoodsId = Goods.Id inner join Place on Place.GoodsId = Goods.Id inner join Aroma on Aroma.GoodsId = Goods.Id inner join GoodsType on Place.GoodsTypeId = GoodsType.Id inner join specifications on Specifications.GoodsId=Goods.Id where 1 =1";
                string sqlCount =
                    "select count(Goods.Id) from Goods inner join Price on Goods.Id=Price.GoodsId  inner join Brand on   Goods.Id = Brand.GoodsId inner join Place on   Goods.Id = Place.GoodsId inner join Aroma on  Goods.Id = Aroma.GoodsId inner join GoodsType on Place.GoodsTypeId = GoodsType.Id inner join specifications on Specifications.GoodsId=Goods.Id where 1=1";
                if (!string.IsNullOrWhiteSpace(goodsName))
                {
                    sql = sql + $" and GoodsName like '%{goodsName}%'";
                    sqlCount = sqlCount + $" and GoodsName like '%{goodsName}%'";
                }
                if (!string.IsNullOrWhiteSpace(goodsDegree))
                {
                    sql = sql + $" and GoodsDegree like '%{goodsDegree}%'";
                    sqlCount = sqlCount + $" and GoodsDegree like '%{goodsDegree}%'";
                }
                if (!string.IsNullOrWhiteSpace(brandName))
                {
                    sql = sql + $" and BrandName like '%{brandName}%'";
                    sqlCount = sqlCount + $" and BrandName like '%{brandName}%'";
                }
                if (!string.IsNullOrWhiteSpace(placeName))
                {
                    sql = sql + $" and PlaceName like '%{placeName}%'";
                    sqlCount = sqlCount + $" and PlaceName like '%{placeName}%'";
                   }
                if (brandId != 0)
                {
                    sql = sql + $" and Brand.Id={brandId}";
                    sqlCount = sqlCount + $" and Brand.Id={brandId}";
                }
                if (typeId != 0)
                {
                    sql = sql + $" and GoodsType.Id={typeId}";
                    sqlCount = sqlCount + $" and GoodsType.Id={typeId}";
                }

                switch (priceNow)
                {
                    case 123: orderByPriceSql += "select * from(" + sql + ") t order by PriceNow desc"; break;
                    case 456: orderByPriceSql += "select * from(" + sql + ") t order by PriceNow"; break;
                    case 789: orderByPriceSql += sql; break;
                }
                orderByPriceSql = orderByPriceSql + $" limit {(pageIndex - 1) * pageSize},{pageSize}";
                var result = conn.Query<GoodsAll>(orderByPriceSql).ToList();
                goodsAllListPage.GoodsAll = result;
                goodsAllListPage.Total = conn.ExecuteScalar<int>(sqlCount);

                return goodsAllListPage;
            }

        }

    }
}
