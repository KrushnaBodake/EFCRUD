using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        private readonly ApplicationDbContext db;
        ProductsDal productsDal;
        public ProductsController(ApplicationDbContext db)
        {
            this.db= db;
            productsDal = new ProductsDal(this.db);
        }
        public ActionResult Index()
        {
            var list = productsDal.GetAllProducts();
            return View(list);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
           var prod= productsDal.GetProductsById(id);
            return View(prod);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products prod)
        {
            try
            {
               int result= productsDal.AddProducts(prod);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = productsDal.GetProductsById(id);
            return View(prod);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products prod)
        {
            try
            {
                int result = productsDal.UpdateProducts(prod);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = productsDal.GetProductsById(id);
            return View(prod);
           
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int result = productsDal.DeleteProducts(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View(); 
            }
            catch
            {
                return View();
            }
        }
    }
}
