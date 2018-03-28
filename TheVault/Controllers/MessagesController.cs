using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;
using System.Net.Mail;

namespace TheVault.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "MessageID,Subject,Comment,YourName,EmailAddress,UserID")] Message message, int? id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Messages.Add(message);
        //        db.SaveChanges();

        //        var post = from x in db.Messages
        //                   where x.MessageID == message.MessageID
        //                   select x.UserID;

        //        var UserID = post.FirstOrDefault();

        //        var email = (from x in db.Users
        //                     where x.Id == UserID
        //                     select x).FirstOrDefault().Email;

        //        var body = "<p>Email From; {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var note = new MailMessage();   
        //        note.To.Add(new MailAddress(email));
        //        note.From = new MailAddress("thevault.krj@gmail.com");
        //        note.Subject = "A response from The Vault!";
        //        note.Body = string.Format("You have received a response from The Vault in regards to your post. ");
        //        note.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            //{
        //            //    UserName = "thevault.krj@gmail.com";
        //            //    Password = "Thevault123$";
        //            //};
        //            smtp.Credentials = new System.Net.NetworkCredential("thevault.krj@gmail.com", "thevault123$");
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            await smtp.SendMailAsync(note);
        //        }
        //        TempData["Message"] = "Your comment has been saved and an email has been sent to the post creator.";
        //        return RedirectToAction("Confirmation");
        //    }
        //    ViewBag.MessageId = new SelectList(db.Messages, "MessageId", "Title", message.MessageID);
        //    return View(message);
        //}


        //            return RedirectToAction("Index");
        //    }

        //    return View(message);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,Subject,Comment,YourName,EmailAddress")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }
         
        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,Subject,Comment,YourName,EmailAddress")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
