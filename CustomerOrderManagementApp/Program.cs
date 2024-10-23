using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Repositories;
using CustomerOrderManagementApp.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();

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

builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();

builder.Services.AddTransient<EcommerceDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
