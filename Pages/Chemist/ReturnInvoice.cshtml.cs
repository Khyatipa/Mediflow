using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtpNet;

namespace Mediflow.Pages.Chemist
{
    public class ReturnInvoiceModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;



        public ReturnInvoiceModel(Mediflow.DBModels.MediflowContext context)
        {

            _context = context;

        }

        public CRegister CRegister { get; set; }
        public ReturnMaster ReturnMaster { get; set; }
        public List<SpReturnInvoice> SpReturnInvoice { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }

        public IActionResult OnGet(int RMid)
        {
            ViewData["Msg"] = "Profile";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int tempOid = Convert.ToInt32(RMid);
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            var a = this.HttpContext.Session.GetString("username");
            //int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();

            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
            else
            {
                //NotifyChemist =
                CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
                ReturnMaster = _context.ReturnMaster.Where(i => i.RmasterId == tempOid).FirstOrDefault();
                //StockMasterList=_context

                SpReturnInvoice = _context.SpReturnInvoice.FromSqlRaw("ReturnOrderInvoice @CID", new SqlParameter("@CID", RMid)).ToList();
                
               


            }
            return Page();
        }
    }
}
