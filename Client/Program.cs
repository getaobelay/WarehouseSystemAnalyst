using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.BlazorUI.Client.ClientService;

namespace WarehouseSystemAnalyst.BlazorUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Add your Syncfusion license key for Blazor platform with corresponding Syncfusion NuGet version referred in project. For more information about license key see https://help.syncfusion.com/common/essential-studio/licensing/license-key.
             Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcxMTA2QDMxMzgyZTM0MmUzMGdrZ0lpbGlwUGhKQk8wZ0Vmb2pmWjQzUEdrSXNpekdycEROY25ab3dTUDg9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSyncfusionBlazor(true);
            builder.Services.AddScoped(typeof(ClientRepository<>));
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
