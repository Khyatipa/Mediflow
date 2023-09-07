using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Chemist
{
    public class DetailedProductModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public DetailedProductModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<Products> ProductList { get; set; }
        public List<NotifyChemist> NotifyChemist { get; set; }
        [BindProperty]
        public OrderCartDetails OrderCartDetail { get; set; }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, string Iid, string qty)
        
        {
            ViewData["Msg"] = "OrderPage";

            ProductList = _context.Products.ToList();
          
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            if (Iid!=null && qty != null)
           {
                OrderCartDetail = _context.OrderCartDetails.Where(i => i.ChemistId == cid && i.ItemId == Convert.ToInt32(Iid)).FirstOrDefault();

                if (OrderCartDetail != null)// Add to Db for same Item
                {
                    int temp = OrderCartDetail.ItemQty.Value;
                    int tempAdd = temp + Convert.ToInt32(qty);
                    OrderCartDetail.ItemQty = tempAdd;
                    _context.OrderCartDetails.Attach(OrderCartDetail).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else//add new item
                {
                    string Uid = this.HttpContext.Session.GetString("userId");

                    var s = new OrderCartDetails()
                    {
                        ItemQty = Convert.ToInt32(qty),
                        ItemId = Convert.ToInt32(Iid),
                        ChemistId = Convert.ToInt32(Uid)
                    };


                    _context.OrderCartDetails.Add(s);
                    _context.SaveChanges();
                }
                int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
                //HttpContext.Session.SetString("cartQty", Convert.ToString(countQty));
                //ViewData["countItem"] = countQty;

                return new JsonResult(countQty);

            }
            if (id == null)
            {
                return NotFound();
            }
            
            Products = await _context.Products.FirstOrDefaultAsync(m => m.ItemId == id);
            int count = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count;
            ViewData["countItem"] = count;


            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnPost()
        {

        }

        //public IActionResult OnGetAddProduct()
        //{
        //            }
    }
}
