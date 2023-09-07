using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages
{
    public class TempEditProductModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Msg"] = "Profile";
        }
    }
}
