


namespace security.domain
{
    using Flunt.Notifications;

    public class AutenticacaoValue : Notifiable<Notification>
    {
        public EmailValue  Email { get; private set; }
        public string Password { get; private set; }
        public string Key { get; private set; }

        public AutenticacaoValue(EmailValue Email, string Password, string Key)
        {
            this.Key = Key;
            this.Email = Email;
            this.Password = Password;

            AddNotifications(new EmailValidationContract(Email));
        }


    }
}
