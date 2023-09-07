using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediflow.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Mediflow.Pages.Chemist.Checkout
{
    public class OrderCheckoutReviewModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;


        public OrderCheckoutReviewModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<SPCartDetails> SPCartDetails { get; set; }

        [BindProperty]
        public OrderCartDetails OrderCartDetails { get; set; }

        [BindProperty]
        public List<OrderCartDetails> OrderCartDetailList { get; set; }

        public OrderMaster OrderMaster { get; set; }
        public IList<OrderTransaction> OrderTransaction { get; set; }

        public OrderDeliveryDetails OrderDeliveryDetails { get; set; }
        public StockMaster StockMaster { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }

        //public NotifyChemist NotifyChemist { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Msg"] = "Checkout";
            ViewData["MsgStep"] = "Order Review";
            ViewData["Tax"] = this.HttpContext.Session.GetString("tax");
            ViewData["Discount"] = this.HttpContext.Session.GetString("discountOnTotal");
            ViewData["ValueTotal"] = this.HttpContext.Session.GetString("valueTotal");
            ViewData["Payable"] = this.HttpContext.Session.GetString("payable");
          
            HttpContext.Session.GetString("ShopName");
            HttpContext.Session.GetString("ShopAdd");
            HttpContext.Session.GetString("Telephone");
            HttpContext.Session.GetString("Email");


            string tempAdd = this.HttpContext.Session.GetString("addressDetails");

            bool payment = Convert.ToBoolean(this.HttpContext.Session.GetString("PaymentType"));
            
            if (this.HttpContext.Session.GetString("PaymentOnline") == "online")
            {
                ViewData["PayType"] = "Online";
            }
            else if (payment == true)
            {
                ViewData["PayType"] = "Credit";
            }
            else if(payment==false)
            {
                ViewData["PayType"] = "Cash";
            }
           


            double gstCharge05, gstCharge12, gstCharge18, gstCharge28, total05 = 0, total12 = 0, total18 = 0, total28 = 0;
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
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
                ViewData["totalGST"] = System.Math.Round(totalGST,2);
                ViewData["totalsubGST"] = System.Math.Round(totalsubGST,2);

             

            }


            return Page();
        }

        public IActionResult OnGetOrder(string valTot, string gstTot, string payTot, string discount)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var a = this.HttpContext.Session.GetString("username");
            string dtype = this.HttpContext.Session.GetString("DeliveryMethod");
            if (dtype!="send")
            {
                dtype = "Pickup";
            }
            string tempPayment = this.HttpContext.Session.GetString("PaymentType");
            string tempOnlinePyament = this.HttpContext.Session.GetString("PaymentOnline");
            bool payment = Convert.ToBoolean(tempPayment);
            if (payTot != null)
            {
                var s = new OrderMaster()
                {
                    ChemistId = Convert.ToInt32(cid),
                    ValuePrice = Convert.ToDouble(valTot),
                    Discount = Convert.ToDouble(discount),
                    GstCharges = Convert.ToDouble(gstTot),
                    FinalPayable = Convert.ToDouble(payTot),
                    OrderDate = DateTime.Now,
                    OrderStatus = "Received",
                    IsCredit = payment,
                    DeliveryType=dtype 
                };

                _context.OrderMaster.Add(s);
                _context.SaveChanges();
                int finalorderid = s.FinalOrderId;

                if (s != null)
                {
                    OrderCartDetailList = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList();
                  
                    //Adding Enteries in Transaction from Cart table
                    
                    for (int i = 0; i < OrderCartDetailList.Count(); i++)
                    {
                        StockMaster = _context.StockMaster.Where(k => k.SitemId == OrderCartDetailList[i].ItemId && k.IsActive == true).FirstOrDefault();

                        var temp = new OrderTransaction()
                        {
                            OitemId = OrderCartDetailList[i].ItemId,
                            ItemQty = OrderCartDetailList[i].ItemQty,
                            ChemistId = cid,
                            FinalOrderId = finalorderid,
                            ObatchNo = StockMaster.BatchNo,
                            OexpiryDt=StockMaster.ExpiryDt
                            
                        };
                        if (StockMaster.StockQty >= OrderCartDetailList[i].ItemQty && StockMaster.IsActive==true)
                        {
                            StockMaster.StockQty = StockMaster.StockQty - OrderCartDetailList[i].ItemQty;
                            _context.StockMaster.Update(StockMaster);
                        }

                            
                        _context.OrderTransaction.Add(temp);
                       
                        _context.OrderCartDetails.Remove(OrderCartDetailList[i]);
                       
                        _context.SaveChanges();

                        _context.Entry(temp).State = EntityState.Detached;


                    }

                   //Adding Delivery Detials
                    
                    var tempAdd = new OrderDeliveryDetails()
                    {
                        FinalOrderId = finalorderid,
                        ChemistId = cid,
                        ShopName = HttpContext.Session.GetString("ShopName"),
                        ShopAddress = HttpContext.Session.GetString("ShopAdd"),
                        Telephone = HttpContext.Session.GetString("Telephone"),
                        EmailChemist = HttpContext.Session.GetString("Email")
                       
                     };
                    _context.OrderDeliveryDetails.Add(tempAdd);

                    var tempNotify = new NotifyChemist()
                    {
                        ChemistId = cid,
                        NotifyIsRead = Convert.ToBoolean(false),
                        UpdateTime = DateTime.Now,
                        NotifyType = "Order",
                        NotifyMsg = finalorderid + " has been received"

                    };

                    _context.NotifyChemist.Add(tempNotify);

                    _context.SaveChanges();
                }


                
                SMSEmailclass sendMail = new SMSEmailclass();

                
                string tempMail = HttpContext.Session.GetString("Email");
                string tempName = HttpContext.Session.GetString("Firstname");
                string bodyMessage = tempName + " you have successfully placed order of type " 
                                                + dtype + " on " + DateTime.Now + ". Please pay amount Rs. " + payTot;
                sendMail.SendMail(tempMail,"Order Placed on Mediflow",bodyMessage,true);
                sendMail.sendSMS(HttpContext.Session.GetString("Telephone"), bodyMessage);

                if (tempOnlinePyament == "online")
                {
                    return new JsonResult("Paytm");
                }
            }
            return new JsonResult("Success");

        }
    }
}
  