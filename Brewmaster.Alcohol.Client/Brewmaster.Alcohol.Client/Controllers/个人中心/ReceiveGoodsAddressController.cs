﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    //收货地址
    public class ReceiveGoodsAddressController : Controller
    {
        /// <summary>
        /// 收货地址
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        
    }
}