using OrderApiSOLID.Factories;
using OrderApiSOLID.Repositories;
using OrderApiSOLID.Services;
using OrderApiSOLID.Services.Notifications;
using OrderApiSOLID.Services.Payment;
using OrderApiSOLID.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<SqlOrderRepository>();
builder.Services.AddScoped<MongoOrderRepository>();
builder.Services.AddScoped<IOrderRepositoryFactory, OrderRepositoryFactory>();
builder.Services.AddScoped<IOrderRepository, SqlOrderRepository>();
builder.Services.AddScoped<IOrderValidator, BasicOrderValidator>();
builder.Services.AddScoped<CreditCardProcessor>();
builder.Services.AddScoped<PayPalProcessor>();
builder.Services.AddScoped<IPaymentProcessorFactory, PaymentProcessorFactory>();
builder.Services.AddScoped<INotification, EmailNotification>();

builder.Services.AddScoped<OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
