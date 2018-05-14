using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmCalculator.Models;
using System.Data;
namespace OhmCalculator.Controllers
{
    public class OhmCalculatorController : Controller
    {
        [HttpGet]
        public ActionResult GetColorValues()
        {
            ViewData["Message"] = "Resistor Calculator";
            
            CalculatorModel model = new CalculatorModel()
            {
                ColorList = GetColorList(), MultiplierColorList = GetMultiplierColorList(), ToleranceColorList = GetToleranceColorList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult GetColorValues(CalculatorModel model)
        {
            ViewData["Message"] = "Resistor Calculator";
            model.ColorList = GetColorList();
            model.MultiplierColorList = GetMultiplierColorList();
            model.ToleranceColorList = GetToleranceColorList();
            IOhmValueCalculator calc = new OhmValueCalculator();
            var result = calc.CalculateOhmValue(model.BandColorA, model.BandColorB, model.Multiplier, model.Tolerance);
            ViewData["Result"] = result.ToString() +" "+ model.Tolerance.ToString();
            return View(model);
        }

        [NonAction]
        public List<SelectListItem> GetColorList()
        {
            string xmlData = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ColorList.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var Colors = new List<SelectListItem>();
            Colors = (from rows in ds.Tables[0].AsEnumerable()
                        select new SelectListItem
                        {
                            Text = rows[0].ToString(),
                            Value =rows[1].ToString(), 
                        }).ToList();
            return Colors;  
        }
        [NonAction]
        public List<SelectListItem> GetMultiplierColorList()
        {
            string xmlData = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/MultiplierColorList.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var Colors = new List<SelectListItem>();
            Colors = (from rows in ds.Tables[0].AsEnumerable()
                      select new SelectListItem
                      {
                          Text = rows[0].ToString(),
                          Value = rows[1].ToString(),
                      }).ToList();
            return Colors;
        }
        [NonAction]
        public List<SelectListItem> GetToleranceColorList()
        {
            string xmlData = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ToleranceColorList.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var Colors = new List<SelectListItem>();
            Colors = (from rows in ds.Tables[0].AsEnumerable()
                      select new SelectListItem
                      {
                          Text = rows[0].ToString(),
                          Value = rows[1].ToString(),
                      }).ToList();
            return Colors;
        }
    }
  
}
