using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmValueCalculatorApp.CalculateOhmValue;
using OhmValueCalculatorApp.Models;

namespace OhmValueCalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult CalculateOhmValue()
        {
            string band1 = Request.Form["band1Color"];
            string band2 = Request.Form["band2Color"];
            string band3 = Request.Form["band3Color"];
            string band4 = Request.Form["toleranceBandColor"];

            CalculateOhmValueRequest request = new CalculateOhmValueRequest();
            request.bandAColor = band1;
            request.bandBColor = band2;
            request.bandCColor = band3;
            request.toleranceBandColor = band4;

            CalculateOhmValueUseCase useCase = new CalculateOhmValueUseCase();
            CalculateOhmValueResponse response = useCase.execute(request);

            //StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();
            //int calculation = calculator.CalculateOhmValue(band1, band2, band3, band4);

            return Json(new {
                            success = response.success,
                            message = response.message,
                            result = response.calculatedValue,
                            tolerance = response.toleranceValue,
                            }, JsonRequestBehavior.AllowGet
                        );
        }
    }
}