using ProjetDotNet.Models;

namespace ProjetDotNet.Helper
{
    public class ValidationHelper
    {
        public static bool IsUserInfoValid(User? user)
        {
            if(user == null) return false;
            if(!IsValidEmail(user.Email)) return false;

            return true;
        }

        public static bool IsValidEmail(string? email)
        {
            if(email == null) return false;
            if (!email.Contains("@")) return false;

            return true;
        }
    }
}
