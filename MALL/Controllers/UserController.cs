using MALL.Models;
using System.Linq;
using System.Web.Mvc;

namespace SLEK.PROJECT.Controllers
{

    public class UserController : Controller
    {
        private DbModels db = new DbModels();
        [HttpGet]


        public ActionResult Registration(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            //ModelInput sampleData = new ModelInput()
            //   {ImageSource = @"C:\Users\HP\Downloads\DD.jpg",};
            //  string sentiment = predictionResult.Prediction;

            using (DbModels dbmodel = new DbModels())
            {
                var userdetails = dbmodel.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();


                /* ModelInput sampleData = new ModelInput();
                 sampleData.ImageSource = userModel.image.ToString();
                ModelOutput predictionResult = ConsumeModel.Predict(sampleData);
                
                //ModelOutput prediction = ConsumeModel.Predict(p);
                if (predictionResult.Prediction != "with_mask")
                {
                    userModel.LoginErrorMessage = " Without mask";
                    return View("Login", userModel);

                }              
                else*/
                if (userdetails == null)
                {
                    userModel.LoginErrorMessage = "Username or password is incorrect";
                    return View("Login", userModel);

                }
                else
                {
                    Session["RegId"] = userdetails.RegId;
                    Session["Username"] = userdetails.UserName;
                    if (userdetails.UserName == "hajar")
                    {
                        return RedirectToAction("index", "Home");

                    }
                    return RedirectToAction("index", "Products");
                }

            }

        }
        public ActionResult LogOut()
        {
            int RegId = (int)Session["RegId"];
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

        public ActionResult Registration(User userModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                if (dbmodel.Users.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exists";
                    return View("Registration", userModel);
                }

                dbmodel.Users.Add(userModel);
                dbmodel.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration success";


            return View("Registration", new User());
        }
    }
}