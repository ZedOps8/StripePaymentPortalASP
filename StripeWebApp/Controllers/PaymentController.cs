using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;
using StripeWebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StripeWebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly MvcContext _context;

        // Constructor to initialize PaymentController with MvcContext
        public PaymentController(MvcContext context)
        {
            _context = context;
        }

        // Action method to display the list of items available for purchase
        public async Task<IActionResult> Index()
        {
            // Asynchronously retrieve the list of items from the database
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        // Action method to create a new checkout session
        [HttpPost]
        public IActionResult CreateCheckout(string priceId)
        {
            // Check if priceId is provided; if not, return a bad request response
            if (string.IsNullOrEmpty(priceId))
            {
                return BadRequest("Invalid price ID.");
            }

            // Define the domain URL (ensure it matches your environment)
            var domain = "http://localhost:7283"; // Adjust if necessary for production

            // Set up Stripe Checkout session options
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = priceId, // Use the priceId passed from the form
                        Quantity = 1,   // Set the quantity of the item
                    },
                },
                Mode = "payment", // Use "payment" mode for a one-time payment
                SuccessUrl = domain + "/Payment/Success", // URL to redirect on successful payment
                CancelUrl = domain + "/Payment/Cancel",   // URL to redirect if payment is canceled
            };

            // Create a new instance of SessionService to interact with Stripe
            var service = new SessionService();
            Session session = service.Create(options); // Create the checkout session

            // Redirect to the Stripe Checkout page
            return Redirect(session.Url);
        }

        // Action method to display the success view after successful payment
        public IActionResult Success()
        {
            return View();
        }

        // Action method to display the cancel view if payment is canceled
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
