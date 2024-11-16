using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4.DTOs;
using Week4.EF;
using Week4.CustomValidations;

namespace Week4.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        Product_and_CustomerEntities db = new Product_and_CustomerEntities();

        public static Customer Convert(CustomerDTO c)
        {
            return new Customer
            {
                ID = c.ID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                DateJoined = c.DateJoined
            };
        }

        public static CustomerDTO Convert(Customer c)
        {
            return new CustomerDTO
            {
                ID = c.ID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                DateJoined = c.DateJoined
            };
        }

        public static List<CustomerDTO> Convert(List<Customer> c)
        {
            var list = new List<CustomerDTO>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public ActionResult List()
        {
            var data = db.Customers.ToList();
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]

        public ActionResult Create(CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(Convert(c));
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(c);

        }

        public ActionResult Details(int id)
        {
            var data = db.Customers.Find(id);
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Customers.Find(id);
            return View(Convert(data));
        }

        [HttpPost]

        public ActionResult Edit(CustomerDTO c)
        {
            if(ModelState.IsValid)
            {
                var data = db.Customers.Find(c.ID);
                db.Entry(data).CurrentValues.SetValues(c);
                data.FirstName = c.FirstName;
                data.LastName = c.LastName;
                data.Email = c.Email;
                data.Phone = c.Phone;
                data.Address = c.Address;
                data.DateJoined = c.DateJoined;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(c);
            
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            var data = db.Customers.Find(id);
            return View(Convert(data));
        }

        [HttpPost]

        public ActionResult Delete(int id, string dcsn)
        {
            if(dcsn.Equals("Yes"))
            {
                var data = db.Customers.Find(id);
                db.Customers.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }

        
}