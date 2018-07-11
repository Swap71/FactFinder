using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FactFinder
{
    class Email
    {
        private string toemail;
        private string body;
        private string subject;
        private MailMessage mail;

        [Test]
        public void email_send()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    SmtpClient SmtpServer = new SmtpClient("STELLAR12");
            //   mail.From = new MailAddress("your mail@gmail.com");
            mail.From = new MailAddress("swapnil.landge@stellarconsultants.co.in");
            //  mail.To.Add("to_mail@gmail.com");
            mail.To.Add("swapnil.landge@stellarconsultants.co.in");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";
            Console.WriteLine("T1");
            System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            attachment = new System.Net.Mail.Attachment("c:/bdlog.txt");
           // attachment = new System.Net.Mail.Attachment("C://Users//Stellar//source//repo//FactFinder//FactFinder//Reports//testreport.html");
            mail.Attachments.Add(attachment);
            Console.WriteLine("T2");
         //   SmtpServer.Port = 587;
            //   SmtpServer.Port = 465;
            SmtpServer.Port = 993;
            Console.WriteLine("465");
            // SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password");
            SmtpServer.Credentials = new System.Net.NetworkCredential("swapnil.landge@stellarconsultants.co.in", "Password_007");
            SmtpServer.EnableSsl = true;
            Console.WriteLine("Credentials");
            SmtpServer.Send(mail);
          //  SmtpServer.Send(SmtpServer);
            //  SmtpServer.Send(swapnil.landge@stellarconsultants.co.in);

            /****    using (MailMessage mailMessage = new MailMessage(new MailAddress(toemail),new MailAddress(toemail)))
                {
                    mailMessage.Body = body;
                    mailMessage.Subject = subject;
                    try
                    {
                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Credentials =
                                 //new System.Net.NetworkCredential(email, password);
                                 new System.Net.NetworkCredential("swapnil.landge@stellarconsultants.co.in", "Password_007");
                        SmtpServer.Port = 587;
                        SmtpServer.Host = "smtp.gmail.com";
                        SmtpServer.EnableSsl = true;
                        mail = new MailMessage();
                        String[] addr = toemail.Split(','); // toemail is a string which contains many email address separated by comma
                        mail.From = new MailAddress("swapnil.landge@stellarconsultants.co.in");
                        Byte i;
                        for (i = 0; i < addr.Length; i++)
                            mail.To.Add(addr[i]);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        mail.DeliveryNotificationOptions =
                            DeliveryNotificationOptions.OnFailure;
                        //   mail.ReplyTo = new MailAddress(toemail);
                        mail.ReplyToList.Add(toemail);
                        SmtpServer.Send(mail);
                        // return "Mail Sent";
                        Console.WriteLine("Mail Sent");
                    }
                    catch (Exception ex)
                    {
                        string exp = ex.ToString();
                        //return "Mail Not Sent ... and ther error is " + exp;
                        Console.WriteLine("Mail Not Sent ... and ther error is ");
                    }
                }*****/
        }

    }
}
