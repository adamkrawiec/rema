using Microsoft.EntityFrameworkCore;
using rema.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddDbContext<RemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"))
);

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RemaContext>();
    context.Database.Migrate();
    var seeder = new Seeder(context);
    seeder.Seed();
}

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
app.UseHttpLogging();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "nestedRealEstates",
//     pattern: "real-estates/{realEstateId}/{controller=EstateUnit}/{action=Index}/{estateUnitId?}"
// );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
