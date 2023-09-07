using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages
{
    public class HomePageModel : PageModel
    {

        private readonly Mediflow.DBModels.MediflowContext _context;

        public HomePageModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<OrderTransaction> OrderTransactionList { get; private set; }
        public List<Products> ProductList { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }

        public void OnGet()
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            ViewData["Msg"] = "Homepage";
            OrderTransactionList = _context.OrderTransaction.ToList();
            ProductList = _context.Products.ToList();
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            TempData["username"] = HttpContext.Session.GetString("username");
        }
    }
}
