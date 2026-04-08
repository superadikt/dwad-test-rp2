namespace DwadTestRp.Services;

public class SmtpEmailSender(IConfiguration configuration) : IEmailSender
{
    public Task SendAsync(string to, string subject, string body)
    {
        // For demo purposes we won't implement an actual SMTP client.
        // In production, inject an SMTP client or third-party provider SDK.
        Console.WriteLine($"[Email] To={to} Subject={subject} Body={body}");
        return Task.CompletedTask;
    }
}
