using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mediflow.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Mediflow.Pages.Chemist
{

    public class OrderProductsModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public OrderProductsModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<StockMaster> StockMaster { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }
        public BookMarkProductsChemist BookMarkProductsChemist { get; set; }

        public List<BookMarkProductsChemist> BookMarkProductsChemistList { get; set; }
        public List<Products> ProductList { get; set; }

        [BindProperty]
        public Products Product { get; set; }

        [BindProperty]
        public OrderCartDetails OrderCartDetail { get; set; }

        [BindProperty]
        public List<OrderCartDetails> OrderCartDetailList { get; set; }
        public CRegister CRegister { get; private set; }

        public IActionResult OnGet(string id, string qty,string cat)
        {
            ViewData["Msg"] = "OrderPage";
            var a = this.HttpContext.Session.GetString("username");
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int countQQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
            ViewData["isEligible"] = CRegister.Status;

           // HttpContext.Session.SetInt32("cartQty", countQty);
            ViewData["countItem"] = countQQty;
            ViewData["Msg"] = "OrderPage";

            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
            else if (a != null)
            {
                
                if (qty == null)
                {
                    if (cat != null)
                    {
                        ProductList = _context.Products.Where(s => s.ProductCategory == cat).ToList();
                        BookMarkProductsChemistList = _context.BookMarkProductsChemist.Where(i => i.ChemistId == cid).ToList();
                        StockMaster = _context.StockMaster.Where(i=>i.IsActive==true).ToList();
                        NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
                        string caseCategory = cat;
                        switch (caseCategory)
                        {
                            case "DER": ViewData["catName"] = "Derma"; break;
                            case "GEN": ViewData["catName"] = "General"; break;
                            case "GYE": ViewData["catName"] = "Gynae"; break;
                            case "CD": ViewData["catName"] = "Cardiac-Diabetic"; break;
                            default:
                                ViewData["catName"] = "All Category"; break;
                    }
                        return Page();

                    }
                    ProductList = _context.Products.ToList();
                    BookMarkProductsChemistList = _context.BookMarkProductsChemist.Where(i => i.ChemistId == cid).ToList();
                    StockMaster = _context.StockMaster.Where(i => i.IsActive == true).ToList();
                    NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
                    int count = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count;
                    ViewData["countItem"] = count;
                    ViewData["catName"] = "All Category";
                    return Page();
                }
              
                else if (id != null && qty != null) //Logic for Add to cart
                {
                    ProductList = _context.Products.ToList();
                    OrderCartDetail = _context.OrderCartDetails.Where(i => i.ChemistId == cid && i.ItemId == Convert.ToInt32(id)).FirstOrDefault();

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
                            ItemId = Convert.ToInt32(id),
                            ChemistId = Convert.ToInt32(Uid)
                        };


                        _context.OrderCartDetails.Add(s);
                        _context.SaveChanges();
                    }

                    int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
                   // HttpContext.Session.SetString("cartQty", Convert.ToString(countQty));
                    //ViewData["countItem"] = countQty;



                    return new JsonResult(countQty);

                }

                


            }

            return Page();
        }


      
        public IActionResult OnPost(string id, string qty)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            ProductList = _context.Products.ToList();
            OrderCartDetail = _context.OrderCartDetails.Where(i => i.ChemistId == cid && i.ItemId == Convert.ToInt32(id)).FirstOrDefault();

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
                    ItemId = Convert.ToInt32(id),
                    ChemistId = Convert.ToInt32(Uid)
                };


                _context.OrderCartDetails.Add(s);
                _context.SaveChanges();
            }
                int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
                HttpContext.Session.SetString("cartQty", Convert.ToString(countQty));
                ViewData["countItem"] = countQty;
            return Page();
               // return new JsonResult(countQty);    
            }
      

        public IActionResult OnPostSearchItem(string ItemName)
        {
            ViewData["Msg"] = "OrderPage";
            if (ItemName != null)
            {
                int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
                BookMarkProductsChemistList = _context.BookMarkProductsChemist.Where(i => i.ChemistId == cid).ToList();
                StockMaster = _context.StockMaster.Where(i => i.IsActive == true).ToList();
                ProductList = _context.Products.Where(i => i.ItemName.Contains(ItemName)).ToList();
               
            }
            else
            {
                ProductList = _context.Products.ToList();
            }
            return Page();
        }
      
        public IActionResult OnPostFilter(string cat)
        {
            ViewData["Msg"] = "OrderPage";
            if (cat != null)
            {
                StockMaster = _context.StockMaster.Where(i => i.IsActive == true).ToList();
                int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
                BookMarkProductsChemistList = _context.BookMarkProductsChemist.Where(i => i.ChemistId == cid).ToList();

                ProductList = _context.Products.Where(s => s.ProductCategory == cat).ToList();
                ViewData["catName"] = cat;
            }
            return Page();

        }
        public IActionResult Logout(string ItemName)
        {
            if (ItemName != null)
            {
                ProductList = _context.Products.Where(i => i.ItemName.Contains(ItemName)).ToList();

            }
            else
            {
                ProductList = _context.Products.ToList();
            }
            return Page();
        }

        public IActionResult OnPostSort(string AplhaSort)
        {
            ViewData["Msg"] = "OrderPage";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            StockMaster = _context.StockMaster.Where(i => i.IsActive == true).ToList();
            BookMarkProductsChemistList = _context.BookMarkProductsChemist.Where(i => i.ChemistId == cid).ToList();
            if (AplhaSort == "NamewiseAsc")
            {
              

                ProductList = _context.Products.OrderBy(s => s.ItemName).ToList();

            }
            else if (AplhaSort == "NamewiseDsc")
            {
                ProductList = _context.Products.OrderByDescending(s => s.ItemName).ToList();
            }
            return Page();
        }


        public IActionResult OnGetBookmarkProduct(string itemid)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int itemID = Convert.ToInt32(itemid);
            
                BookMarkProductsChemist = _context.BookMarkProductsChemist.Where(i => i.BookedItemId == itemID & i.ChemistId == cid).FirstOrDefault();
                if (BookMarkProductsChemist == null)
                {
                    var tempBook = new BookMarkProductsChemist()
                    {
                        BookedItemId = itemID,
                        ChemistId = cid,
                        Flag = true

                    };
                    _context.BookMarkProductsChemist.Add(tempBook);
                    _context.SaveChanges();
                    return new JsonResult(0);
                }
               else if(BookMarkProductsChemist!=null && BookMarkProductsChemist.Flag==true)
                   
               {
                 
                        _context.BookMarkProductsChemist.Remove(BookMarkProductsChemist);
                        _context.SaveChanges();
                                                   

                    return new JsonResult(1);
                

                }


            return new JsonResult("Bookmark Proper");
        }
    }
}
