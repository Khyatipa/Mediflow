using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Mediflow.Pages.Admin
{
    public class ProductListModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ProductListModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get; set; }
        public IList<StockMaster> StockMaster { get; set; }
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
                Products = _context.Products.ToList();
                StockMaster = _context.StockMaster.ToList();

                return Page();
            }
        }
    }
}
