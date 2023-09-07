using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Shared
{
    public class _ChemistHomeModel : PageModel
    {
        public IActionResult OnGet()
        {
            ViewData["Test"] = "Nonsense";

            return Page();        }
    }
}
