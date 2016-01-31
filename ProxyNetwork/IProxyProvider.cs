using System.Threading.Tasks;

namespace ProxyNetwork
{
    public interface IProxyProvider
    {
        Task<int> RefreshAsync();
        ProxyIdentity Next();
        ProxyIdentity[] GetIdentities();
        void Remove(ProxyIdentity identity);
        void ToBlackList(string host);
    }
}