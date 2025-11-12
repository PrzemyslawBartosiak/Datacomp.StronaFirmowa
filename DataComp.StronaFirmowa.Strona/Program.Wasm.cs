using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DataComp.StronaFirmowa.Strona.Components;
using Telerik.Blazor.Services;
using Microsoft.Extensions.Localization;
using Datacomp.StronaFirmowa.Fundament.Resources;
using System.Globalization;

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

// Lokalizacja - pliki .resx z Fundament bêd¹ dzia³aæ
builder.Services.AddLocalization();
builder.Services.AddSingleton<ITelerikStringLocalizer, ResxLocalizer>();

// ? WA¯NE: Ustaw kulturê (bo nie ma middleware jak w Server)
var culture = new CultureInfo("pl-PL");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await builder.Build().RunAsync();