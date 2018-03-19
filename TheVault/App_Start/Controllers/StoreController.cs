using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;


namespace TheVault.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            return View(categories);
        }



        public ActionResult Browse(string category)
        {
            var currentCategoryId = db.Categories.Where(c => c.Name == category).FirstOrDefault().CategoryID;
            //var categoryModel = db.Categories
            //    .Single(c => c.Name == category);
            var itemsThatMatchCategory = db.Items.Where(i => i.CategoryId == currentCategoryId).ToList();
            return View(itemsThatMatchCategory);

        }

        public ActionResult Details(int id)
        {
            var Item = db.Items.Find(id);
            return View(Item);
        }
    }
}

  


//public ActionResult Index()
//{
//    var category = new List<Category>
//                {
//                    new Category {Name =" Adidas" },
//                    new Category {Name =" Jordan" },
//                    new Category {Name =" Nike" },
//                    new Category {Name =" Reebox" },
//                    new Category {Name =" Under Armour" },
//                };
//    return View();
//}



//public ActionResult Browse(string category)
//{
//    var categoryModel = new Category { Name = category };
//    return View(categoryModel);

//}

//public ActionResult Details(int id)
//{
//    var Item = new Item { Title = "Item" + id };
//    return View(Item);
//}