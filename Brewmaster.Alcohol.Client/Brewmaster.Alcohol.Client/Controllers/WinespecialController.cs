﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class WinespecialController : Controller
    {
        public IActionResult WinespecialIndex()
        {
            return View();
        }
    }
}