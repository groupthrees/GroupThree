using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
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

        public ActionResult Update(int id)
        {
            ViewBag.id = id;
            var result = new ApiHelper().GetApiResult("get", "Address/GetAddressById?id=" + id);
            var address = JsonConvert.DeserializeObject<Address>(result);
            return View(address);
        }

        
    }
}