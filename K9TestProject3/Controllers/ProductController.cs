using K9TestProject3.Fantastic;
using K9TestProject3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace K9TestProject3.Controllers
{
    public class ProductController : Controller
    {
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
                List<Size> sizeOrgs = db.Sizes.ToList();
                ViewBag.SizeOrgs = sizeOrgs;

                Product product = CreateProductFromViewMode(model);
                db.Products.Add(product);
                db.SaveChanges();


            }
            return View("Index");

            //var hierarchy = from p in ctx.Parents
            //        .Include(p => p.Children.Select(c => c.GrandChild))
            //                select p;

            //var children = MenuList.MenuItems.Where(mi => mi.ParentId == 0);
            //var grandchildren = MenuList.MenuItems.Where(mi => children.Any(c => c.Id == mi.ParentId));
            //var descendants = children.Union(grandchildren);
        }

        public ActionResult GetSizes(int selectedValue)
        {
            List<Size> sizes = new List<Size>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                sizes = db.Sizes.OrderBy(s => s.SizeName).Where(x => x.SizeId == selectedValue).ToList();
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

        private static Product CreateProductFromViewMode(ProductVM model)
        {
            var product = new Product()
            {
                ProductId = model.ProductId,
                Productname = model.Productname,
                Category = model.Category,
            };

            if (model.ColorAttributes.Count > 0)
            {
                int id = -1;
                foreach (ColorAttributeVM colorAttribute in model.ColorAttributes ?? new List<ColorAttributeVM>())
                {
                    ColorAttribute colorDto = new ColorAttribute()
                    {
                        ColorAttributeId = id,
                        ColorId = colorAttribute.ColorId,
                        ProductId = colorAttribute.ProductId,
                        SizeAttributes = new List<SizeAttribute>()
                    };
                    id--;

                    if (model.ColorAttributes.Select(s => s.SizeAttributes).Any())
                    {

                        int sizeId = -1;
                        foreach (SizeAttributeVM sizeAttribute in colorAttribute.SizeAttributes ?? new List<SizeAttributeVM>())
                        {
                            SizeAttribute sizeDto = new SizeAttribute()
                            {
                                SizeId = sizeAttribute.SizeId,
                                SizeAttributeId = sizeId,
                                Quantity = sizeAttribute.Quantity,
                                ColorAttributeId = sizeAttribute.ColorAttributeId,
                            };
                            colorDto.SizeAttributes.Add(sizeDto);
                            sizeId--;

                        }
                    }

                    product.ColorAttributes.Add(colorDto);
                }
            }
            return product;
        }

        public ActionResult EditProduct(int? id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = db.Products.Find(id);
                var model2 = db.Products.Where(x => x.ProductId == id);
                var model3 = new ProductVM(model);
                return View(model3);
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            return View();
        }
    }

}