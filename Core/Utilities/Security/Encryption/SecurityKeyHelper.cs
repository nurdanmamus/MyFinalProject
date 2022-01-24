using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption  
{
    public class SecurityKeyHelper
    {
        //parolaları asp.net'in jwt lerinin anlayacağı dile getirmemiz gerekiyor.    
        //"SecurityKey": "mysupersecretkeymysupersecretkey" i byte array(simetrik anahtar) haline getiriyor.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        } 
    }
}