using MailKit.Net.Smtp;
using MimeKit;

class Program
{
    static void Main()
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Sugam Neupne", Environment.GetEnvironmentVariable("EMAIL_FROM")));
        email.To.Add(new MailboxAddress("Prasamsha Upreti", Environment.GetEnvironmentVariable("EMAIL_TO")));
        email.Subject = "Automated Email";

        email.Body = new TextPart("plain")
        {
            Text = "I love you, Prasamsha Upreti <3 -Sugam"
        };

        using (var client = new SmtpClient())
        {
            client.Connect(
                Environment.GetEnvironmentVariable("SMTP_HOST"),
                int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")),
                true
            );

            client.Authenticate(
                Environment.GetEnvironmentVariable("SMTP_USER"),
                Environment.GetEnvironmentVariable("SMTP_PASS")
            );

            client.Send(email);
            client.Disconnect(true);
        }
    }
}
