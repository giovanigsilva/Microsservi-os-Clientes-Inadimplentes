using VShop.Web.Services;
using VShop.Web.Services.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient("ClienteApi", c =>
{
   c.BaseAddress = new Uri(builder.Configuration["ServiceUri:ClienteApi"]);
 }).ConfigureHttpMessageHandlerBuilder(builder =>
{
    builder.PrimaryHandler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (m, c, ch, e) => true,
        SslProtocols = System.Security.Authentication.SslProtocols.Tls12
    };

});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITituloService, TituloService>();

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

