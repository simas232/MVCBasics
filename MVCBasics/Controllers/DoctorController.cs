using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(float temperatureValue, String temperatureScale)
        {
            if (temperatureValue == 0.0f)
            {
                return View();
            }
            else
            {
                ViewBag.Msg = FeverCheckModel.EvaluateTemperature(temperatureValue, temperatureScale);

                return View();
            }
        }
    }
}
