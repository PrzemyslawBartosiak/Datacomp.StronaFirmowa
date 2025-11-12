using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DataComp.StronaFirmowa.Strona.Components;
using Telerik.Blazor.Services;
using Microsoft.Extensions.Localization;
using Datacomp.StronaFirmowa.Fundament.Resources;
using System.Globalization;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HTTP Client
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Telerik Blazor
builder.Services.AddTelerikBlazor();

// Lokalizacja
builder.Services.AddLocalization();
builder.Services.AddSingleton<ITelerikStringLocalizer, ResxLocalizer>();

var host = builder.Build();

// ✅ Odczytaj kulturę z localStorage (jeśli istnieje)
var js = host.Services.GetRequiredService<IJSRuntime>();
var cultureFromStorage = await js.InvokeAsync<string>("localStorage.getItem", "culture");

var culture = !string.IsNullOrEmpty(cultureFromStorage)
    ? new CultureInfo(cultureFromStorage)
    : new CultureInfo("pl-PL");

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();