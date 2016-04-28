using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace desafio.app
{
    public class JwtUtility
    {
       private static string secretKey = "H4e3k77WnrSDmn1Od7q5pxp6wqO7xz6H";
       
       public static string Encode(Guid userId, double expiration, double login)
       {
           var payload = new Dictionary<string, object>()
            {
                { "userId", userId },
                { "exp", expiration.ToString() },
                { "login", login.ToString() }
            };
            
            return JwtDnx.JsonWebToken.Encode(payload, secretKey, JwtDnx.JwtHashAlgorithm.HS256);
       }
       
       public static string Decode(string token)
       {
            return JwtDnx.JsonWebToken.Decode(token, secretKey);
       }
    }
}