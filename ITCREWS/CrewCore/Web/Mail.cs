using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CrewCore.Web
{
    public class Mail
    {
       private MimeMessage message = new MimeMessage();

        public  Mail(string sendMail, string toMail)
        {
            this.message.From.Add(MailboxAddress.Parse(sendMail));
            this.message.To.Add( MailboxAddress.Parse(toMail));
        }
     

        public  async Task SendEmail( string subject, string body)
        {
    
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = $@"<a href='{body}' target ='_blenk'>클릭</a>" };
            //message.Body = new TextPart("plain") { Text=body };
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("itcrewinfo@gmail.com", "qwer1234!@#$");
                    client.CheckCertificateRevocation = false;
                    //client.Connect("smtp.naver.com", 25, SecureSocketOptions.None);
                    client.Send(message);
                    client.Disconnect(true);
                    client.Dispose();
                }
                catch (Exception e)
                {
                    
                }
            }

        }
    }
}
