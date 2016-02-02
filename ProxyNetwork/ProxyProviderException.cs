using System;

namespace ProxyNetwork
{
    public class ProxyProviderException : Exception
    {
        public ProxyProviderException() { }
        public ProxyProviderException(string message) : base(message) { }
        public ProxyProviderException(string message, Exception innerException) : base(message, innerException) { }
    }
}