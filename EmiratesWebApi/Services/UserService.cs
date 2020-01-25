using nCoreCMSBL.Models;
using nCoreCMSBL.Repository;

namespace EmiratesWebApi.Services
{
    public class UserService
    {
        public Users ValidateUser(string userName, string password)
        {
            var user = UserRepository.ValidateUser(userName, password);
            return user;
        }
    }
}