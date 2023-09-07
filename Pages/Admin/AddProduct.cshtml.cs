using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public AddProductModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

      

        [BindProperty]
        public Products Products { get; set; }

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
                return Page();
            }
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int HSN)
        {    

            if (!string.IsNullOrEmpty(Products.ItemName))
            {
                if (HSN == 3004)
                {
                    Products.HsnCode = 3004;
                    Products.MarginPercent = 0.28;
                    Products.GstPercent = 0.12;
                    Products.Rate = Products.Mrp - (Products.Mrp * 0.28);
                }
                else if (HSN == 3304)
                {
                    Products.HsnCode = 3004;
                    Products.MarginPercent = 0.32;
                    Products.GstPercent = 0.18;
                    Products.Rate = Products.Mrp - (Products.Mrp * 0.32);
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
                _context.Products.Add(Products);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Index");
        }
    }
}
