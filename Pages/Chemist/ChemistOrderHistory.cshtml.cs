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
    public class ChemistOrderHistoryModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;


        public ChemistOrderHistoryModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }
        public IList<OrderMaster> OrderMaster { get; set; }
        public List<NotifyChemist> NotifyChemist { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Msg"] = "Profile";
            var a = this.HttpContext.Session.GetString("username");
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            ViewData["countItem"] = countQty;
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }

           
            OrderMaster = _context.OrderMaster.Where(i => i.ChemistId == cid).OrderByDescending(k => k.OrderDate).ToList();
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
           
            return Page();
        }

        public void OnGetForward()
        {

        }
    }
}
