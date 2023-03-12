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

builder.Services.AddDbContext<ASU_DegestaContext>(options =>
    options.UseMySQL(connectionString));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<ASU_DegestaContext>();

builder.Services.AddDefaultIdentity<DegestaUser>(
        options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ASU_DegestaContext>();

builder.Services.Configure<SecurityStampValidatorOptions>(o => o.ValidationInterval = TimeSpan.FromSeconds(10));

builder.Services.AddSingleton(
    HtmlEncoder.Create(allowedRanges: new[] {UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic}));

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<ApplicationDbContext>();
//     //context.Database.Migrate();
//     // requires using Microsoft.Extensions.Configuration;
//     // Set password with the Secret Manager tool.
//     // dotnet user-secrets set SeedUserPW <pw>
//
//     var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");
//
//     await SeedData.Initialize(services, testUserPw);
// }

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
;

app.UseAuthorization();

//app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    //endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.Run();