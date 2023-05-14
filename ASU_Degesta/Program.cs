using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ASU_DegestaContextConnection") ??
                       throw new InvalidOperationException(
                           "Connection string 'ASU_DegestaContextConnection' not found.");

var connectionString2 = builder.Configuration.GetConnectionString("SmartASP") ??
                       throw new InvalidOperationException(
                           "Connection string 'SmartASP' not found.");

builder.Services.AddDbContext<ASU_DegestaContext>(options =>
    options.UseMySQL(connectionString2));

builder.Services.AddDefaultIdentity<DegestaUser>(
        options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ASU_DegestaContext>();

builder.Services.Configure<SecurityStampValidatorOptions>(o => o.ValidationInterval = TimeSpan.FromSeconds(10));

builder.Services.AddSingleton(
    HtmlEncoder.Create(allowedRanges: new[] {UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic}));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();