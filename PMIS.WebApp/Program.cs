using Microsoft.AspNetCore.Authentication.Cookies;
using PMIS.Application.Configurations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();



builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
    }); 

//builder.Services.AddTransient<ICustomerRepository>(c =>
//{
    
//    var httpContextAccessor = c.GetRequiredService<IHttpContextAccessor>();
//    string customerType = httpContextAccessor?.HttpContext?.Request.Query["customerType"].ToString();
//    if(customerType.ToLower()=="premium")
//    {
//        return new PremiumCustomerRepository();
//    }

//    return new CustomerRepository();
//});


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
