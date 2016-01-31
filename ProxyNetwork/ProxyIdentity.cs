using System;
using System.Net;

namespace ProxyNetwork
{
    public class ProxyIdentity
    {
        public Uri Proxy { get; set; }
        public NetworkCredential Credential { get; set; }
        public string UserAgent { get; set; }
    }
}