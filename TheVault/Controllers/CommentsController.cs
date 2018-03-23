using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;

namespace TheVault.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index(int? id)
        {
            if(id != null)
            {
                return View(db.Comments.Include(c => c.Message).Where(x => x.MessageID == id).ToList());
            }
            var comments = db.Comments.Include(c => c.Message);
            return View(comments.ToList());
        }

        //public PartialViewResult_Details_Partial(int? id)
        //{
        //    if (id != null)
        //    {
        //        return PartialView(db.Comments.Include(c => c.Message).Where(x => x.MessageID == id).ToList());
        //    }
        //    var comments = db.Comments.Include(c => c.Message);
        //    return PartialView(comments.ToList());
        //}

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.MessageID = new SelectList(db.Messages, "MessageID", "Subject");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "CommentID,Note,UserID,MessageID")] Comment comment, int? id)
        {
            if (ModelState.IsValid)
            {
               
                var currentUserId = User.Identity.GetUserId();

                comment.UserID = currentUserId;

                comment.MessageID = (int)id;
                db.Comments.Add(comment);
                db.SaveChanges();

                var message = (from x in db.Messages
                              where x.MessageID == comment.MessageID
                              select x).FirstOrDefault();

                message.RecipientID = currentUserId;

                //I have the user ID

                // userID is null , look to fix 

                var email = (from x in db.Users
                             where x.Id == currentUserId
                             select x).FirstOrDefault().Email;


                var body = "<p>Email From; {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var note = new MailMessage();
                note.To.Add(new MailAddress(email));
                note.From = new MailAddress("thevault.krj@gmail.com");
                note.Subject = "A response from The Vault!";
                note.Body = string.Format("You have received a response from The Vault in regards to your post. ");
                note.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "thevault.krj@gmail.com",
                        Password = "Thevault123$",
                };
                    //smtp.Credentials = new System.Net.NetworkCredential("thevault.krj@gmail.com", "thevault123$");
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(note);
                }
                TempData["Message"] = "Your comment has been saved and an email has been sent to the post creator.";
                return RedirectToAction("Confirmation");
            }
            ViewBag.MessageID = new SelectList(db.Messages, "MessageID", "Title", comment.MessageID);
            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CommentID,Note,UserID,MessageID")] Comment comment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Comments.Add(comment);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MessageID = new SelectList(db.Messages, "MessageID", "Subject", comment.MessageID);
        //    return View(comment);
        //}

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageID = new SelectList(db.Messages, "MessageID", "Subject", comment.MessageID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Note,UserID,MessageID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageID = new SelectList(db.Messages, "MessageID", "Subject", comment.MessageID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
