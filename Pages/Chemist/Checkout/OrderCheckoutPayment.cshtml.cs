using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Chemist.Checkout
{
    public class OrderCheckoutPaymentModel : PageModel
    {

        private readonly Mediflow.DBModels.MediflowContext _context;

        public OrderCheckoutPaymentModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }


        [BindProperty]
        public CRegister CRegister { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }

        public IActionResult OnGet()
        {
            ViewData["Msg"] = "Checkout";
            ViewData["MsgStep"] = "Payment";

            ViewData["Tax"] = this.HttpContext.Session.GetString("tax");
            ViewData["Discount"] = this.HttpContext.Session.GetString("discountOnTotal");
            ViewData["ValueTotal"] = this.HttpContext.Session.GetString("valueTotal");
            ViewData["Payable"] = this.HttpContext.Session.GetString("payable");
           
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            if (a == null)
            {
                TempData["TempUser"] = cid;
                return RedirectToPage("/Home/LoginChemist");
            }

            CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
            return Page();
        }

        public IActionResult OnPostPaymentMethod(string payment)
        {
            if(payment=="credit")
            {
                HttpContext.Session.SetString("PaymentType","true");
            }
            else if (payment == "cash")
            {
                HttpContext.Session.SetString("PaymentType","false");
            }
            else if(payment=="online")
            {
                HttpContext.Session.SetString("PaymentOnline", "online");
            }

            return RedirectToPage("/Chemist/CHeckout/OrderCheckoutReview");
        }
    }
}
