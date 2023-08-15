namespace Email.Interface
{
    public interface IEmailSender
    {
        public void SendEmail(string from, string fromName, string toName, string to, string subject, string body);
        public bool EmailValidate(string email);
    }
}
