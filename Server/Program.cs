using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Sallamation.Server.Data;
using Sallamation.Server.Extensions;
using Sallamation.Server.Hubs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SallamationContext>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SallamationContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreDB")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7107", "http://localhost:7107").AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

var app = builder.Build();
app.MigrateDatabase<Program>();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

//app.MapRazorPages();
//app.MapControllers();
app.MapHub<AuthHub>("/authhub");
//app.MapFallbackToFile("index.html");

app.Run();
