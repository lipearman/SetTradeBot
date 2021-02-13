using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace SetTradeBot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // configure http client
            builder.Services.AddScoped(x => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient(sp => new HttpClient(new DefaultBrowserOptionsMessageHandler(new WebAssemblyHttpHandler()) // or new HttpClientHandler() in .NET 5.0
            {
                DefaultBrowserRequestMode = BrowserRequestMode.NoCors
            })
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            builder.Services.AddMatBlazor();

            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomCenter;
                config.ShowProgressBar = true;
                config.ShowStepDuration = 500;
                config.HideStepDuration = 500;
                //config.PreventDuplicates = true;
                //config.NewestOnTop = true;
                //config.ShowCloseButton = true;
                //config.MaximumOpacity = 95;
                config.VisibleStateDuration = 2000;
            });

            await builder.Build().RunAsync();
        }
    }
}
