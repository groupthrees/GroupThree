﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    //我的订单

    public class MyIndentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}