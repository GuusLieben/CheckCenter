using System.Collections.Generic;
using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        User GetUser(string email);

        bool ValidateLogin(User user);
        IEnumerable<User> GetUsers();
        string CreateToken(User user);
    }
}
