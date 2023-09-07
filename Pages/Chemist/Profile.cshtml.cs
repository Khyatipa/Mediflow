using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;

namespace Mediflow.Pages.Chemist
{
    public class ProfileModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ProfileModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CRegister CRegister { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CRegister = await _context.CRegister.FirstOrDefaultAsync(m => m.Id == id);

            if (CRegister == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CRegister).State = EntityState.Modified;
             
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CRegisterExists(CRegister.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CRegisterExists(int id)
        {
            return _context.CRegister.Any(e => e.Id == id);
        }
    }
}
