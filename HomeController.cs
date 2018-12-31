using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF6_Example.Models;

namespace MVC_EF6_Example.Controllers
{
    public class HomeController : Controller
    {
        MyDBContext db = new MyDBContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*
                var count = (from c in db.Customers
                             where c.customerid == model.loginid && c.customerpassword == model.Password
                             select c).Count();
                             */
                var count = db.Customers.Count(c => c.customerid == model.loginid && c.customerpassword == model.Password);
                if (count > 0)
                {
                    Session["loginid"] = model.loginid;
                    return RedirectToAction("search", "Home");
                }
                else
                {
                    ViewBag.msg = "Invalid ID or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerModel model)
        {
            db.Customers.Add(model);
            db.SaveChanges();//will update database
            ViewBag.msg = "Customer Added:" + model.customerid;
            return View();
        }

        public ActionResult Search()
        {
            List<CustomerModel> list = new List<CustomerModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
            /*
            var data = (from c in db.Customers
                        where c.customerid.ToString().Contains(key)
                        || c.customername.Contains(key)
                        || c.customeremailid.Contains(key)
                        select c).ToList();*/

            var data = db.Customers.Where(c => c.customerid.ToString().Contains(key)
                                          || c.customername.Contains(key)
                                          || c.customeremailid.Contains(key)).ToList();
            return View(data);

        }

        public ActionResult Find(int id)
        {
            /*var model = (from c in db.Customers
                         where c.customerid == id
                         select c).FirstOrDefault();*/

            var model = db.Customers.FirstOrDefault(c => c.customerid == id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            /* var model = (from c in db.Customers
                          where c.customerid == id
                          select c).FirstOrDefault();*/

            var model = db.Customers.FirstOrDefault(c => c.customerid == id);
            db.Customers.Remove(model);
            db.SaveChanges();
            return View("v_customerdeleted");
        }
        public ActionResult Edit(int id)
        {
            /* var model = (from c in db.Customers
                          where c.customerid == id
                          select c).FirstOrDefault();*/

            var model = db.Customers.FirstOrDefault(c => c.customerid == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            /* var dbmodel = (from c in db.Customers
                            where c.customerid == model.customerid
                            select c).FirstOrDefault();*/

            var dbmodel = db.Customers.FirstOrDefault(c => c.customerid == model.customerid);
            dbmodel.customercity = model.customercity;
            dbmodel.customeremailid = model.customeremailid;
            db.SaveChanges();
            return View("v_Updated");
        }
    }
}