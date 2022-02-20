using MALL.Models;
using MALLML.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MALL.Controllers
{
    public class commentController : Controller
    {
        private DbModels db = new DbModels();

        // GET: comments
        public ActionResult Index()
        {
            return View(db.comments.ToList());
        }

        // GET: comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment c = db.comments.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // GET: comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: comments/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDC,Name,Comment1")] comment c)
        {
            if (ModelState.IsValid)
            {
                ModelInput input = new ModelInput()
                {
                    Col0 = c.Comment1,
                };
                // Load model and predict output of sample data
                ModelOutput result = ConsumeModel.Predict(input);

                // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
                c.sentiment = result.Prediction == "1" ? "Positive" : "Negative";
                @ViewData["message"] = "Text: " + input.Col0 + "Sentiment:" + c.sentiment;
                db.comments.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(c);
        }

        // GET: comments/Edit/5

        // POST: comments/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        // GET: comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment c = db.comments.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comment c = db.comments.Find(id);
            db.comments.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}