using System;
using ECommerce.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ECommerce.UnitTest.RepositoryTests
{
    [TestFixture]
    public class CreatorTests
    {
        public CreatorTests()
        {
            //var webHost = WebHost.CreateDefaultBuilder()
            //    .UseStartup<Startup>()
            //    .Build();
            //_serviceProvider = new DependencyResolverHelpercs(webHost);
        }

        public class DependencyResolverHelpercs
        {
            private readonly IWebHost _webHost;

            /// <inheritdoc />
            public DependencyResolverHelpercs(IWebHost WebHost) => _webHost = WebHost;

            public T GetService<T>()
            {
                using (var serviceScope = _webHost.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        var scopedService = services.GetRequiredService<T>();
                        return scopedService;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                };
            }
        }

    }
}
