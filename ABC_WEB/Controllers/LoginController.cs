using ABC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authenticate(ABC_WEB.Models.Client userModel)
        {
            using (ABC_DBEntities db = new ABC_DBEntities())
            {
                var LoginDetail = db.Clients.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (LoginDetail == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or Password.";
                    return View("Index", userModel);
                }
                else
                {

                    Session["userID"] = LoginDetail.Client_ID;
                    Session["FullName"] = LoginDetail.Name;


                    return RedirectToAction("Index", "RequestPayment");
                }


            }

        }
    }
}