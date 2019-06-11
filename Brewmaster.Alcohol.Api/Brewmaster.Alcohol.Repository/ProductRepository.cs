using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Model;
using IRepository;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// 返回单个Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProduct(int productId)
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("select * from Product where ID ={0}",productId);
                var result = conn.QuerySingle<Product>(strSql, productId);
                return result;
            }
        }

        /// <summary>
        /// 获取Product
        /// </summary>
        /// <returns></returns>
        public List<Product> Productlist()
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("select * from Product");

                //枚举
                IEnumerable<Product> result = conn.Query<Product>(strSql, null);
                return result.ToList<Product>();
            }
        }

        /// <summary>
        /// 多表连接
        /// </summary>
        /// <returns></returns>
        public List<Product> ProductUser()
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("select Product.* from Product left join Users on  Product.UserID = Users.UserID");

                var productList = conn.Query<Product>(strSql, null);
                return productList.ToList<Product>();
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int InsertProduct(Product product)
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("insert into Product values(@ProductName,@ProductDesc,@UserID,getdate())");
                int i = conn.Execute(strSql, product);
                return i;
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public int InsertProduct(List<Product> products)
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("insert into Product values(@ProductName,@ProductDesc,@UserID,getdate())");
                int i = conn.Execute(strSql, products);
                return i;
            }
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int DeleteProduct(int productId)
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("delete  Product where id=@ProductId");
                int i = conn.Execute(strSql, new { ProductId = productId });
                return i;
            }
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public int DeleteProducts(List<Product> productIds)
        {
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string strSql = string.Format("delete  Product where id in (@id)");
                int i = conn.Execute(strSql, productIds);
                return i;
            }
        }

        /// <summary>
        /// 普通存储过程调用(OUT)
        /// </summary>
        /// <param name="usersId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Product> ExecProductOut(int usersId, out int count)
        {
            var productList = new List<Product>();

            DynamicParameters parms = new DynamicParameters();
            parms.Add("@Pageindex", "1", DbType.Int32, ParameterDirection.Input, null);
            parms.Add("@pageSize", "1", DbType.Int32, ParameterDirection.Input, null);
            parms.Add("@count", null, DbType.Int32, ParameterDirection.Output, null);

            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                productList = conn.Query<Product>("dbo.Pager", parms, null, false, null, CommandType.StoredProcedure).ToList<Product>();
                count = parms.Get<int>("@count");
                return productList;
            }
        }

        /// <summary>
        /// 通用分页demo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loginName"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageDataView<Product> GetCommonList(int page = 1, int pageSize = 10)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Condition = "1=1";
            criteria.Condition += string.Format(" and ProductName like '%{0}%'", "商品");
            criteria.CurrentPage = page;
            criteria.Fields = "*";
            criteria.PageSize = pageSize;
            criteria.TableName = "Product ";
            criteria.PrimaryKey = "ID";
            var productList = DapperHelper.GetPageData<Product>(criteria);
            return productList;
        }

        /// <summary>
        /// 事务
        /// </summary>
        public void TranMed()
        {
            int id = 2;
            using (SqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    string strSql = "DELETE FROM Product WHERE id = @ProductID";
                    string strSql2 = "DELETE FROM Users WHERE UserID = @UserID";
                    conn.Execute(strSql, new { ProductID = id }, transaction, null, null);
                    conn.Execute(strSql2, new { UserID = id }, transaction, null, null);

                    //提交事务
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //出现异常，事务Rollback
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
