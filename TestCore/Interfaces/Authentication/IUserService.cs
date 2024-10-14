using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCore.Dto.Request;

namespace TestCore.Interfaces.Authentication
{
    public interface IUserService
    {
        Task<bool> IsValidUser(UserCredential userCredential);
    }
}
