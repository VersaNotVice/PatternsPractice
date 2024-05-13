public interface IMailConstructor
{
    public IMailConstructor AddRecipient(string recipient);
    public IMailConstructor AddSubject(string subject);
    public IMailConstructor AddContent(string content);
    public IMailConstructor AddAttachments(string attachments);
    public IMailConstructor Reset();
    public Mail Construct();
}
public class Mail
{
    //builder
    public string Subject { get; set; }
    public string Content { get; set; }
    public string Recipient { get; set; }
    public string Attachments { get; set; }
}

public class MailConstructor : IMailConstructor
{
    Mail mail;
    public MailConstructor()
    {
        mail = new Mail();
    }
    public IMailConstructor AddSubject(string subject)
    {
        mail.Subject = subject;
        return this;
    }
    public IMailConstructor AddRecipient(string recipient)
    {
        mail.Recipient = recipient;
        return this;
    }
    public IMailConstructor AddContent(string content) 
    {
        mail.Content = content;
        return this;
    }

    public IMailConstructor AddAttachments(string attachment)
    {
        mail.Attachments = attachment;
        return this;
    }
    public IMailConstructor Reset()
    {
        mail = new Mail();
        return this;
    }

    public Mail Construct()
    {
        return mail;
    }
}

public class SMTP
{
    IMailConstructor mailConstructor;
    public SMTP(IMailConstructor mailConstructor)
    {
        this.mailConstructor = mailConstructor;
    }

    public void SendNoReplyMail()
    {
        mailConstructor.AddSubject("No Reply").AddContent("Hello World").Construct();
        //Sending logic here
    }
}
public static class ClientCode
{
    public static void Run()
    {
        SMTP smtp = new SMTP(new MailConstructor());
        smtp.SendNoReplyMail();
    }
}
