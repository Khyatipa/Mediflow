using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Mediflow.Pages.IntroPage
{
    public class UpdateProfileRegisterModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public UpdateProfileRegisterModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<NotifyChemist> NotifyChemist { get; private set; }

        [BindProperty]
        public CRegister CRegister { get; set; }

        public async Task<IActionResult> OnGetAsync(/*int? id*/)

        {
            ViewData["Msg"] = "Profile";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");

            if (a == null)
            {
                TempData["TempUser"] = cid;
                return RedirectToPage("/Home/LoginChemist");
            }
            else
            {
                NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
                CRegister = await _context.CRegister.FirstOrDefaultAsync(m => m.Id == cid);

                if (CRegister == null)
                {
                    return NotFound();
                }
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

            var file1 = Request.Form.Files[0];
            if (file1.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file1.CopyToAsync(stream);
                    CRegister.DocumentImg = stream.ToArray();
                }
            }
                //  _context.Attach(CRegister.Password)
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

            return RedirectToPage("/Chemist/HomePage");
        }

        private bool CRegisterExists(int id)
        {
            return _context.CRegister.Any(e => e.Id == id);
        }
    }
}
