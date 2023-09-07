using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace Mediflow.Pages.Chemist
{
    public class CartModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;


        public CartModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<SPCartDetails> SPCartDetails { get; set; }

        [BindProperty]
        public OrderCartDetails OrderCartDetail { get; set; }

        [BindProperty]
        public List<OrderCartDetails> OrderCartDetailList { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }


        // public IActionResult OnGetAsync(string id, Dictionary<int,int> changeQtyForItemId,string msg)

        public IActionResult OnGet(string id)
        {
            ViewData["Msg"] = "Homepage";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }

            if (id == null && a != null)
            {
                ViewData["countItem"] = countQty;

                //SqlParameter parameter = new SqlParameter("@CID",System.Data.SqlDbType.Int,50);
                //parameter.Value = cid;
                //SPCartDetails = await _context.SPCartDetails.FromSqlRaw("GetOrderCartDetails @cid",new SqlParameter("@cid", cid)).ToListAsync();

                double gstCharge05, gstCharge12, gstCharge18, gstCharge28, total05 = 0, total12 = 0, total18 = 0, total28 = 0;
                SPCartDetails = _context.SPCartDetails.FromSqlRaw("GetOrderCartDetails @CID", new SqlParameter("@CID", cid)).ToList();

                if (SPCartDetails.Count == 0)
                {
                    return RedirectToPage("/Chemist/OrderProducts");
                }
                else
                {

                    for (int i = 0; i < SPCartDetails.Count(); i++)
                    {
                        double tempGst = SPCartDetails[i].gstRate;
                        double tempMul;
                        switch (tempGst)
                        {
                            case 0.0:

                                //tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                                // total00 += tempMul;


                                break;
                            case 0.05:

                                tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                                total05 += tempMul;


                                break;

                            case 0.12:

                                tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                                total12 += tempMul;

                                break;

                            case 0.18:

                                tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                                total18 += tempMul;


                                break;

                            case 0.28:

                                tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                                total28 += tempMul;

                                break;

                            default:

                                break;

                        }

                    }
                    //    ////gstCharge00 = System.Math.Round(total12 * 0.12, 2);
                    //    //TempData["gst00"] = 0.0;

                    gstCharge05 = System.Math.Round(total05 * 0.05, 2);
                    TempData["gst5"] = gstCharge05;
                    TempData["gst2.5"] = gstCharge05 / 2;

                    gstCharge12 = System.Math.Round(total12 * 0.12, 2);
                    TempData["gst12"] = gstCharge12;
                    TempData["gst6"] = gstCharge12 / 2;

                    gstCharge18 = System.Math.Round(total18 * 0.18, 2);
                    ViewData["gst18"] = gstCharge18;
                    ViewData["gst9"] = gstCharge18 / 2;

                    gstCharge28 = System.Math.Round(total28 * 0.28, 2);
                    ViewData["gst28"] = gstCharge28;
                    ViewData["gst14"] = gstCharge28 / 2;

                    double totalGST = gstCharge05 + gstCharge12 + gstCharge18 + gstCharge28;
                    double totalsubGST = totalGST / 2;
                    ViewData["totalGST"] = totalGST;
                    ViewData["totalsubGST"] = totalsubGST;

                    //double paymentTotal = totalGST + Convert.ToDouble(TempData["gtotal"]);
                    // ViewData["paymentTotal"] = paymentTotal;

                    }

                }

            return Page();

        }

        public IActionResult OnGetLoadCart()
        {
            ViewData["Msg"] = "Homepage";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            double gstCharge05, gstCharge12, gstCharge18, gstCharge28, total05 = 0, total12 = 0, total18 = 0, total28 = 0;
            
            SPCartDetails = _context.SPCartDetails.FromSqlRaw("GetOrderCartDetails @CID", new SqlParameter("@CID", cid)).ToList();

            if (SPCartDetails.Count == 0)
            {
                return RedirectToPage("/Chemist/OrderProducts");
            }
            else
            {

                for (int i = 0; i < SPCartDetails.Count(); i++)
                {
                    double tempGst = SPCartDetails[i].gstRate;
                    double tempMul;
                    switch (tempGst)
                    {
                        case 0.0:

                            //tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            // total00 += tempMul;


                            break;
                        case 0.05:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total05 += tempMul;


                            break;

                        case 0.12:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total12 += tempMul;

                            break;

                        case 0.18:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total18 += tempMul;


                            break;

                        case 0.28:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total28 += tempMul;

                            break;

                        default:

                            break;

                    }

                }
                //    ////gstCharge00 = System.Math.Round(total12 * 0.12, 2);
                //    //TempData["gst00"] = 0.0;

                gstCharge05 = System.Math.Round(total05 * 0.05, 2);
                TempData["gst5"] = gstCharge05;
                TempData["gst2.5"] = gstCharge05 / 2;

                gstCharge12 = System.Math.Round(total12 * 0.12, 2);
                TempData["gst12"] = gstCharge12;
                TempData["gst6"] = gstCharge12 / 2;

                gstCharge18 = System.Math.Round(total18 * 0.18, 2);
                ViewData["gst18"] = gstCharge18;
                ViewData["gst9"] = gstCharge18 / 2;

                gstCharge28 = System.Math.Round(total28 * 0.28, 2);
                ViewData["gst28"] = gstCharge28;
                ViewData["gst14"] = gstCharge28 / 2;

                double totalGST = gstCharge05 + gstCharge12 + gstCharge18 + gstCharge28;
                double totalsubGST = totalGST / 2;
                ViewData["totalGST"] = totalGST;
                ViewData["totalsubGST"] = totalsubGST;

                //double paymentTotal = totalGST + Convert.ToDouble(TempData["gtotal"]);
                // ViewData["paymentTotal"] = paymentTotal;

            }
            return Page();
        }
        public IActionResult OnGetDelete(string Iid)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();

            if (Iid != null)
            {

                OrderCartDetail = _context.OrderCartDetails.Where(i => i.ItemId == Convert.ToInt32(Iid) && i.ChemistId == cid).FirstOrDefault();
                _context.OrderCartDetails.Remove(OrderCartDetail);
                _context.SaveChanges();
                countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
                ViewData["countItem"] = countQty;
                return new JsonResult("countQty");
            }
            return new JsonResult("countQty");

        }
        public IActionResult OnGetUpdate(string Oid, string ChangedQty)
        {
            if (Oid != null && ChangedQty != null)
            {

                OrderCartDetail = _context.OrderCartDetails.Where(i => i.OrderId == Convert.ToInt32(Oid)).FirstOrDefault();
                OrderCartDetail.ItemQty = Convert.ToInt32(ChangedQty);

                _context.OrderCartDetails.Attach(OrderCartDetail).State = EntityState.Modified;
                _context.SaveChanges();

                return new JsonResult("success");
            }

            return new JsonResult("Success");
        }

        public IActionResult OnGetCartSession(string valTot)
        {
            HttpContext.Session.SetString("valueTotal", valTot);
            double discount = System.Math.Round(Convert.ToDouble(valTot) * 0.02,2);
            HttpContext.Session.SetString("discountOnTotal", Convert.ToString(discount));

            double gstCharge05, gstCharge12, gstCharge18, gstCharge28, total05 = 0, total12 = 0, total18 = 0, total28 = 0;
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            SPCartDetails = _context.SPCartDetails.FromSqlRaw("GetOrderCartDetails @CID", new SqlParameter("@CID", cid)).ToList();

            if (SPCartDetails.Count == 0)
            {
                return RedirectToPage("/Chemist/OrderProducts");
            }
            else
            {

                for (int i = 0; i < SPCartDetails.Count(); i++)
                {
                    double tempGst = SPCartDetails[i].gstRate;
                    double tempMul;
                    switch (tempGst)
                    {
                        case 0.0:


                            break;
                        case 0.05:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total05 += tempMul;


                            break;

                        case 0.12:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total12 += tempMul;

                            break;

                        case 0.18:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total18 += tempMul;


                            break;

                        case 0.28:

                            tempMul = SPCartDetails[i].Rate * SPCartDetails[i].Qty;
                            total28 += tempMul;

                            break;

                        default:

                            break;

                    }

                }


                gstCharge05 = System.Math.Round(total05 * 0.05, 2);


                gstCharge12 = System.Math.Round(total12 * 0.12, 2);


                gstCharge18 = System.Math.Round(total18 * 0.18, 2);


                gstCharge28 = System.Math.Round(total28 * 0.28, 2);

                double totalGST = System.Math.Round(gstCharge05 + gstCharge12 + gstCharge18 + gstCharge28,2);
                double payable = System.Math.Round(totalGST + Convert.ToDouble(valTot) - discount,2);

                HttpContext.Session.SetString("tax", Convert.ToString(totalGST));
                HttpContext.Session.SetString("payable", Convert.ToString(payable));
               
                return new JsonResult("Success");
               
            }
        }
    }
}
