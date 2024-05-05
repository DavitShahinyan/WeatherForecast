using Hangfire;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.BackgroundServices;
using WeatherForecast.DAL;
using WeatherForecast.DependencyInjection;
using WeatherForecast.Domain.Infrastructure.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WeatherForecastContext");
builder.Services.AddDbContext<WeatherForecastDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDAL();
builder.Services.AddServices();
builder.Services.AddHangfire(config => config.UseSqlServerStorage(connectionString));
builder.Services.AddHangfireServer();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new TimeOnlyConverter());
    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
}); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHangfireDashboard();

app.Services.AddBackgroundTasks();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
