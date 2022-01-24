﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption 
{
    public class SigningCredentialsHelper 
    {
        //Asp.net'in hangi anahtarı ve hangi algoritmayı kullanacağını söylememiz
        public static SigningCredentials CreateSigningCredentials(SecurityKey sequrityKey)
        {
            return new SigningCredentials(sequrityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}