using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Tangy_Business.Repository;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess.Data;
using TangyWeb_Server.Service;
using TangyWeb_Server.Service.IService;
using Microsoft.AspNetCore.Identity;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM5NjEwOUAzMjMwMmUzNDJlMzBCQ0IxL3JYZkdaRmJtdEpKTFFXSDU0SitETVUwemU1YWlQOURLWitHYklRPQ==");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// This will show the exceptions
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
SeedDatabase();
app.MapBlazorHub(); // Adding signalR here.
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}