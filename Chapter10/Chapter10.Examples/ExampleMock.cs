using System;

namespace Chapter10.Examples
{
public class EmailMessage
{
    public string To { get; set; }
    public string Body { get; set; }
}

public interface IMailSender
{
    void SendMessage(EmailMessage message);
}

public class MarketingService
{
    private readonly IMailSender _sender;

    public MarketingService(IMailSender sender)
    {
        _sender = sender;
    }

    public void SendMailShot(string to, string body)
    {
        _sender.SendMessage(new EmailMessage{To=to, Body = body});
    }
}

}
