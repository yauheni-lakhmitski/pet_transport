using MailKit.Net.Smtp;
using MimeKit;

namespace PetTransport.Infrastructure.Email;

public class EmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();
 
        emailMessage.From.Add(new MailboxAddress("Pet Transfer", "pet.transfer.no.reply@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 465, true);
        await client.AuthenticateAsync("pet.transfer.no.reply@gmail.com", "03f245fd-61a5-4964-93a9-52894bf7773b");
        await client.SendAsync(emailMessage);
        
        await client.DisconnectAsync(true);
    }
}