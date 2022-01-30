using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApi.Console.Client
{
    public class RequestCredential
    {
        public DateTime? TokenTimeStamp { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = "demo";
        public string Password { get; set; } = "demo";
    }
}
