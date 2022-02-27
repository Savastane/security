

namespace security.test
{
    using security.domain;

    using Xunit;    
    using System.Collections.Generic;
    using Moq;


    public class EmailValueTest
    {



        [Fact]
        public void IsEmail()
        {
        
            var list = new List<EmailValue>();

            list.Add(new EmailValue("some string"));
            list.Add(new EmailValue("invalid"));
            list.Add(new EmailValue("some string"));
            list.Add(new EmailValue("someinvalid.com"));

            list.Add(new EmailValue("some@gmail.com"));
            list.Add(new EmailValue("some@hotmail.com"));
            list.Add(new EmailValue("some@customdomain.com"));
            list.Add(new EmailValue("some@mydomain.com.br"));

            int totalNotificacoes = 0;
            foreach (var item in list)
            {
                totalNotificacoes = totalNotificacoes + item.Notifications.Count;                
            }


            Assert.Equal(4, totalNotificacoes);
            
        }


    }
    
}