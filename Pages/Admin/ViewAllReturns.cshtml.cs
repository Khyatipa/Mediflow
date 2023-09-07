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
    public class ViewAllReturnsModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ViewAllReturnsModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }
        public List<SpGetInstantReturn> SpGetInstantReturn { get; set; }
        public List<SPGetReturn> SPGetReturn { get; set; }
     
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
               
                SPGetReturn = _context.SPGetReturn.FromSqlRaw("GetReturns").ToList();
                SpGetInstantReturn = _context.SpGetInstantReturn.FromSqlRaw("GetReturnsInstant").ToList();
                return Page();
            }
        }
    }
}
