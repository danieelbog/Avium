using Serilog;
using System.Reflection;
using Web.BFF.Middlewares;
using Web.Core;
using Web.Events;
using Web.Map;
using Web.Services;
using Web.EntityFramework;
using Web.IdentityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddEvents()
    .AddMappers()
    .AddServices()
    .AddEntityFramework(builder.Configuration)
    .AddIdentityFramework(builder.Configuration);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();