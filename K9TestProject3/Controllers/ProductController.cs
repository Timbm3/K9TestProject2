using K9TestProject3.Fantastic;
using K9TestProject3.HelpersLib;
using K9TestProject3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace K9TestProject3.Controllers
{
    public class ProductController : Controller
    {
        private List<int> itemsToDelete = new List<int>();
        private List<ColorAttributeVM> vms;
        public ProductController()
        {
            vms = new List<ColorAttributeVM>();
        }

        // GET: Product
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = db.Products.ToList();
                return View(model);
            }
            // var course = db.Courses
            //   .Include(i => i.Modules.Select(s => s.Chapter))
            //   .Single(s => s.Id == id);
            //return View(course);
        }


        public ActionResult AddProduct3()
        {
            var dd = new Product()
            {
                ColorAttributes = new List<ColorAttribute>()
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new ProductVM(dd)
                {
                    Colors = db.Colors.ToList(),
                    Sizes = db.Sizes.ToList()
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddProduct3(ProductVM model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Product product = ProductHelpers.CreateProductFromViewModel(model);
                db.Products.Add(product);
                db.SaveChanges();
            }
            return View("Index");
        }

        public ActionResult GetSizes()
        {
            List<Size> sizes = new List<Size>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                sizes = db.Sizes.OrderBy(s => s.SizeName).ToList();
            }
            return Json(new SelectList(sizes, "SizeId", "SizeName"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetColors()
        {
            List<Color> colors = new List<Color>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                colors = db.Colors.OrderBy(s => s.ColorName).ToList();
            }
            return Json(new SelectList(colors, "ColorId", "ColorName"), JsonRequestBehavior.AllowGet);
        }



        public ActionResult EditProduct(int? id)
        {
            //DeleteItem(32);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var product2 = db.Products.Include(co => co.ColorAttributes).Include(si => si.ColorAttributes.Select(sis => sis.SizeAttributes)).SingleOrDefault(x => x.ProductId == id);
                var colorList = db.Colors.ToList();
                var sizeList = db.Sizes.ToList();

                ProductVM model2 = ProductHelpers.CreateViewModelFromProduct(product2, colorList, sizeList);

                return View(model2);
            }
        }

        //public void DeleteItem(int id)
        //{

        //    itemsToDelete.Add(43);
        //}


        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            try
            {
                itemsToDelete.Add(id);

                //if (support == null)
                //{
                //    Response.StatusCode = (int)HttpStatusCode.NotFound;
                //    return Json(new { Result = "Error" });
                //}

                //delete files from the file system

                //db.Supports.Remove(support);
                //db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult EditProduct(ProductVM model, FormCollection form)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //foreach (var i in itemsToDelete)
                //{
                //    model.ColorAttributes.Remove(i)
                //}
                var test = itemsToDelete;

                Product product = ProductHelpers.EditProductFromViewModel(model);

                db.Products.Attach(product);

                db.Entry(product).State = EntityState.Modified;
                foreach (var item in product.ColorAttributes)
                {
                    db.Entry(item).State = item.ColorAttributeId < 0 ?
                        EntityState.Added : EntityState.Modified;

                    foreach (var sizeAttribute in item.SizeAttributes)
                    {
                        db.Entry(sizeAttribute).State = sizeAttribute.SizeAttributeId < 0 ?
                            EntityState.Added : EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
            return View("Index");
        }
    }
}