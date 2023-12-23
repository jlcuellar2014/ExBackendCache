using CacheInMemory.Cache;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace CacheInMemory.Tests.Utils
{
    public class FakeWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddTransient<IDataContext, FakeDataContext>();
            });
        }
    }
}
