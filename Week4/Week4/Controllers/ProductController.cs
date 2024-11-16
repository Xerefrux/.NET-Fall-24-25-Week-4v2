using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4.DTOs;
using Week4.EF;

namespace Week4.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Product_and_CustomerEntities db = new Product_and_CustomerEntities();


        public static Product Convert(ProductDTO p)
        {
            return new Product
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category
            };
        }


        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category
            };
        }

        public static List<ProductDTO> Convert(List<Product> p)
        {
            var list = new List<ProductDTO>();
            foreach (var item in p)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public ActionResult List()
        {
            var data = db.Products.ToList();
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]

        public ActionResult Create(ProductDTO p) 
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(Convert(p));
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(p);  
        }

        public ActionResult Details(int id)
        {
            var data = db.Products.Find(id);
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Products.Find(id);
            return View(Convert(data));
        }

        [HttpPost]

        public ActionResult Edit(ProductDTO p)
        {
            if(ModelState.IsValid)
            {
                var data = db.Products.Find(p.ID);
                db.Entry(data).CurrentValues.SetValues(p);
                data.Name = p.Name;
                data.Description = p.Description;
                data.Price = p.Price;
                data.StockQuantity = p.StockQuantity;
                data.Category = p.Category;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(p);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            var data = db.Products.Find(id);
            return View(Convert(data));
        }

        [HttpPost]

        public ActionResult Delete(int id, string dcsn)
        {
            if(dcsn.Equals("Yes"))
            {
                var data = db.Products.Find(id);
                db.Products.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("List");

        }


    }
}