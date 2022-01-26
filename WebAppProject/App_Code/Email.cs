using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    public Email()
    {
        //
        // TODO: Add constructor logic here
        //




    }
    public static void SendEmail(string Email)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.Credentials = new System.Net.NetworkCredential("OzymandiasNovaLux@gmail.com", "GamestoptotheMoon42069");
        // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();


        //New password


        //Setting From , To and CC
        mail.From = new MailAddress("OzymandiasNovaLux@gmail.com", "Zade's Action Figures");
        mail.To.Add(new MailAddress(Email));
        //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

        mail.Subject = "Password reset Email";
        mail.Body = $"Hello it appears that you have asked for a password reset.Here is your new password: ";
        mail.IsBodyHtml = true;

        smtpClient.Send(mail);
    }

    



}