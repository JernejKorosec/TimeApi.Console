using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApi.Console.Client.DTO
{
    public class LoginHeader
    {
        public String? HeaderKey { get; set; }
        public String? HeaderValue { get; set; }
    }

    /*
     var payloadHeader = new LoginHeader
            {
                //HeaderKey = "Authorization",
                HeaderKey = TokenAuthentication.Scheme,
                //HeaderValue = "SpicaToken 87F262C4-7FA6-46D3-880D-2F7E15B4F204"
                HeaderValue = Api.headerValuePrefix + " " + Api.key
            };
    */
}
