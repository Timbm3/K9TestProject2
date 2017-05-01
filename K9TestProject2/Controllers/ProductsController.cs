using K9TestProject2.Models;
using K9TestProject2.Models.ProductModels;
using K9TestProject2.ViewModels;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace K9TestProject2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()//new List<ProductVM>(product.);
        {
            //List<Product> product = 
            var model = db.Products.ToList();
            var mode = db.Products.ToArray().Select(x => new ProductVM(x)).ToList();
            return View(mode);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {

            return View();
        }

        #region OldCreate

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductId,Productname,Category, Egenskaps")] ProductVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = new Product
        //        {
        //            ProductId = model.ProductId,
        //            Category = model.Category,
        //            Productname = model.Productname
        //        };
        //        foreach (EgenskapVM egenskapVm in model.Egenskaps)
        //        {
        //            Egenskap egenskap1 = new Egenskap
        //            {
        //                ColorId = egenskapVm.ColorId,
        //                SizeId = egenskapVm.SizeId,
        //                Quantity = egenskapVm.Quantity
        //            };
        //            db.Egenskaps.Add(egenskap1);
        //        }

        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}
        #endregion


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Productname,Category, Egenskaps")] ProductVM model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductId = model.ProductId,
                    Category = model.Category,
                    Productname = model.Productname
                };
                foreach (EgenskapVM egenskapVm in model.Egenskaps)
                {
                    Egenskap egenskap1 = new Egenskap
                    {
                        ColorId = egenskapVm.ColorId,
                        SizeId = egenskapVm.SizeId,
                        Quantity = egenskapVm.Quantity
                    };
                    db.Egenskaps.Add(egenskap1);
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            ProductVM model = new ProductVM(product);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Productname,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
