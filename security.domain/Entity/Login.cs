
namespace security.domain
{
    using Flunt.Notifications;


    public class Login :  Notifiable<Notification>
    {
        
        public AutenticacaoValue Autenticacao { get; set; }

        public Login(string Email, string Password, string Key)
        {
            //this.Id = rota;             
            this.Autenticacao = new AutenticacaoValue(new EmailValue(Email), Password, Key); 
            
           AddNotifications(this.Autenticacao.Notifications);
        }

    }
}
