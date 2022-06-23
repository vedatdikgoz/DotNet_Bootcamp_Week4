using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {

            serviceCollection.AddMemoryCache();                      
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();  //InMemory kullanmak için
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();  //Redis kullanmak için
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
