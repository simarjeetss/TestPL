
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestPL.Models;
using TestPL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<PollingSystemDatabaseSettings>(
                builder.Configuration.GetSection(nameof(PollingSystemDatabaseSettings)));

builder.Services.AddSingleton<IPollingSystemDatabaseSettings>(sp =>sp.GetRequiredService<IOptions<PollingSystemDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("PollingSystemDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IPollService, PollService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())    
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
