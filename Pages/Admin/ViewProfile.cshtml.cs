using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Admin
{
    public class ViewProfileModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ViewProfileModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CRegister Chemist { get; set; }

        public IActionResult OnGet(int ChemistId)
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
                Chemist = _context.CRegister.FirstOrDefault(s => s.Id == ChemistId);
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id, string status, string CAC)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Chemist = _context.CRegister.Where(s => s.Id == id).FirstOrDefault();


            if (CAC == "1")
            {
                Chemist.IsCredit = true;
            }
            else if (CAC == "0")
            {
                Chemist.IsCredit = false;
            }
            else
            {
                Chemist.IsCredit = null;
            }


            if (status == "Approved")
            {
                Chemist.Status = status;
                _context.CRegister.Update(Chemist);

            }

            else if (status == "Disapproved")
            {
                Chemist.Status = status;
                _context.CRegister.Update(Chemist);
            }



            await _context.SaveChangesAsync();
            return RedirectToPage("ViewRegisters");

        }


    }


}
