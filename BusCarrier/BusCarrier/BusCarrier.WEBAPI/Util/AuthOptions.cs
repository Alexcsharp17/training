using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BusCarrier.WEBAPI.Util
{
    public class AuthOptions
    {
        public const string ISSUER = "WebApiServer"; 
        public const string AUDIENCE = "WebApiClient"; 
        const string KEY = "buscarrier_secretkey!123";  
        public const int LIFETIME = 60; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
