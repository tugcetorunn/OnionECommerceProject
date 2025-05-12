using OnionProject.Application.Layer.Mapper;
using OnionProject.Application.Layer.Services.Kategoriler;
using OnionProject.Application.Layer.Services.Login;
using OnionProject.Application.Layer.Services.Urunler;
using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Repositories.Abstracts;
using OnionProject.Infrastructure.Layer.Contexts;
using OnionProject.Infrastructure.Layer.Repositories.Concretes;
using OnionProject.UI.MVCCore.UIMappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UrunDbContext>();

builder.Services.AddIdentity<Uye, Rol>(x => x.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UrunDbContext>()
    .AddRoles<Rol>();

builder.Services.AddAutoMapper(typeof(ProjectMapper), typeof(UIMapper));

builder.Services.AddTransient<IUrunRepository, UrunRepository>();
builder.Services.AddTransient<IKategoriRepository, KategoriRepository>();
builder.Services.AddTransient<ISepetRepository, SepetRepository>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUrunService, UrunService>();
builder.Services.AddTransient<IKategoriService, KategoriService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Urun}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
