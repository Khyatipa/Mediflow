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
    public class ProductDetailsModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ProductDetailsModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
                if (id == null)
                {
                    return NotFound();
                }

                Products = await _context.Products.FirstOrDefaultAsync(m => m.ItemId == id);

                if (Products == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
}
