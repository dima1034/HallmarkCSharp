using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalAuth.Services
{
    public class DummyUserService : IUserService
    {
        private IDictionary<string, (string PasswordHash, User user)> _users = 
             new Dictionary<string, (string PasswordHash, User user)>();
        
        public DummyUserService(IDictionary<string, string> users)
        {
            foreach (var usr in users)
            {
                _users.Add(usr.Key.ToLower(), (usr.Value, new User(usr.Key)));
            }
        }

        public Task<bool> ValidateCredentianls(string username, string password, out User user)
        {
            user = null;
            var key = username.ToLower();
            if (_users.ContainsKey(key))
            {
                var hash = _users[key].PasswordHash;
                if (BCrypt.Net.BCrypt.Verify(password, hash))
                {
                    user = _users[key].user;
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult((false));
        }
    }
}