using Brewmaster.Alcohol.Model;
using System;
using System.Collections.Generic;

namespace Brewmaster.Alcohol.IRepository
{
    public interface IProductRepository
    {
        /// <summary>
        /// 返回单个Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProduct(int productId);

        /// <summary>
        /// 获取Product
        /// </summary>
        /// <returns></returns>
        List<Product> Productlist();

        /// <summary>
        /// 多表连接
        /// </summary>
        /// <returns></returns>
        List<Product> ProductUser();

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int InsertProduct(Product product);

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        int InsertProduct(List<Product> products);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        int DeleteProduct(int productId);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        int DeleteProducts(System.Collections.Generic.List<Product> productIds);

        /// <summary>
        /// 普通存储过程调用(OUT)
        /// </summary>
        /// <param name="usersId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<Product> ExecProductOut(int usersId, out int count);

        /// <summary>
        ///// 通用分页demo
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="loginName"></param>
        ///// <param name="page"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //PageDataView<Product> GetCommonList(int page = 1, int pageSize = 10);

        /// <summary>
        /// 事务
        /// </summary>
        void TranMed();
    }
}
