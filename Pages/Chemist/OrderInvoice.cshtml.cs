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
using OtpNet;
namespace Mediflow.Pages.Chemist
{
    public class OrderInvoiceModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;
        
        

        public OrderInvoiceModel(Mediflow.DBModels.MediflowContext context)
        {

            _context = context;

        }
        [BindProperty]
        public RateOrder RateOrder { get; set; }
       public Products Products { get; set; }
        public List<NotifyChemist> NotifyChemist { get; private set; }
        [BindProperty]

        public CRegister CRegister { get; set; }
        [BindProperty]
        public OrderMaster OrderMaster { get; set; }
        [BindProperty]
        public List<OrderTransaction> OrderTransactionList { get; set; }
        public OrderTransaction OrderTransaction { get; set; }
        [BindProperty]
        public OrderDeliveryDetails OrderDeliveryDetails { get; set; }
        [BindProperty]
        public OrderCartDetails OrderCartDetails { get; set; }
        [BindProperty]
        public List<OrderItemsDetails> OrderItemsDetails { get; set; }

        public ReturnItem ReturnItem { get; set; }
        public ReturnMaster NewReturnMaster { get; set; }
        public ReturnMaster ReturnMaster { get; set; }
        //public List<StockMaster> StockMasterList { get; set; }

        public IActionResult OnGet(string FinalOidClick)
        {
            ViewData["Msg"] = "Profile";
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int tempOid = Convert.ToInt32(FinalOidClick);
            var a = this.HttpContext.Session.GetString("username");
            //int countQty = _context.OrderCartDetails.Where(i => i.ChemistId == cid).ToList().Count();
           
            if (a == null)
            {
                TempData["TempUser"] = a;
                return RedirectToPage("/Home/LoginChemist");
            }
            else
            {
                NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
                CRegister = _context.CRegister.Where(i => i.Id == cid).FirstOrDefault();
                OrderMaster = _context.OrderMaster.Where(i => i.FinalOrderId == tempOid).FirstOrDefault();
                //StockMasterList=_context
                OrderDeliveryDetails = _context.OrderDeliveryDetails.Where(i => i.FinalOrderId == tempOid).FirstOrDefault();
                OrderItemsDetails = _context.OrderItemsDetails.FromSqlRaw("ChemistOrderInvoice @CID", new SqlParameter("@CID", FinalOidClick)).ToList();
                foreach(var item in OrderItemsDetails)
                {
                    if (item.OExpiry_Dt.Value.AddMonths(-3) <= DateTime.Now)
                    {
                        //4-4-2021<=1-4-2021
                        ViewData["Return"] = "Return Eligible";
                    }
                    else
                    {
                        ViewData["Return"] = "Not Eligible";
                    }
                }
                if(OrderMaster.OrderDate.Value.AddDays(7) >= DateTime.Now)
                {
                    ViewData["ReturnInstant"] = "Instant Return Eligible";
                }
                else if(OrderMaster.OrderDate.Value.AddDays(7) <= DateTime.Now)
                {
                    ViewData["ReturnInstant"] = "Instant Return Not Eligible";
                }

             
            }
            return Page();
        }

