using System;
using System.Threading.Tasks;

namespace ProxyNetwork
{
    public interface IProxyProvider
    {
        Task<int> Refresh();
        Uri Next();
        void Remove(Uri proxy, bool toBlackList);
    }
}