using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService objCust;

        //CustomerRepository CustRepository;
        public HomeController()
        {
            this.objCust = new CustomerService();
        }

        // GET: Home
        public ActionResult Index()
        {
            int Count = 10;
            object[] parameters = { Count };
            var test = objCust.GetAll(parameters);
            return View(test);
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Customer model)
        {
            if (ModelState.IsValid)
            {
                object[] parameters = { model.CustName, model.CustEmail };
                objCust.Insert(parameters);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            object[] parameters = { id };
            this.objCust.Delete(parameters);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            object[] parameters = { id };
            return View(this.objCust.GetbyID(parameters));
        }

        [HttpPost]
        public ActionResult Update(Customer model)
        {
            object[] parameters = { model.Id, model.CustName, model.CustEmail };
            objCust.Update(parameters);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}