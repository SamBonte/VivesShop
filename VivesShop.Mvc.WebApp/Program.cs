
using Microsoft.EntityFrameworkCore;
using VivesShop.Mvc.WebApp.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString(nameof(VivesShopDbContext));
// AddDbContext => scoped 
builder.Services.AddDbContext<VivesShopDbContext>(options =>
{
    //options.UseSqlServer(connectionString);
    options.UseInMemoryDatabase(nameof(VivesShopDbContext));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // zeggen tegen service provider => Geef me een database, EN We weten dat hij geregistreerd is
    // iets dat disposable is = proper opkuisen na uitvoering
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<VivesShopDbContext>();

    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }


}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
