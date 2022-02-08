using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_on_Customer_Single_view_EF.Models;

namespace CRUD_on_Customer_Single_view_EF.Controllers
{
    public class CustController : Controller
    {
        public void ForewardCust()
        {
            CustomerModel obj = new CustomerModel();
            ViewBag.cust = obj.GetCustomer();
        }
        // GET: Cust
        public ActionResult Index()
        {
            ForewardCust();
            return View();
        }
        public ActionResult DeleteCus()
        {
            CustomerModel obj = new CustomerModel
            {
                Cid = int.Parse(Request.QueryString["cno"])
            };
            ViewData["delvalue"] = obj.DeleteCustomer();
            ForewardCust();
            return View("Index");
        }
        public ActionResult InsertCus()
        {
            CustomerModel obj = new CustomerModel
            {
                Cid = int.Parse(Request["txtcno"]),
                cname = Request["txtcname"],
                cloc = Request["txtcloc"],
                cmail = Request["txtcmail"]
            };
            ViewData["insvalue"] = obj.InsertCustomer();
            ForewardCust();
            return View("Index");
        }
        public ActionResult EditCus()
        {
            CustomerModel obj = new CustomerModel
            {
                Cid = int.Parse(Request.QueryString["cno"])
            };
            ForewardCust();
            return View("Index");
        }
        public ActionResult UpdateCus()
        {
            CustomerModel obj = new CustomerModel
            {
                Cid = int.Parse(Request["txtcid"]),
                cloc = Request["txtnewloc"]
            };
            ViewData["updvalue"] = obj.UpdateCustomer();
            ForewardCust();
            return View("Index");
        }
        public ActionResult Cancel()
        {
            ForewardCust();
            return View("Index");
        }
    }
}