using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Admin
{
    public class EditStockModel : PageModel
    {

        private readonly Mediflow.DBModels.MediflowContext _context;
        public EditStockModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<StockMaster> StockMasterList { get; set; }

        [BindProperty]
        public StockMaster StockMaster { get; set; }

        public StockMaster StockMasterActive { get; set; }
        public StockMaster StockMasterCheck { get; set; }

        [BindProperty]
        public Products Products { get; set; }




        public IActionResult OnGet(int? id, int stockid)
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

                Products = _context.Products.FirstOrDefault(m => m.ItemId == id);

                StockMasterList = _context.StockMaster.Where(i => i.SitemId == id).ToList();

                StockMaster = _context.StockMaster.Where(i => i.StockId == stockid).FirstOrDefault();

                StockMasterCheck = _context.StockMaster.Where(i => i.SitemId == id).FirstOrDefault();

                return Page();
            }
        }

        public IActionResult OnPostUpdateStock()
        {
          
           
            //if (StockMasterCheck != null)
            //{
              
                _context.StockMaster.Add(StockMaster);

                _context.SaveChanges();
            //}
            //else
            //{

            //}
            return RedirectToPage("/Admin/ProductList");
        }


        public IActionResult OnPostUpdateCurrentStock(int btnedit_id,string EditStockBtn,int Iid)
        {
            ViewData["Msg"] = "Profile";
           
            if (EditStockBtn != "Edit")
            {
                Products = _context.Products.Where(m => m.ItemId == Iid).FirstOrDefault();
                StockMasterList = _context.StockMaster.Where(i => i.SitemId == Iid).ToList();
                StockMaster = _context.StockMaster.Where(i => i.StockId == btnedit_id).FirstOrDefault();
                ViewData["EditMsg"] = "EditStock";
               
            }
            else if(EditStockBtn == "Edit")
            {

                //  StockMaster = _context.StockMaster.Where(i => i.StockId == Sid).FirstOrDefault();
                // _context.StockMaster.Update(StockMaster);
                _context.Attach(StockMaster).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToPage("/Admin/EditStock", new { id = Iid, stockid = btnedit_id });
            }
            return Page();
        }

        public IActionResult OnGetEnableDisableStock(string Sid,bool Status,string ProductId)
        {

            StockMasterActive = _context.StockMaster.Where(i => i.IsActive == true).FirstOrDefault();
          //  StockMasterList = _context.StockMaster.Where(i => i.SitemId == Convert.ToInt32(ProductId)).ToList();

            //for(int i=0;i<StockMasterList.Count;i++)
            //{
            //    StockMasterList[i].IsActive= false;
            //    StockMaster = StockMasterList[i];
            //    _context.StockMaster.Update(StockMaster);
            //    _context.SaveChanges();
            //}
          StockMaster = _context.StockMaster.Where(i => i.StockId == Convert.ToInt32(Sid)).FirstOrDefault();
            StockMasterActive.IsActive = false;
            StockMaster.IsActive=Status;
            _context.Update(StockMaster);
            _context.Update(StockMasterActive);
            _context.SaveChanges();
            return new JsonResult("success");
            
        }
    }
}
