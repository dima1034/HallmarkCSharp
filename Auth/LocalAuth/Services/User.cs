using System.Threading.Tasks;

namespace LocalAuth.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentianls(string username, string password, out User user);
    }

    public class User
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}