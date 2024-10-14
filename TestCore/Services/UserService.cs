using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using TestCore.Dto.Request;
using TestCore.Interfaces.Authentication;

namespace TestCore.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration) {
        
            _configuration = configuration;
        
        }

        public async Task<bool> IsValidUser(UserCredential userCredential)
        {
            var isValidUser = false;
            try
            {
                if(_configuration[$"LocalUsers:{userCredential.User}"] != null) isValidUser = _configuration[$"LocalUsers:{userCredential.User}"].Any() && _configuration[$"LocalUsers:{userCredential.User}"].Equals(userCredential.PassWord);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                //throw;
            }

                return isValidUser;

        }
    }
}
