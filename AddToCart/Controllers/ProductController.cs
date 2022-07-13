using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddToCart.Models;
namespace AddToCart.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        // GET: ProductController
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int PId)
        {
            Product prod = db.GetProductById(PId);
            return View(prod);
        }

        // GET: ProductController/Create
        public ActionResult Create(int PId)
        {
            var product = db.GetProductById(PId);

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                db.Save(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int PId)
        {
            Product prod = db.GetProductById(PId);
            var model = prod;
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                db.Update(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int PId)
        {
            Product prod = db.GetProductById(PId);

            return View(prod);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName ("Delete")]
        public ActionResult DeleteComfirm(int PId)
        {
            try
            {
                db.Delete(PId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
