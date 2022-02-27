using System.Text;

namespace security.jwt.settings
{
    public class Settings
    {
        
        public static string Issuer = "diario";
        public static string Audiencia = "organize.one";
        public static string Key = "93021a930129302930219329130920392198A32910839028390@21830912";

        public static byte[] getKey()
        {
            return Encoding.ASCII.GetBytes(Settings.Key);
        }
    }
}
