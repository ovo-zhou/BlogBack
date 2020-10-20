using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Service
{
    public interface IAuthenticateService
    {
        string GetToken(string username);
    }
}
