using Fridge.Repository;
using Fridge.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FridgeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FridgeContext") ?? throw new InvalidOperationException("Connection string 'FridgeContext' not found.")));
builder.Services.AddServerSideBlazor();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IItem, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

//create the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<FridgeContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initializer(context);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
