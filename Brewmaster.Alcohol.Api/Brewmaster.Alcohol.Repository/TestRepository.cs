using Brewmaster.Alcohol.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace Brewmaster.Alcohol.Repository
{
    public class TestRepository : ITestRepository
    {
        public int test(int id)
        {
            using (SqlConnection s = new SqlConnection())
            {

            }
            return id;
        }
    }
}
