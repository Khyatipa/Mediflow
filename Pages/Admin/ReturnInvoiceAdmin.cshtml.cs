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
    public class ReturnInvoiceAdminModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;



        public ReturnInvoiceAdminModel(Mediflow.DBModels.MediflowContext context)
        {

            _context = context;

        }

        public CRegister CRegister { get; set; }
        public ReturnMaster ReturnMaster { get; set; }
        public List<SpReturnInvoice> SpReturnInvoice { get; set; }
      
        public IActionResult OnGet(int RMid)
        {
            var a = this.HttpContext.Session.GetString("aUserName");

            if (a == null)
            {

                return RedirectToPage("/Admin/LoginAdmin");
            }
            else
            {
                ViewData["Msg"] = "Profile";

                int tempOid = Convert.ToInt32(RMid);


                //NotifyChemist =

                ReturnMaster = _context.ReturnMaster.Where(i => i.RmasterId == tempOid).FirstOrDefault();
                CRegister = _context.CRegister.Where(i => i.Id == ReturnMaster.RmCid).FirstOrDefault();
                //StockMasterList=_context

                SpReturnInvoice = _context.SpReturnInvoice.FromSqlRaw("ReturnOrderInvoice @CID", new SqlParameter("@CID", RMid)).ToList();
               
            } 


            return Page();
        }
    }
}
