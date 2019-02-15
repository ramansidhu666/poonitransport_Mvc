using PooniTransport.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PooniTransport.Web.Helper
{
    public class EmailSenderCls
    {

        public static void SendMail(ContactViewModel model)
        {
            MailMessage mail = new MailMessage();
            string ToEmailID = ConfigurationManager.AppSettings["ToEmailID"].ToString(); //From Email & To Email are same for admin
            //string ToEmailPassword = ConfigurationManager.AppSettings["ToEmailPassword"].ToString();
            string FromEmailID = ConfigurationManager.AppSettings["RegFromMailAddress"].ToString();
            string FromEmailPassword = ConfigurationManager.AppSettings["RegPassword"].ToString();
            string _Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            int _Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            Boolean _UseDefaultCredentials = false;
            Boolean _EnableSsl = true;
            mail.To.Add(ToEmailID);
            mail.From = new MailAddress(FromEmailID);
            mail.Subject = model.Subject ?? "Confirmation mail By User" ;

            string body = "";
            body = " <b>Name:</b>" + model.UserName + "<br/>";
            body = body + "<b>Email Id:</b> " + model.EMailId + "<br/>";
            body = body + "<b>Phone No:</b>" + model.PhoneNo + "<br/>";
            if (model.Location != null && model.Location != "Select Location")
            {
                body = body + "<b>Location:</b>" + model.Location+ "<br/>";
            }
            else if(model.Location == "Select Location")
            {
                body = body + "<b>Location:</b> <br/>";
            }

            body= body+"<b> Message:</b> " + model.Message+ "";
            mail.Body = body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = _Host;
            smtp.Port = _Port;
            smtp.UseDefaultCredentials = _UseDefaultCredentials;
            smtp.Credentials = new System.Net.NetworkCredential
            (FromEmailID, FromEmailPassword);// Enter senders User name and password
            smtp.EnableSsl = _EnableSsl;
            smtp.Send(mail);
        }
    }
}