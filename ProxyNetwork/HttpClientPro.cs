using System;
using System.Net;
using System.Net.Http;

namespace ProxyNetwork
{
    public class HttpClientPro : IDisposable
    {
        public static HttpClientPro Create(IProxyProvider proxyProvider)
        {
            var proxy = proxyProvider.Next();
            if (proxy == null)
            {
                proxyProvider.Refresh().Wait();
                proxy = proxyProvider.Next();
                if (proxy == null)
                {
                    throw new Exception("The proxy provider had not found available proxy.");
                }
            }
            return new HttpClientPro(proxy);
        }

        public HttpClientPro(Uri proxy = null)
        {
            if (proxy != null)
            {
                Proxy = proxy;
                var handler = new HttpClientHandler
                {
                    UseProxy = true,
                    Proxy = new WebProxy(proxy) { UseDefaultCredentials = false }
                };
                Client = new HttpClient(handler);
            }
            else
            {
                Client = new HttpClient();

            }
        }

        public HttpClient Client { get; }

        public Uri Proxy { get; }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}