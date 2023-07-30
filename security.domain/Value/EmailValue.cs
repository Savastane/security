


namespace security.domain
{

    using Flunt.Notifications;
    using System.Runtime.Serialization;

    [DataContract]
    public class EmailValue: Notifiable<Notification>
    {
        [DataMember]
        public string  Endereco { get; private set; }

        public  EmailValue(string endereco)
        {
            this.Endereco = endereco;
            AddNotifications(new EmailValidationContract(this).Notifications);
        }


    }
}
