using Microsoft.Ajax.Utilities;
using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebProject.Controllers
{
    public class DetailsOfRequestController : Controller
    {
        public ActionResult UploadGamePlan(DetailsOfRequest detailsOfRequest)
        {
            try
            {
                if (detailsOfRequest.GamePlan1 != null && detailsOfRequest.GamePlan1.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(detailsOfRequest.GamePlan1.FileName);
                    string fileExtension = Path.GetExtension(detailsOfRequest.GamePlan1.FileName);
                    fileName = DateTime.Now.ToString("MMddyyyy") + "-" + fileName.Trim() + fileExtension;
                    detailsOfRequest.GamePlanPath = Server.MapPath("~\\UploadedFiles\\GamePlanFiles\\") + fileName;
                    detailsOfRequest.GamePlan1.SaveAs(detailsOfRequest.GamePlanPath);

                    //for display
                    detailsOfRequest.GamePlanValidation = " -Uploaded Successfully-";
                    detailsOfRequest.GamePlanPath = detailsOfRequest.GamePlan1.FileName;
                    return RedirectToAction("requests", detailsOfRequest);
                }
                else
                {
                    detailsOfRequest.GamePlanValidation = "";
                    return RedirectToAction("requests", detailsOfRequest);
                }
            }
            catch (Exception e)
            {
                detailsOfRequest.GamePlanValidation = " -Uploading Failed-";
                return RedirectToAction("requests", detailsOfRequest);
            }
        }
        public ActionResult UploadSupportingDocuments(DetailsOfRequest detailsOfRequest)
        {
            try
            {
                if (detailsOfRequest.SupportingDocuments1 != null && detailsOfRequest.SupportingDocuments1.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(detailsOfRequest.SupportingDocuments1.FileName);
                    string fileExtension = Path.GetExtension(detailsOfRequest.SupportingDocuments1.FileName);
                    fileName = DateTime.Now.ToString("MMddyyyy") + "-" + fileName.Trim() + fileExtension;
                    detailsOfRequest.SupportingDocumentsPath = Server.MapPath("~\\UploadedFiles\\SupportingDocuments\\") + fileName;
                    detailsOfRequest.SupportingDocuments1.SaveAs(detailsOfRequest.SupportingDocumentsPath);

                    //for display
                    detailsOfRequest.SupportingDocumentsValidation = " -Uploaded Successfully-";
                    detailsOfRequest.SupportingDocumentsPath = detailsOfRequest.SupportingDocuments1.FileName;
                    return RedirectToAction("requests", detailsOfRequest);
                }
                else
                {
                    detailsOfRequest.SupportingDocumentsValidation = "";
                    return RedirectToAction("requests", detailsOfRequest);
                }
            }
            catch (Exception)
            {
                detailsOfRequest.SupportingDocumentsValidation = " -Uploading Failed-";
                return View("requests", detailsOfRequest);
            }
        }
        public ActionResult Requests(DetailsOfRequest detailsOfRequest)
        {
            return View(detailsOfRequest);
        }
        public ActionResult Requests1(DetailsOfRequest detailsOfRequest)
        {
            return View("requests");
        }
        // GET: DetailsOfRequest
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetailsOfRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailsOfRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailsOfRequest/Create
        [HttpPost]
        public ActionResult Create(DetailsOfRequest detailsOfRequest, string submitGamePlan, string submitSupportingDocuments, string saveAsDraft)
        {
            if (!string.IsNullOrEmpty(submitGamePlan))
            {
                return UploadGamePlan(detailsOfRequest);
            }
            if (!string.IsNullOrEmpty(submitSupportingDocuments))
            {
                return UploadSupportingDocuments(detailsOfRequest);
            }
          
            try
            {
                using (var context = new TMGEntities())
                {
                    var requestHistory = new RequestHistory();
                    var request = new DetailsOfRequest();
                    {
                        request.Emp_ID = LoginController.UserId;
                        request.DateCreated = detailsOfRequest.DateCreated;
                        request.Channel = detailsOfRequest.Channel;
                        request.Title = detailsOfRequest.Title;
                        request.Description = detailsOfRequest.Description;
                        request.CoveragePeriod = detailsOfRequest.CoveragePeriodStart.ToString() + "-" + detailsOfRequest.CoveragePeriodEnd.ToString();
                        request.GamePlan = detailsOfRequest.GamePlanPath;
                        request.SupportingDocuments = detailsOfRequest.SupportingDocumentsPath;
                        request.Objectives = detailsOfRequest.Objectives;
                        request.Mechanics = detailsOfRequest.Mechanics;
                        request.ResourcesNeeded = detailsOfRequest.ResourcesNeeded;
                        request.Amount = detailsOfRequest.Amount;
                        request.DateNeeded = detailsOfRequest.DateNeeded;
                        request.CostToSales = detailsOfRequest.CostToSales;
                        request.AllocatedAnnualBudget = detailsOfRequest.AllocatedAnnualBudget;
                        request.YTDExpenses = detailsOfRequest.YTDExpenses;
                        request.RemainingBudget = detailsOfRequest.RemainingBudget;
                        request.DateNeeded = detailsOfRequest.DateNeeded;
                        request.Status = "Request Created";

                        if (!string.IsNullOrEmpty(saveAsDraft))
                        {
                            request.Status = "Draft";
                        }
                        requestHistory.Request_ID = request.Request_ID;
                        requestHistory.RequestHistoryStatus = request.Status;

                        request.RequestHistories.Add(requestHistory);
                    };
                    
                    context.DetailsOfRequests.Add(request);
                    context.SaveChanges();

                }
                // TODO: Add insert logic here

                return RedirectToAction("Requests");
            }
            catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return RedirectToAction("Requests");
            }
        }

        // GET: DetailsOfRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailsOfRequest/Edit/5
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

        // GET: DetailsOfRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailsOfRequest/Delete/5
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
