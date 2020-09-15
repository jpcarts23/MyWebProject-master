using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MyWebProject.Models;

namespace MyWebProject.Controllers
{
    public class LoginController : Controller
    {
        public static string UserId = "";
        public static string UserAccess = "";
        public ActionResult Dashboard()
        {
            ViewBag.Access = UserAccess;
            return View();
        }
        public ActionResult Index()
        {
            LoginRequest loginRequest = new LoginRequest();
            return View(loginRequest);
        }

        [HttpPost]
        public ActionResult VerifyLogin(LoginRequest loginRequest)
        {
            using (TMGEntities db = new TMGEntities())
            {
                var query = db.LoginRequests.Where(s => s.Username == loginRequest.Username && s.Password == loginRequest.Password).FirstOrDefault<LoginRequest>();

                if (query != null)
                {

                    UserId = query.Emp_ID;
                    Session["Id"] = query.Emp_ID;
                    Session["Username"] = query.UserInfo.FirstName + " " + query.UserInfo.LastName;
                    Session["Validate"] = "block";

                    System.Diagnostics.Debug.WriteLine(query.UserInfo.Access);
                    if (query.UserInfo.Access == "Admin")
                    {
                        UserAccess = "Admin";
                    }
                    else if (query.UserInfo.Access == "RCA" || query.UserInfo.Access == "Channel Head")
                    {
                        UserAccess = "SalesVP/ChannelHead";
                    }
                    else
                    {
                        UserAccess = "Requester";
                    }
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    loginRequest.LoginError = "Incorrect Username/Password";
                    return View("Index",loginRequest);
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
