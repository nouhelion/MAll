using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MALL.Models;
using MALLML.Model;
namespace MALL.Controllers
{

    public class HomeController : Controller
    {    private DbModels db = new DbModels();

        public ActionResult Index()
        {
            // Add input data
            //ModelInput input = new ModelInput()
            //{
            //    Col0 = "This restaurant was wonderful."
            //};
            //// Load model and predict output of sample data
            //ModelOutput result = ConsumeModel.Predict(input);

            //// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
            //string sentiment = result.Prediction == "1" ? "Positive" : "Negative";
            //@ViewData["message"]="Text: " +input.Col0+ "Sentiment:"+ sentiment;
            return View();
        }

        public ActionResult About()
        {
            var pQuery = db.Products.Where(elt => elt.CategoryName == "Fashion");
            return View(pQuery.ToList());
        }      
        public ActionResult restaurant()
        {
            var pQuery = db.Restaurents;
            return View(pQuery.ToList());
        }       
        public ActionResult brand()
        {
            var pQuery = db.brands;
            return View(pQuery.ToList());
        }

        public ActionResult Contact()
        {
            var pQuery = db.Products.Where(elt => elt.CategoryName == "Beauty");
            return View(pQuery.ToList());
        }
    }
}