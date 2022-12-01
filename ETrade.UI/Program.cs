using ETrade.Dal;
using ETrade.Dto;
using ETrade.Entity.Concrete;
using ETrade.Repos.Abstract;
using ETrade.Repos.Concrete;
using ETrade.Repos.Concretes;
using ETrade.UI.Models.ViewModel;
using ETrade.Uow;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

//biz ekledik
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//

builder.Services.AddDbContext<TradeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));
builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoryRep, CategoryRep<Category>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductRep, ProductRep<Product>>();
builder.Services.AddScoped<ISupplierRep, SupplierRep<Supplier>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IUserRep, UserRep<User>>();
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<UserModel>();
builder.Services.AddScoped<BasketDetailModel>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();


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
//biz ekledik
app.UseSession();
//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
