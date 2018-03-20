using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVault.Models;

namespace TheVault.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
            private ApplicationDbContext db = new ApplicationDbContext();
            const string PromoCode = "50";

            public ActionResult AddressAndPayment()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddressAndPayment(FormCollection values)
            {
                var order = new Order();
                TryUpdateModel(order);

                try
                {
                    if (string.Equals(values["PromoCode"], PromoCode,
                        StringComparison.OrdinalIgnoreCase) == false)
                    {
                        return View(order);
                    }
                    else
                    {
                        order.Username = User.Identity.Name;
                        order.OrderDate = DateTime.Now;


                        db.Orders.Add(order);
                        db.SaveChanges();


                        return RedirectToAction("Complete",
                            new { id = order.OrderId });
                    }
                }
                catch
                {

                    return View(order);
                }
            }
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            StripeConfiguration.SetApiKey("Stripe_Secret_Key");
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return View();
        }


        public ActionResult Complete(int id)
            {

                bool isValid = db.Orders.Any(
                    o => o.OrderId == id &&
                    o.Username == User.Identity.Name);

                if (isValid)
                {
                    return View(id);
                }
                else
                {
                    return View("Error");
                }
            }

        }
    }