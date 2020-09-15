using Microsoft.Ajax.Utilities;
using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Status()
        {
            ViewBag.Message = "Request Status";
            List<DetailsOfRequest> result = new List<DetailsOfRequest>();
            var user_id = LoginController.UserId;

            using (var context = new TMGEntities())
            {
                result = context.DetailsOfRequests.Where(u => u.Emp_ID == user_id).ToList();
            }

            return View(result);
        }
        public new ActionResult ValidateRequest()
        {
            ViewBag.Message = "Validate Request";
            List<DetailsOfRequest> result = new List<DetailsOfRequest>();
            var user_id = LoginController.UserId;

            using (var context = new TMGEntities())
            {
                result = context.DetailsOfRequests.Where(u => u.Emp_ID == user_id).ToList();
            }
            return View(result);
        }
        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            DetailsOfRequest detailsOfRequest = new DetailsOfRequest();
            using (var context = new TMGEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                detailsOfRequest = context.DetailsOfRequests.Where(u => u.Request_ID == id).FirstOrDefault();
            }
            return Json(detailsOfRequest,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveUserInfo(UserInfo userInfo)
        {
            try
            {
                using (var context = new TMGEntities())
                {
                    context.UserInfoes.Add(userInfo);
                    context.SaveChanges();
                    TempData["message"] = "Saved Successfully.";
                }
            }
            catch (Exception e)
            {
                TempData["message"] = "Save Failed!";
            }
            return Json(TempData["message"]);
        }
        [HttpGet]
        public JsonResult GetHistoryById(int id)
        {
            List<RequestHistory> requestHistory = new List<RequestHistory>();
            using (var context = new TMGEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                requestHistory = context.RequestHistories.Where(u => u.Request_ID == id).ToList();
            };
            return Json(requestHistory, JsonRequestBehavior.AllowGet);
        }
    }
}