using CustomerMicroservice.Models.Data.MicroservicedbContext;
using CustomerMicroservice.Models.Data.Services;
using CustomerMicroservice.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomer,CustomerService>();
builder.Services.AddDbContext<MicroservicedbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("Conn"));
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Customers",
            Description = "Api End points of Customers",
            Version = "v1"
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers Microservice");

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
