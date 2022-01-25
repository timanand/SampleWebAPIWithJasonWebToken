using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Demo
{

    // Interface added by AANA
    public interface IJwtAuthenticationManager
    {
        // It will return a string back which is the JWT token created
        string Authenticate(string username, string password);
    }


}
