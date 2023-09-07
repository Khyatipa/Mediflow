using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Admin
{
    public class ViewOrdersModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ViewOrdersModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public IList<Products> ProductList { get; set; }
        public IList<FetchOrders> FetchOrders { get; set; }

        public IList<OrderTransaction> OrderTransactions { get; set; }

        public IActionResult OnGet()
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
                ProductList = _context.Products.ToList();
                FetchOrders = _context.FetchOrders.FromSqlRaw("GetTotalOrders").ToList();

                return Page();
            }
        }



    }
}

