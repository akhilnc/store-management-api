using System.Collections.Generic;

namespace StoreManagement.Data.Generics.General.Mail
{
    public class MailSettings
    {
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string RecieverName { get; set; }
        public string RecieverMail { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}