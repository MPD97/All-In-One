using System.Threading.Tasks;

namespace AOI_Services.Services
{
    public interface ICacheService
    {
        public Task<string> GetCacheValueAsync(string key);
        public Task SetCacheValueAsync(string key, string value);
    }
}