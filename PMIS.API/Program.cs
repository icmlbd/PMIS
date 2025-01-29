using PMIS.API.Formatters;
using PMIS.Application.Configurations;
using PMIS.Models.ConfigrationOptions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<PaymentGatewayOption>(builder.Configuration.GetSection("PaymentGateway:Paypal"));



builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new CustomerVcardOutputFormatter()); 
})
.AddNewtonsoftJson()
.AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(Program)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
