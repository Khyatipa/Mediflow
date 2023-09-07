using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mediflow.Pages.Chemist
{
    public class OrderCheckoutAddressModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public OrderCheckoutAddressModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }


        [BindProperty]
        public CRegister CRegister { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }

        public IActionResult OnGet()
        {
            ViewData["Msg"] = "Checkout";
            ViewData["MsgStep"] = "Delivery Details";

            ViewData["Tax"] = this.HttpContext.Session.GetString("tax");
            ViewData["Discount"] = this.HttpContext.Session.GetString("discountOnTotal");
            ViewData["ValueTotal"] = this.HttpContext.Session.GetString("valueTotal");
            ViewData["Payable"] = this.HttpContext.Session.GetString("payable");
            
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");

            if (a == null)
            {
                TempData["TempUser"] = cid;
                return RedirectToPage("/Home/LoginChemist");
            }

            CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            return Page();
        }

        public IActionResult OnPostEditAddress(string shopname, string address, string tele, string email,string delivery)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();

            if (shopname != null && address != null)
            {
                HttpContext.Session.SetString("ShopName", shopname);
                HttpContext.Session.SetString("ShopAdd", address);
                HttpContext.Session.SetString("Telephone", tele);
                HttpContext.Session.SetString("Email",email);
                HttpContext.Session.SetString("DeliveryMethod", delivery);

            }
            else
            {
              
              HttpContext.Session.SetString("ShopName", CRegister.ShopName);
              HttpContext.Session.SetString("ShopAdd", CRegister.Address + " " + CRegister.City + " " + CRegister.Zcode + " " + CRegister.State);
              HttpContext.Session.SetString("Telephone", CRegister.Mobile);
              HttpContext.Session.SetString("Email", CRegister.Email);
              HttpContext.Session.SetString("DeliveryMethod", delivery);
            }


            return RedirectToPage("OrderCheckoutPayment");
        }
    }
}
