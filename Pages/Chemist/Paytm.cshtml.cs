using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AstroBasic.PayTM;
using Microsoft.AspNetCore.Http;
using Mediflow.DBModels;

namespace Mediflow.Pages.Chemist
{
    public class PaytmModel : PageModel
    {
        private readonly Mediflow.DBModels.MediflowContext _context;

        public PaytmModel(Mediflow.DBModels.MediflowContext context)
        {
            _context = context;
        }

        public List<NotifyChemist> NotifyChemist { get; set; }
        public void OnGet()
        {
            int cid = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            NotifyChemist = _context.NotifyChemist.Where(i => i.ChemistId == cid).ToList();
            string msg = this.HttpContext.Session.GetString("PayStatus");
            if(msg!=null)
            {
                string msgBody = this.HttpContext.Session.GetString("PaytmString");
                ViewData["Msg"] = "AfterMath";
            }
            ViewData["Msg"] = "Homepage";
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";
        //    return View();
        //}
        public IActionResult OnPostTransaction()
        {
            string orderid = "D" + DateTime.Now.Ticks.ToString();
            Dictionary<String, String> paytmParams = new Dictionary<String, String>();
            /* Find your MID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
            paytmParams.Add("MID", "uoHGXH66527702417335");
            /* Find your WEBSITE in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
            paytmParams.Add("WEBSITE", "WEBSTAGING");
            /* Find your INDUSTRY_TYPE_ID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
            paytmParams.Add("INDUSTRY_TYPE_ID", "Retail");
            /* WEB for website and WAP for Mobile-websites or App */
            paytmParams.Add("CHANNEL_ID", "WEB");
            /* Enter your unique order id */
            paytmParams.Add("ORDER_ID", orderid);
            /* unique id that belongs to your customer */
            paytmParams.Add("CUST_ID", "2");
            /* customer's mobile number */
            paytmParams.Add("MOBILE_NO", "8141391446");
            /* customer's email */
            paytmParams.Add("EMAIL", "rutvikrocks189@gmail.com");
            /**
            * Amount in INR that is payble by customer
            * this should be numeric with optionally having two decimal points
*/
            paytmParams.Add("TXN_AMOUNT", "50");
            /* on completion of transaction, we will send you the response on this URL */
            paytmParams.Add("CALLBACK_URL", "http://localhost:51599/Chemist/Paytm");
            /**
            * Generate checksum for parameters we have
            * You can get Checksum DLL from https://developer.paytm.com/docs/checksum/
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
*/
            //  String checksum = AstroBasic.PayTM.CheckSum.generateCheckSum("WVxD5fwuD8SqTyUH", paytmParams);
            String checksum = AstroBasic.PayTM.Library.CheckSum.generateCheckSum("WVxD5fwuD8SqTyUH", paytmParams);
            /* for Staging */
            String url = "https://securegw-stage.paytm.in/order/process";
            /* for Production */
            // String url = "https://securegw.paytm.in/order/process";

            /* Prepare HTML Form and Submit to Paytm */
            String outputHtml = "";
            outputHtml += "<html>";
            outputHtml += "<head>";
            outputHtml += "<title>Merchant Checkout Page</title>";
            outputHtml += "</head>";
            outputHtml += "<body>";
            outputHtml += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHtml += "<form method='post' action='" + url + "' name='paytm_form'>";

            foreach (string key in paytmParams.Keys)
            {
                outputHtml += "<input type='hidden' name='" + key + "' value='" + paytmParams[key] + "'>";
            }
            outputHtml += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHtml += "</form>";
            outputHtml += "<script type='text/javascript'>";
            outputHtml += "document.paytm_form.submit();";
            outputHtml += "</script>";
            outputHtml += "</body>";
            outputHtml += "</html>";
            HttpContext.Session.SetString("PaytmString",outputHtml.ToString());
            HttpContext.Session.SetString("PayStatus","Paid");
            //  Response.Write(outputHtml.ToString());//session ma muko ....view data fetch... htmlraw //outputhtml.string.....blank page per ddata levenu ,,,n batavanyu htmlraw
            return Page();
        }
    }
}