        public IActionResult OnGetTwoFactor(string otp)
        {
            if (otp != null)
            {

                SMSEmailclass sendMail = new SMSEmailclass();
                Random rnd = new Random();
                var secretKey = rnd.Next(100000, 999999);

                HttpContext.Session.SetInt32("checkOtp", secretKey);

                String msg = "Your OTP to change Order is" + secretKey;
            sendMail.sendSMS("8141391446", msg);   // edit below !=
            }
            
            return new JsonResult("Success");
            
        }

     
        public IActionResult OnGetReturn(int [] tempIdArray,int [] tempValArray, bool isExpiryReturn)
        {

            int[] IdArray = tempIdArray;
            int[] ValueArray = tempValArray;
            //OrderTransactionList = _context.OrderTransaction.ToList();
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            float valueTotal=0;
            float payableTotal = 0;
           

            for (int k = 0; k < IdArray.Length; k++)
            {
                float tempTotal = 0;
                
                OrderTransaction = _context.OrderTransaction.Where(i => i.OrderDetailId == tempIdArray[k]).FirstOrDefault();
                OrderMaster = _context.OrderMaster.Where(i => i.FinalOrderId == OrderTransaction.FinalOrderId).FirstOrDefault();
                Products = _context.Products.Where(i => i.ItemId == OrderTransaction.OitemId).FirstOrDefault();
                NewReturnMaster = _context.ReturnMaster.Where(i => i.RmFinalOrderId== OrderTransaction.FinalOrderId).FirstOrDefault();

                if (k == 0)
                {
                    if (NewReturnMaster != null)
                    {
                        if (NewReturnMaster.RmIsNewRecord == true)
                        {
                            ReturnMaster = _context.ReturnMaster.Where(i => i.RmFinalOrderId == OrderTransaction.FinalOrderId && i.RmIsNewRecord == true).FirstOrDefault();

                        }
                    }
                    else
                    {
                        ReturnMaster = _context.ReturnMaster.Where(i => i.RmFinalOrderId == OrderTransaction.FinalOrderId).FirstOrDefault();
                    }
                }

                else if (k != 0 && (NewReturnMaster.RmIsNewRecord == null || NewReturnMaster.RmIsNewRecord == false))
                {

                    ReturnMaster = _context.ReturnMaster.Where(i => i.RmFinalOrderId == OrderTransaction.FinalOrderId).FirstOrDefault();
                }
                else
                {
                }
               
                int tempRMid=0;
                bool tempExp = false;
                float qtyrate = (float)Products.Rate * ValueArray[k] ;
                float hsnRate = qtyrate;
                if (isExpiryReturn == true)
                {
                    tempExp = true;
                }
                else
                {
                    tempExp = false;
                }

                if (Products.HsnCode==3304)
                {
                    hsnRate = (float)(hsnRate * Products.GstPercent);
                }else if(Products.HsnCode==3004)
                {
                    hsnRate =(float)(hsnRate * Products.GstPercent);
                }
                 tempTotal = (float) (qtyrate);
                tempTotal = (float) (tempTotal* 0.02);

                payableTotal = payableTotal + qtyrate+hsnRate-tempTotal;
                
                valueTotal = valueTotal+qtyrate;
                
                if (ReturnMaster == null)
                {
                    var tempReturnMaster = new ReturnMaster()
                    {
                        RmFinalOrderId = OrderTransaction.FinalOrderId,
                        RmDate = DateTime.Now,
                        RmValuePrice = System.Math.Round(valueTotal,2),
                        RmFinalPayable = System.Math.Round(payableTotal,2),
                        RmIstypeExpiry=tempExp,
                        RmIsNewRecord=false,
                        RmCid=cid

                    };

                    _context.ReturnMaster.Add(tempReturnMaster);
                    _context.SaveChanges(); //save new return master record 
                    tempRMid = (int)tempReturnMaster.RmasterId;
                }
                else if (ReturnMaster != null)
                {

                    ReturnMaster.RmValuePrice = System.Math.Round(valueTotal, 2);
                    ReturnMaster.RmFinalPayable = System.Math.Round(payableTotal, 2);
                    if (k == IdArray.Length - 1)
                    {
                        ReturnMaster.RmIsNewRecord = true;
                    }
                    else
                    {
                        ReturnMaster.RmIsNewRecord = false;
                    }
                        tempRMid = (int)ReturnMaster.RmasterId;
                    _context.Attach(ReturnMaster).State = EntityState.Modified;//or update same record 
                    _context.SaveChanges();

                }
               
                //Mane ReturnItems record whihc contains details of items.
               

                var tempReturn = new ReturnItem()
                {

                    RmId=tempRMid,
                    RchemistId=cid,
                    RfinalOrderId=OrderTransaction.FinalOrderId,
                    RitemId= OrderTransaction.OitemId,
                    RitemQty= ValueArray[k],
                    RitemExpiry= OrderTransaction.OexpiryDt,
                    RbatchNo= OrderTransaction.ObatchNo,
                    RinitiateDate=DateTime.Now,
                    RpaymentType="Cash",                   
                    RIstypeExpiry = tempExp,
                       

                };


                _context.ReturnItem.Add(tempReturn);
                _context.SaveChanges();

                OrderTransaction.OitemReturnStatus = true;
                _context.OrderTransaction.Update(OrderTransaction);

                var tempNotify = new NotifyChemist()
                {
                    ChemistId = cid,
                    NotifyMsg = "Item " + Products.ItemName + " return initiated",
                    UpdateTime = DateTime.Now,
                    NotifyType = "Return",
                    NotifyIsRead= false
                };
                _context.NotifyChemist.Add(tempNotify);

                _context.SaveChanges();
                //OrderTransaction[i]
                

                
            }

          
            return new JsonResult("Success");
        }

     
        public IActionResult OnPostCheckTwoFactor(string n1,string n2, string n3, string n4, string n5, string n6,int ForderId)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            int checkOtp = (int)this.HttpContext.Session.GetInt32("checkOtp");
            int verfiyOtp = Convert.ToInt32(n1 + n2 + n3 + n4 + n5 + n6);

            if (checkOtp == verfiyOtp) // (checkOtp != 0) //
            {
                OrderMaster = _context.OrderMaster.Where(i => i.FinalOrderId == ForderId).FirstOrDefault();
                OrderMaster.OrderStatus = "Cancelled";
               // _context.Attach(OrderMaster).State = EntityState.Modified;
                _context.OrderMaster.Update(OrderMaster);
                
               // _context.SaveChanges();
                OrderTransactionList = _context.OrderTransaction.Where(i=>i.FinalOrderId==ForderId).ToList();
                OrderDeliveryDetails = _context.OrderDeliveryDetails.Where(i => i.FinalOrderId == ForderId).FirstOrDefault();
                _context.OrderDeliveryDetails.Remove(OrderDeliveryDetails);
                for (int i = 0; i < OrderTransactionList.Count(); i++)
                {
                    var temp = new OrderCartDetails()
                    {
                        ChemistId = cid,
                        ItemId = OrderTransactionList[i].OitemId,
                        ItemQty = OrderTransactionList[i].ItemQty

                    };

                    _context.OrderCartDetails.Add(temp);
                    _context.OrderTransaction.Remove(OrderTransactionList[i]);


                    _context.SaveChanges();


                }
               
            }

            return RedirectToPage("/Chemist/Cart");
        }
        


        public IActionResult OnPostRateOrder(string feedback,string msg, int fid)
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            var tempRate = new RateOrder() { 
            
                RForderId=fid,
                RCid=cid,
                RType=feedback,
                RMsg=msg
            
            };

            _context.RateOrder.Add(tempRate);
            _context.SaveChanges();
            return RedirectToPage("/Chemist/OrderInvoice",new { FinalOidClick = fid });
        }
    }
}
