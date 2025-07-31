using Blog.External.Infrastructures.CrossCutting;
using Blog.External.Presentations.Api.Middlewares.HealthCheck;
using Blog.External.Presentations.Api.Middlewares.Hosting;
using Blog.External.Presentations.Api.Middlewares.Json;
using Blog.External.Presentations.Api.Middlewares.Security;
using Blog.External.Presentations.Api.Middlewares.Swagger;
using Blog.External.Presentations.Api.Middlewares.Versioning;
using Blog.Internal.Applications.Core.Services;

var builder = WebApplication.CreateBuilder(args);


#region - Services -
builder.Services.AddCors();
builder.Services.AddLogging();
builder.Services.AddSecurity(builder.Configuration);
builder.Host.AddConfiguration();
builder.Services.AddJsonConfig();
builder.Services.AddControllers();
builder.Services.AddSwaggerDocs();
builder.Services.AddHealthChecks();
builder.Services.AddApiVersioningConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependency(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next();
});

#region  - Pipeline de Inicialização -
app.UseStaticFiles();
app.UseSwaggerDocs();
app.UseHttpsRedirection();
app.UseSecurity();

app.MapControllers();
app.UseHealthCheck();
#endregion

#region - WebSockets -
app.UseWebSockets();

app.Map("/ws", async context =>
{
if (context.WebSockets.IsWebSocketRequest)
{
    var socket = await context.WebSockets.AcceptWebSocketAsync();
    var handler = app.Services.GetService<WebSocketHandler>();
    await handler?.AddSocket(socket)!;
}
else
{
    context.Response.StatusCode = 400;
}
});
#endregion


app.Run();

