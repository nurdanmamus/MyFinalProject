using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT 
{
    //kullanıcı girişi işleminde verilen token ve süresi(setting'de 10 yapmıştık)
    public class AccessToken 
    {
        public string Token { get; set; } 
        public DateTime Expiration { get; set; }
    }
}
