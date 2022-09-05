namespace StoreManagement.Data.Generics.AppSettings
{
    public class EmailConfig
    {
        public bool Dummy { get; set; }
        public bool SendMail { get; set; }
        public string FakeRecieverName { get; set; }
        public string FakeRecieverMail { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}