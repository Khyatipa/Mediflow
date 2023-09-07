using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mediflow.Pages.Chemist
{
    public class SmsMailModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string mobile, string sms)
        {
            SMSEmailclass s = new SMSEmailclass();
            //s.sendSMS(mobile,sms);

            s.SendMail("rutvikrocks189@gmail.com", "Hello", "Test Message", true);
            //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential("mediflow.dishaenterprise@gmail.com", "michael**00"),
        //        EnableSsl = true,
        //        UseDefaultCredentials = false
        //};

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("mediflow.dishaenterprise@gmail.com"),
        //        Subject = "Test Project",
        //        Body = "<h1> Hello Test USer</h1>",
        //        IsBodyHtml = true,
        //    };
        //    mailMessage.To.Add("rutvikrocks189@gmail.com");

        //    smtpClient.Send(mailMessage);



            return Page();
        }
    }
}
