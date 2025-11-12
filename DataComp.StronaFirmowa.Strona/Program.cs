using DataComp.StronaFirmowa.Strona.Components;
// using Datacomp.StronaFirmowa.Fundament.Data; // ❌ ZAKOMENTOWANE
using Datacomp.StronaFirmowa.Fundament.Resources;
// using Datacomp.StronaFirmowa.Fundament.Services; // ❌ ZAKOMENTOWANE
// using Datacomp.StronaFirmowa.Fundament.Services.Interfaces; // ❌ ZAKOMENTOWANE
using Microsoft.AspNetCore.Localization;
// using Microsoft.EntityFrameworkCore; // ❌ ZAKOMENTOWANE
using Microsoft.Extensions.Localization;
using System.Globalization;
using Telerik.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Telerik Blazor
builder.Services.AddTelerikBlazor();

#region Baza danych - WYŁĄCZONE DLA DEMO NA AZURE FREE
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Serwisy z Fundament - WYŁĄCZONE DLA DEMO NA AZURE FREE
// builder.Services.AddScoped<IFaqSerwis, FaqSerwis>();
// builder.Services.AddScoped<IBlogSerwis, BlogSerwis>();
// builder.Services.AddScoped<IAktualnosciSerwis, AktualnosciSerwis>();
// builder.Services.AddScoped<IKontaktSerwis, KontaktSerwis>();
// builder.Services.AddScoped<IAutentykacjaSerwis, AutentykacjaSerwis>();
#endregion

#region Lokalizacja - TO ZOSTAJE I BĘDZIE DZIAŁAĆ
builder.Services.AddLocalization();
builder.Services.AddSingleton<ITelerikStringLocalizer, ResxLocalizer>();
builder.Services.AddControllers();
#endregion

// Blazor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

#region Lokalizacja Middleware
var supportedCultures = new[] { "pl-PL", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());

app.UseRequestLocalization(localizationOptions);
#endregion

app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();