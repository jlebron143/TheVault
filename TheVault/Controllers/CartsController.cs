using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;
using TheVault.ViewModels;

namespace TheVault.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string ShoppingCartId { get; set; }

        // GET: Carts
        public ActionResult Index()
        {
           
            var UserID = User.Identity.GetUserId();

            //need to filter db.carts. only need to see current users cart


            var viewModel = new ShoppingCartViewModel();
            viewModel.CartItems = db.Carts.Include("Item").Where(m => m.UserID == UserID).ToList();
            //{ I need to get all of this item totals , save 
            // 
            //    CartItems = cart.GetCartItems(),
            //    CartTotal = cart.GetTotal()
            //};

            return View(viewModel);
        }


        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,CartId,ItemId,Count,UserID,DateCreated")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        public ActionResult AddToCart(int? id)
        {
            //get current user 
            //get the item using the id just passed in 
            Cart cart = new Cart();
            cart.ItemId = (int)id;
            cart.Item = (from x in db.Items where x.ItemId == (int)id select x).First();
            cart.UserID = User.Identity.GetUserId();
            cart.Count = 1;
            cart.DateCreated = DateTime.Now;
            
            db.Carts.Add(cart);
            db.SaveChanges();

            return RedirectToAction("index");
        }

       
        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,CartId,ItemId,Count,UserID,DateCreated")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public void MigrateCart(string Email)
        {

            var shoppingCart = db.Carts.Where(
                c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = Email;

            }
            db.SaveChanges();
         }
        //public static Cart GetCart(HttpContextBase context)
        //{
        //    var shoppingCart = new Cart();
        //    shoppingCart.CartId = shoppingCart.Get(context)
        //    return shoppingCart;

        //}

        //public ActionResult RemoveFromCart(int id)
        //{
        //    var cartItem = db.Carts.Single(
        //        Cart = Cart.CartId == )
            
        //    int itemCount = 0;

        //    if (cartItem == null)
        //    {
        //        if (cartItem.Count > 1)
        //        {
        //            cartItem.Count--;
        //            itemCount = cartItem.Count;
        //        }
        //        else
        //        {
        //            db.Carts.Remove(cartItem);
        //        }

        //        db.SaveChanges();

        //        return RemoveFromCart;
        //    }
        //}



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
