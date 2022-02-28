


namespace security.domain
{
    using Flunt.Notifications;
    using System.Runtime.Serialization;

    [DataContract]
    public class Usuario :  Notifiable<Notification>
    {
        [DataMember]
        public string? Id { get; set; }
        [DataMember]
        public EmailValue Email { get; set; }
        [DataMember]
        public string? Nome { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<string>? Roles { get; set; }

        public Usuario(string nome, string email, string password, List<string> roles)
        {
            this.Id = email;
            this.Nome = nome;
            this.Email = new EmailValue(email);
            this.Password = password;            
            this.Roles = roles ?? new List<string>();


            AddNotifications(this.Email.Notifications);
        }

        public Usuario(string email, string password)
        {
            this.Id = email;
            this.Nome = "";
            this.Email = new EmailValue(email);
            this.Password = password;
            this.Roles = new List<string>();

            AddNotifications(this.Email.Notifications);

        }

        public bool GetPasswordInvalid(string password)
        {
            return (this.Password != password);


        }

        public string GetId()
        {
            //if (String.IsNullOrEmpty(this.Id))
            //{
            //    this.Id = Guid.NewGuid().ToString();
            //}

            return this.Id;

            
        }

        public static List<Usuario> GetMoq()
        {
            var savaRole = new List<string>();
            savaRole.Add("System");
            savaRole.Add("Admin");

            var caronteRole = new List<string>();
            caronteRole.Add("Diario");

            return  new List<Usuario>
            {
                new Usuario("Savastane","savastane@gmail.com","12345",savaRole ),
                new Usuario("Caronte","caronte@gmail.com","12345",caronteRole)

            };
            
        }


    }
}
