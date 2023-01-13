namespace ProjetDotNet.Data
{
    public class UserRepository
    {
        public static object? FindByCreds(string? username, string? password)
        {
            if (username == null) return null;
            if (password == null) return null;



            return new object();
        }
    }
}
