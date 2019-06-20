using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model;
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

        /// <summary>
        /// 根据UsersId查询收藏的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public CollectionPageList GetCollectionlist(int id, int pageIndex, int pageSize)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string strSql1 = string.Format("select count(1) from collection join goods on collection.GoodsId = goods.Id join price on goods.Id=price.Goodsid where  UsersId={0}", id);
                var total = conn.ExecuteScalar<int>(strSql1);
                int index = (pageIndex - 1) * pageSize;
                var strSql2 = string.Format("select * from collection join goods on collection.GoodsId = goods.Id join price on goods.Id=price.Goodsid where UsersId={0} limit  {1},{2}", id, index, pageSize);

                var collectionlist = conn.Query<CollectionDto>(strSql2);
                if (collectionlist == null)
                {
                    return new CollectionPageList();
                }
                var collectionDto = new CollectionPageList
                {
                    CollectionList = collectionlist.ToList(),
                    Total = total
                };
                return collectionDto;
            }
        }

        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="shopCart"></param>
        /// <returns></returns>
        public int InsertShopCart(ShopCart shopCart)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
              
                
                    string strsql = string.Format("insert into shopcart(GoodsId,UsersId,Num) values({0},{1},{2})", shopCart.GoodsId, shopCart.UsersId, shopCart.Num);
                    var result = conn.Execute(strsql);
                    return result;
                


               
            }
        }
    }
}

