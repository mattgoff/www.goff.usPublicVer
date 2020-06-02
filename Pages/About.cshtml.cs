using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;

namespace www.goff.us.Pages
{
    public class AboutModel : PageModel
    {
        private string webApp = "key here";
        public void OnGet()
        {
        }

        public IActionResult OnPost(string emailFrom, string emailSubject, string emailBody)
        {
            System.Console.WriteLine($"Email from {emailFrom}");
            System.Console.WriteLine($"Email subject {emailSubject}");
            System.Console.WriteLine($"Email body {emailBody}");
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(emailFrom, "from smtp addr here");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Display Name", "to smtp addr here");
            message.To.Add(to);

            message.Subject = emailSubject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailBody;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("smtp username for auth", webApp);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            return Page();

        }
    }
}
