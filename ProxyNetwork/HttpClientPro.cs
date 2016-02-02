using System;
using System.Net;
using System.Net.Http;

namespace ProxyNetwork
{
    public class HttpClientPro : HttpClient
    {
        public HttpClientPro() { }

        public HttpClientPro(HttpMessageHandler handler)
            : base(handler) { }

        public HttpClientPro(HttpMessageHandler handler, bool disposeHandler)
            : base(handler, disposeHandler)
        {
        }

        public HttpClientPro(ProxyIdentity identity)
            : this(CreateHandler(identity), true)
        {
            Identity = identity;
            DefaultRequestHeaders.UserAgent.Clear();
            if (!string.IsNullOrEmpty(identity.UserAgent))
            {
                DefaultRequestHeaders.UserAgent.ParseAdd(identity.UserAgent);
            }
        }

        public ProxyIdentity Identity { get; private set; }

        private static HttpMessageHandler CreateHandler(ProxyIdentity identity)
        {
            if(identity == null) throw new ArgumentNullException(nameof(identity));
            var proxy = identity.Credential != null
                ? new WebProxy(identity.Proxy, true, null, identity.Credential)
                : new WebProxy(identity.Proxy);
            proxy.UseDefaultCredentials = identity.Credential != null;
            return new HttpClientHandler
            {
                UseProxy = true,
                Proxy = proxy
            };
        }
    }
}