using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.DataProvider.Services.Imp;
using SalesDatePrediction.DataProvider.Services;
using SalesDatePrediction.Repository.Data;
using SalesDatePrediction.Repository.Models;
using SalesDatePrediction.Repository.Repositories.Imp;
using SalesDatePrediction.Repository.Repositories;
using SalesDatePrediction.DataProvider.Mappers;
using SalesDatePrediction.DataProvider.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddSingleton(provider =>
    new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    }).CreateMapper()
);

builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Shipper>, ShipperRepository>();
builder.Services.AddScoped<ICustomRepository, CustomRepository>();


builder.Services.AddScoped<IService<CustomerDto>, CustomerService>();
builder.Services.AddScoped<IService<EmployeeDto>, EmployeeService>();
builder.Services.AddScoped<IService<OrderDto>, OrderService>();
builder.Services.AddScoped<IService<ProductDto>, ProductService>();
builder.Services.AddScoped<IService<ShipperDto>, ShipperService>();
builder.Services.AddScoped<ICustomService, CustomService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new CustomDateFormatConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
