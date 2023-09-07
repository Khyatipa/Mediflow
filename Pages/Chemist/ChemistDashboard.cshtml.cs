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
    public class ChemistDashboardModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public ChemistDashboardModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }
        public OrderCartDetails OrderCartDetail { get; set; }
        public List<OrderMaster> OrderMaster { get; set; }
        public List<NotifyChemist> NotifyChemist { get; set; }
        public IActionResult OnGet()

        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
           // LayoutCommon collectDetials = new LayoutCommon();
            int countQQty = 0;
            countQQty= _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            ViewData["DetailsMsg"] = "DisplayDetials";

            //collectDetials.LoadDetials(cid); //calling method of common layout

            ViewData["countItem"] = countQQty;//collectDetials.LoadCount(cid);
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/Index");
            }
            ViewData["Msg"] = "Profile";
            ViewData["DetailsMsg"] = "DisplayDetials";
            return Page();
        }
        public IActionResult OnGetLoadAreaChart()
        {
            int[] barArray = new int[] { }; 
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int MonCt=0,TueCt=0,WedCt=0,ThusCt=0,FriCt=0,SatCt=0;
            OrderMaster = _context.OrderMaster.Where(i => i.ChemistId == cid && (i.OrderDate<=DateTime.Now && i.OrderDate>DateTime.Now.AddDays(-30))).ToList();
            for(int i=0;i<OrderMaster.Count();i++)
            {
                
                var currDate = DateTime.Now;
                string temp = OrderMaster[i].OrderDate.Value.ToString("dddd");
                switch (temp)
                {
                    case "Monday":      MonCt++;
                        break;
                    case "Tuesday":     TueCt++;
                        break;
                    case "Wednesday":   WedCt++;
                        break;
                    case "Thursday":    ThusCt++;
                        break;
                    case "Friday":      FriCt++;
                        break;
                    case "Saturday":    SatCt++;
                        break;
                    default:
                        break;
                }

            }
            int[] tempArray= { MonCt, TueCt, WedCt, ThusCt, FriCt, SatCt };
            return new JsonResult(tempArray);
        }
    }
}
