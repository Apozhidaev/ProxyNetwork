using System.Threading.Tasks;

namespace ProxyNetwork
{
    public interface IProxyProvider
    {
        Task<int> RefreshAsync();
        Task<ProxyIdentity> NextAsync();
        ProxyIdentity[] GetIdentities();
        void Remove(ProxyIdentity identity);
        void ToBlackList(string host);
    }
}