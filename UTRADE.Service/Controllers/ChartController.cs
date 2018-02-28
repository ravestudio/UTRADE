using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UTRADE.Service.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var arr = new List<object>(); 
            arr.Add(new object[] {DateTime.Now.Ticks, 100, 120, 115, 117});
            arr.Add(new object[] {DateTime.Now.AddMinutes(1).Ticks, 98, 100, 113, 118});
            arr.Add(new object[] {DateTime.Now.AddMinutes(2).Ticks, 99, 110, 114, 116});

            return Json(arr);
        }

    }

}