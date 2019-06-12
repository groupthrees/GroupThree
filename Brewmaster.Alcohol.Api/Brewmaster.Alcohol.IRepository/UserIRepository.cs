using System;
using System.Collections.Generic;
using System.Text;

using Brewmaster.Alcohol.Model;
namespace Brewmaster.Alcohol.IRepository
{
    public interface UserIRepository
    {
        //注册
        int Resigt(Users users);
    }
}
