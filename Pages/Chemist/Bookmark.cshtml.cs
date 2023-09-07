using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Mediflow.Pages.Chemist
{
    public class BookmarkModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;


        public BookmarkModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<BookMarkProductsChemist> Bookmark { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Msg"] = "Profile";
            var a = this.HttpContext.Session.GetString("username");
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
            else
            {

            }
            return Page();
    }
}
}
