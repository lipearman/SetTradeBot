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

namespace SetTradeBot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

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
