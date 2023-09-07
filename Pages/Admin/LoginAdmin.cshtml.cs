using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Admin
{
    public class LoginAdminModel : PageModel
    {

        private readonly Mediflow.DBModels.MediflowContext _context;  // DB nu context nu object banayo

        public LoginAdminModel(Mediflow.DBModels.MediflowContext context)// index page nu constructor banayui
        {
            _context = context;
        }

        public IActionResult OnGet(string ss)
        {
            if (ss == "Logout")
            {

                HttpContext.Session.Remove("userAId");
                HttpContext.Session.Remove("aUserName");
                HttpContext.Session.Clear();

                if (HttpContext.Session.GetString("userAId") == null && HttpContext.Session.GetString("aUserName") == null)
                {
                    ViewData["Msg"] = "Logout Successful";
                }
            }
            else
            {
                ViewData["Msg"] = "Null";
            }
            
            return Page();
          
        }

        [BindProperty]

        public ARegister ALogin { get; set; }

        public IActionResult OnPost()
        {
          ALogin = _context.ARegister.FirstOrDefault(s => s.AdminName == ALogin.AdminName && s.AdminPwd == ALogin.AdminPwd);
            if (ALogin != null)
            {
               
                HttpContext.Session.SetString("userAId", Convert.ToString(ALogin.Id));
               
                HttpContext.Session.SetString("aUserName", ALogin.AdminName);
                return RedirectToPage("Index");
            }

            ModelState.AddModelError("Error", "Please check mobile no or password");
            return Page();

        }

       
    }
}
