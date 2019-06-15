using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto.收藏表;
using Brewmaster.Alcohol.Model.Dto.订单Dto;
using Dapper;
using MySql.Data.MySqlClient;

namespace Brewmaster.Alcohol.Repository
{
    public class CollectionRepository : ICollectionRepository
    {
        //数据库连接
        private static string connStr = "Server=169.254.241.82;Database=alcohol;Uid=root;Pwd=1064519100;";

        public CollectionPageList GetCollectionPageList(int pageIndex, int pageSize)
        {
            CollectionPageList collectionPageList = new CollectionPageList();
            var sql = "";
            var sqlCount = "";
            int sum = (pageIndex - 1) * pageSize;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                sql = string.Format("select GoodsName,GoodsDegree,GoodsImg,PriceNow from  Goods inner join  valence on goods.Id = valence.GoodsId inner join price on price.GoodsId = Goods.Id limit  {0},{1}  ", sum, pageSize);
                sqlCount = string.Format("select Count(Goods.Id) from  Goods inner join  valence on goods.Id = valence.GoodsId inner join price on price.GoodsId = Goods.Id");
                var result = conn.Query<CollectionDto>(sql).ToList();
                collectionPageList.GetCollectionDto = result;
                collectionPageList.total= conn.ExecuteScalar<int>(sqlCount);
                return collectionPageList;
            }
        }
    }


}

