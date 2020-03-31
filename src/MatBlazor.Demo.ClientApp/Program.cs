﻿using MatBlazor.Demo.Models;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MatBlazor.Demo.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MatBlazor.Demo.ClientApp
{
#if !PREVIEW
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
#else
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            new Startup().ConfigureServices(builder.Services);

            await builder
                .Build()
                .UseLocalTimeZone()
                .RunAsync();
        }
    }
#endif
}