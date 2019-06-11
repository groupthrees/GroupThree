using Brewmaster.Alcohol.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brewmaster.Alcohol.Repository
{
    public class TestRepository : ITestRepository
    {
        public int test(int id)
        {
            return id;
        }
    }
}
