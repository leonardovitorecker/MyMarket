using Microsoft.EntityFrameworkCore;
using MyMarket.Database;
using MyMarket.Helper;
using MyMarket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(
    options => options.UseNpgsql(


        "Host=localhost;Port=5432;Database=mart;User Id=postgres; Password=root;"));


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ISessao, Sessao>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSession();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
var app = builder.Build();




AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
    pattern: "{controller=Login}/{action=Create}/{id?}");
app.UseSession();
app.Run();
