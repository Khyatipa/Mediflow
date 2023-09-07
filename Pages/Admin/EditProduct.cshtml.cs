using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public EditProductModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Products Products { get; set; }

        public IActionResult OnGet(int? id)
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
                Products = _context.Products.FirstOrDefault(m => m.ItemId == id);
                return Page();
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file1 = Request.Form.Files[i];


                if (file1.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file1.CopyToAsync(stream);
                        switch (i)
                        {
                            case 0:
                                Products.Image = stream.ToArray();
                                break;
                            case 1:
                                Products.Image1 = stream.ToArray();
                                break;
                            case 2:
                                Products.Image2 = stream.ToArray();
                                break;
                        }
                    }
                }


            }

            //Products = _context.Products.FirstOrDefault(m => m.ItemId == idd);
            // _context.Products.Update(Products);

            _context.Attach(Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Products.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }



            return RedirectToPage("./ProductList");
        }


        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ItemId == id);
        }

    }
}
