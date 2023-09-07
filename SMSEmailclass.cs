using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Mediflow
{
    public class SMSEmailclass
    {
     
        public void sendSMS(string mobile, string message )
        {
            string YOUR_API_KEY = "gDnATNwu4f6aJBj29Il53XOZVeMbCUYQ8FzLtPqpSimhR0r7EsGiVPesdapjgv53HTc1oZyBuAQXDh9R";
           // var client = new RestClient("https://www.fast2sms.com/dev/bulkV2?authorization=" + YOUR_API_KEY + "&message=" + message + "&language=english&sender_id = TXTIND&route=q&numbers="+ mobile + "");
            var client = new RestClient("https://www.fast2sms.com/dev/bulkV2?authorization=" + YOUR_API_KEY + "&message=" + message + "&language=english&sender_id = TXTIND&route=q&numbers=" + mobile);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

        }
        public bool SendMail(string toAddress, string subject, string body, bool useSSL)
        {

            MailMessage mm = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            MailAddress emailFrom = new MailAddress("mediflow.dishaenterprise@gmail.com", "Mediflow");
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

            try
            {
                NetworkCred.UserName = "mediflow.dishaenterprise@gmail.com";
                NetworkCred.Password = "michael**00";
                mm.To.Add(new MailAddress(toAddress));
                mm.From = emailFrom;
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate,
                 X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = useSSL;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }



    }
}
