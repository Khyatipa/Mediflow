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

namespace Mediflow.Pages.Admin
{
    public class OrderInvoiceModel : PageModel

    {
        public OrderInvoiceModel(Mediflow.DBModels.MediflowContext context)
        {

            _context = context;

        }

        [BindProperty]
        public OrderMaster OrderMaster { get; set; }

        [BindProperty]
        public CRegister cRegister { get; set; }

        [BindProperty]
        public OrderDeliveryDetails OrderDeliveryDetails { get; set; }

        [BindProperty]
        public List<OrderItemsDetails> OrderItemsDetails { get; set; }


        private readonly Mediflow.DBModels.MediflowContext _context;

        public IActionResult OnGet(string sts, int? iidd)

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
                int temp = (int)HttpContext.Session.GetInt32("cid");
                OrderMaster = _context.OrderMaster.Where(i => i.FinalOrderId == iidd).FirstOrDefault();
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                cRegister = _context.CRegister.Where(i => i.Id == temp).FirstOrDefault();
                OrderMaster.OrderStatus = sts;

                _context.OrderMaster.Update(OrderMaster);
                _context.SaveChanges();



                return new JsonResult("Success");
            }
        }

        public IActionResult OnPost(int? oid, int? cid)
        {
            ViewData["Msg"] = "Profile";
            if (oid == null)
            {
                return NotFound();
            }

            if (cid == null)
            {
                return NotFound();
            }

            else
            {
                HttpContext.Session.SetInt32("cid", (int)cid);
                OrderMaster = _context.OrderMaster.Where(i => i.FinalOrderId == oid).FirstOrDefault();
                OrderDeliveryDetails = _context.OrderDeliveryDetails.Where(i => i.FinalOrderId == oid).FirstOrDefault();
                cRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
                OrderItemsDetails = _context.OrderItemsDetails.FromSqlRaw("AdminOrderInvoice @OID", new SqlParameter("@OID", oid)).ToList();

            }
            return Page();
        }
    }
}

