



namespace security.domain
{
    using Flunt.Validations;

    internal class EmailValidationContract : Contract<EmailValue>
    {
        public EmailValidationContract(EmailValue email)
        {
            Requires()
                 .IsEmailOrEmpty(email.Endereco, "Email", "Email Inválido");
                          
        }
    }

    
    
}
