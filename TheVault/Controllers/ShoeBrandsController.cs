using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;

namespace TheVault.Controllers
{
    public class ShoeBrandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoeBrands
        public ActionResult Index()
        {
            return View(db.ShoeBrands.ToList());
        }

        // GET: ShoeBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeBrand shoeBrand = db.ShoeBrands.Find(id);
            if (shoeBrand == null)
            {
                return HttpNotFound();
            }
            return View(shoeBrand);
        }

        // GET: ShoeBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoeBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoeBrandID,Brands")] ShoeBrand shoeBrand)
        {
            if (ModelState.IsValid)
            {
                db.ShoeBrands.Add(shoeBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoeBrand);
        }

        // GET: ShoeBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeBrand shoeBrand = db.ShoeBrands.Find(id);
            if (shoeBrand == null)
            {
                return HttpNotFound();
            }
            return View(shoeBrand);
        }

        // POST: ShoeBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoeBrandID,Brands")] ShoeBrand shoeBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoeBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoeBrand);
        }

        // GET: ShoeBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeBrand shoeBrand = db.ShoeBrands.Find(id);
            if (shoeBrand == null)
            {
                return HttpNotFound();
            }
            return View(shoeBrand);
        }

        // POST: ShoeBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoeBrand shoeBrand = db.ShoeBrands.Find(id);
            db.ShoeBrands.Remove(shoeBrand);
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
