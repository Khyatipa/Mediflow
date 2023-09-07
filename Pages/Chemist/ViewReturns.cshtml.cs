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
    public class ViewReturnsModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;


        public ViewReturnsModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }
        public IList<OrderMaster> OrderMaster { get; set; }
        public List<NotifyChemist> NotifyChemist { get; set; }

        public List<ReturnMaster> ReturnMasterList { get; set; }
        public IActionResult  OnGet()
        {
            ViewData["Msg"] = "Profile";
            var a = this.HttpContext.Session.GetString("username");
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            ViewData["countItem"] = countQty;
            ReturnMasterList = _context.ReturnMaster.Where(i => i.RmCid == cid).ToList();
            OrderMaster = _context.OrderMaster.Where(i => i.ChemistId == cid).OrderByDescending(k => k.OrderDate).ToList();
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();

            return Page();

        }
    }
}
