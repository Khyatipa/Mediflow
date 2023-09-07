using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Mediflow.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public IndexModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get; set; }
        public List<CRegister> Registers { get; private set; }
        public IList<OrderMaster> OrderMaster  { get; set; }
        public List<ReturnMaster> ReturnMaster { get; private set; }

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
                Products = _context.Products.ToList();
                Registers = _context.CRegister.ToList();
                OrderMaster = _context.OrderMaster.ToList();
                ReturnMaster = _context.ReturnMaster.ToList();
                return Page();
            }            
        }

        public IActionResult OnGetLoadAreaChart()
        {
            int[] barArray = new int[] { };
           
            int Jan = 0, Feb = 0, Mar = 0, Apr = 0, May = 0, June = 0, Jul=0, Aug=0, Sept=0, Oct=0, Nov=0, Dec=0;
            OrderMaster = _context.OrderMaster.Where(k=>k.OrderDate <= DateTime.Now && k.OrderDate > DateTime.Now.AddMonths(-12)).ToList();
            for (int i = 0; i < OrderMaster.Count(); i++)
            {

                var currDate = DateTime.Now;
                string temp = OrderMaster[i].OrderDate.Value.ToString("MMMM");
                switch (temp)
                {
                    case "January":
                        Jan++;
                        break;
                    case "February":
                        Feb++;
                        break;
                    case "March":
                        Mar++;
                        break;
                    case "April":
                        Apr++;
                        break;
                    case "May":
                        May++;
                        break;
                    case "June":
                        June++;
                        break;
                    case "July":
                        Jul++;
                        break;
                    case "August":
                        Aug++;
                        break;
                    case "September":
                        Sept++;
                        break;
                    case "October":
                        Oct++;
                        break;
                    case "November":
                        Nov++;
                        break;
                    case "December":
                        Dec++;
                        break;
                    default:
                        break;
                }

            }
            int[] tempArray = { Jan, Feb, Mar, Apr, May, June, Jul, Aug, Sept, Oct, Nov, Dec };
            return new JsonResult(tempArray);
        }


        public IActionResult OnGetLoadCircle()
        {
           

            int app = 0, dis = 0, pend = 0;
            Registers = _context.CRegister.ToList();
            for (int i = 0; i < Registers.Count(); i++)
            {

              
                string temp = Registers[i].Status;
                switch (temp)
                {
                    case "Approved":
                        app++;
                        break;
                    case "NotApproved":
                        pend++;
                        break;
                    case "Disapproved":
                        dis++;
                        break;
                 
                    default:
                        break;
                }

            }
            int[] tempArray = { app,pend,dis };
            return new JsonResult(tempArray);
        }

        public IActionResult OnGetLoadLine()
        {
            
           
            int MonCt = 0, TueCt = 0, WedCt = 0, ThusCt = 0, FriCt = 0, SatCt = 0;
            OrderMaster = _context.OrderMaster.Where(k=>k.OrderDate <= DateTime.Now && k.OrderDate > DateTime.Now.AddDays(-7)).ToList();
            for (int i = 0; i < OrderMaster.Count(); i++)
            {

                var currDate = DateTime.Now;
                string temp = OrderMaster[i].OrderDate.Value.ToString("dddd");
                switch (temp)
                {
                    case "Monday":
                        MonCt++;
                        break;
                    case "Tuesday":
                        TueCt++;
                        break;
                    case "Wednesday":
                        WedCt++;
                        break;
                    case "Thursday":
                        ThusCt++;
                        break;
                    case "Friday":
                        FriCt++;
                        break;
                    case "Saturday":
                        SatCt++;
                        break;
                    default:
                        break;
                }

            }
            int[] tempArray = { MonCt, TueCt, WedCt, ThusCt, FriCt, SatCt };
            return new JsonResult(tempArray);
        }
    }
}
