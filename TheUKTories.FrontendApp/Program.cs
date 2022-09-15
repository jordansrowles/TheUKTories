global using TheUKTories.Services.Data.EFCore;
global using TheUKTories.Services.Data.EFCore.Models;
global using TheUKTories.Services.Data.EFCore.Models.Covid;
global using TheUKTories.Services.Data.EFCore.Models.People;

global using TheUKTories.FrontendApp.Pages.Shared.ViewModels;

using GovUk.Frontend.AspNetCore;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using TheUKTories.Services.BlobService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();
//builder.Services.AddResponseCaching();

builder.Services.AddGovUkFrontend(new GovUkFrontendAspNetCoreOptions() 
{ 
    AddImportsToHtml = false
});

builder.Services.AddTransient<SqlServerDataContext>();
builder.Services.AddTransient<BlobStorageService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseResponseCaching();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
