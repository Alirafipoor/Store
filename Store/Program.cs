using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.interfaces.Contexts;
using Store.Application.interfaces.FacadPattern;
using Store.Application.Services.Commands.EditUser;
using Store.Application.Services.Commands.RegisterUser;
using Store.Application.Services.Commands.RemoveUser;
using Store.Application.Services.Commands.UserLogin;
using Store.Application.Services.Commands.UserStatusChange;
using Store.Application.Services.Common.Queries.GetCategory;
using Store.Application.Services.Common.Queries.GetHomePageImage;
using Store.Application.Services.Common.Queries.GetMenuItem;
using Store.Application.Services.Common.Queries.GetSlider;
using Store.Application.Services.HomePages.AddHomePageImage;
using Store.Application.Services.HomePages.AddNewSlider;
using Store.Application.Services.Product.FacadPattern;

using Store.Application.Services.User.Commands.RegisterUser;

using Store.Application.Services.User.Commands.UserLogin;

using Store.Application.Services.User.Queries.GetRole;
using Store.Application.Services.User.Queries.GetUser;
using Store.Persistence.Contexts;
using Store.Application.Services.HomePages.AddHomePageImage;
using Store.Application.Services.Cart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataBaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRoleServices, GetRoleServices>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();

builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddScoped<IGetMenusItem, GetMenuItem>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImage, AddHomePageImage>();
builder.Services.AddScoped<IGetHomePageImage, GetHomePageImagesService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DatabaseContext>(option =>
    {
        option.UseSqlServer();
    });



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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
