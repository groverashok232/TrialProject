using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TrialProject.Utilities
{
    public class SendEmailNotification
    {
        static string SendersAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
        static string SendersPassword = ConfigurationManager.AppSettings["Password"].ToString();
        static string ReceiversAddress = ConfigurationManager.AppSettings["ToAddress"].ToString();
        const string subject = "Failure Scenarios";


        public static void SendEmail(string errorMessage)
        {
            SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                    Timeout = 30000
                };

            MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject,
                "Dear User,"
        + "\n\n Page impacted : Home Page"
        + "\n\n Error message : " + errorMessage
        + "\n\n Type Issue : Not able to reach to home page"
        + "\n\n Level of Severity : Blocker");

            smtp.Send(message);
        }
    }
}
