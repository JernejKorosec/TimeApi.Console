using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApi.Console.Client.Enum
{
    public class Endpoints
    {
        private Endpoints(string value) { GetPath = value; }
        public string GetPath { get; private set; }
        public static Endpoints GetSession { get { return new Endpoints(@"/Session/GetSession"); } }
        public static Endpoints ApiHttpBasicUrl { get { return new Endpoints(@"http://rdweb.spica.com:5213/timeapi"); } }
        public static Endpoints Employee { get { return new Endpoints(@"/Employee"); } }
        public static Endpoints Presence { get { return new Endpoints(@"/Presence"); } }
        
    }
}
