
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Model.Dto;
using Brewmaster.Alcohol.Model.Dto.订单Dto;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;
using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.Repository
{
    public class IndentRepository : IIndentRepository
    {

        //数据库连接
        private static string connStr = "Server=169.254.200.110;Database=alcohol;Uid=root;Pwd=123456;";

        /// <summary>
        ///订单显示
        /// </summary>
        /// <param name="orderSite"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<IndentDto> GetIndentPageList( int userId, int OrderSite)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql1 = string.Format("select orders.*,address.detailaddress,address.AddressPerson from address join orders on address.Id = orders.addressId  where orders.usersId = {0} and orders.OrderSite={1}", userId,OrderSite);
                var orderlist = conn.Query<IndentDto>(sql1).ToList();
                string sql2 = string.Format("select goods.goodsimg as img,goods.GoodsName,ordergoods.ordersid  from ordergoods join goods on ordergoods.GoodsId=goods.Id   where UsersId={0}", userId);
                var goodslist = conn.Query<orderImg>(sql2).ToList();
                List< IndentDto> indent =new List<IndentDto>();
                foreach (var item in orderlist)
                {
                    IndentDto indentDto = new IndentDto();
                    indentDto.ApplyMethod = item.ApplyMethod;
                    indentDto.Id = item.Id;
                    indentDto.AddressPerson = item.AddressPerson;
                    indentDto.PracticalMoney = item.PracticalMoney;
                    indentDto.OrderSite = item.OrderSite;
                    List<string> imgs = new List<string>();
                    foreach (var item1 in goodslist.Where(a=>a.ordersid==item.Id))
                    {

                        imgs.Add(item1.img);
                    }
                    indentDto.imgs = imgs;
                    indent.Add(indentDto);

                }

                return indent;

            }

        }

     

    }
    
}
