using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;  // DB nu context nu object banayo
        public IndexModel(Mediflow.DBModels.MediflowContext context)// index page nu constructor banayui
        {
            _context = context;
        }

        [BindProperty]

        public CRegister CLogin { get; set; }
        public List<Products> ProductList { get; set; }

        public IActionResult OnGet(string ss)
        {
            ViewData["Msg"] = "Homepage";
            ProductList = _context.Products.ToList();
            ViewData["Firstname"] = HttpContext.Session.GetString("Firstname");
            ViewData["status"] = HttpContext.Session.GetString("status");
            if (Convert.ToString(ViewData["status"]) == "Approved")
            {
                ViewData["status"] = "Approved";
            }
            else if (Convert.ToString(ViewData["status"]) == "Disapproved")
            {
                ViewData["status"] = "Disapproved";
            }
            else if (Convert.ToString(ViewData["status"]) == "Notapproved")
            {
                ViewData["status"] = "Pending";
            }


            if (ss == "Logout")
            {

                HttpContext.Session.Remove("username");
                HttpContext.Session.Remove("userId");
                HttpContext.Session.Clear();

                if (HttpContext.Session.GetString("userId") == null && HttpContext.Session.GetString("username") == null)
                {
                    ViewData["Msg"] = "Logout Successful";
                }
            }
            else
            {
                ViewData["Msg"] = "Null";
            }
            try
            {
                string kk = this.HttpContext.Session.GetString("PaymentType");
            }
            catch
            {

            }
            return Page();
        }



        public IActionResult OnPost()
        {

            return Page();
        }
        public IActionResult OnPostLogin()
        {
            ViewData["Msg"] = "Homepage";
            CLogin = _context.CRegister.FirstOrDefault(s => s.Username == CLogin.Username && s.Password == CLogin.Password);
            if (CLogin != null)
            {
                /*ViewData["status"] = CLogin.Status;*/ //CHECK FOR APPROVE OR NOT and show on home screen
                //HttpContext.Session.SetString("status", CLogin.Status);
                HttpContext.Session.SetString("username", CLogin.Username);
                HttpContext.Session.SetString("userId", Convert.ToString(CLogin.Id));
                HttpContext.Session.SetString("Firstname", CLogin.Fname);

                if (CLogin.Status == "Approved")
                {
                    HttpContext.Session.SetString("status", "Approved");
                    return RedirectToPage("/Chemist/HomePage", new { id = CLogin.Id });

                }
                else if (CLogin.Status == "Disapproved")
                {
                    HttpContext.Session.SetString("status", "Disapproved");
                    return RedirectToPage("/Home/Index", new { id = CLogin.Id });
                }
                else if (CLogin.Status == "NotApproved")
                {
                    HttpContext.Session.SetString("status", "Pending");
                    return RedirectToPage("/Home/Index", new { id = CLogin.Id });

                }// return RedirectToPage("/Chemist/Checkout/OrderCheckoutAddress", new { id = CLogin.Id });

            }

            ModelState.AddModelError("Error", "Please check mobile no or password");
            return Page();


        }
        public IActionResult OnPostRegister()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CLogin.Status = "Notapproved";
            _context.CRegister.Add(CLogin);
            _context.SaveChanges();

            // return RedirectToPage("/Home/LoginChemist");
            return RedirectToPage("/Chemist/OrderProducts");

        }
    }
}
