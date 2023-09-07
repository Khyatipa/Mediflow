using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Admin
{
    public class ViewRegistersModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ViewRegistersModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public IList<CRegister> CRegister { get; set; }

        public IActionResult OnGet()
        {
            var a = this.HttpContext.Session.GetString("aUserName");

            if (a == null)
            {

                return RedirectToPage("/Admin/LoginAdmin");
            }
            else
            {
                ViewData["user"] = a;
                ViewData["Msg"] = "Profile";
                CRegister = _context.CRegister.ToList();
                return Page();
            }
        }

        public IActionResult OnPost(int ChemistId)
        {

            return Page();
        }



    }
}