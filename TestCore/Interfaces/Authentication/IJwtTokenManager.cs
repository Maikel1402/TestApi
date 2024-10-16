﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCore.Interfaces.Authentication
{
    public interface IJwtTokenManager
    {
        Task<string> Authenticate(string userName, string password);
    }
}
