using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Blog.External.Presentations.Api.Middlewares.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static WebApplication UseHealthCheck(this WebApplication app)
        {
            app.MapHealthChecks("/healthz", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var asse = Assembly.GetExecutingAssembly();
                    var result = JsonSerializer.Serialize(
                        new
                        {
                            status = report.Status.ToString(),
                            checks = report.Entries.Select(e => new
                            {
                                name = e.Key,
                                status = e.Value.Status.ToString(),
                                exception = e.Value.Exception != null ? e.Value.Exception.Message : "none",
                                description = e.Value.Description
                            }),
                            metrics = new
                            {
                                Duration = report.TotalDuration,
                                LastBuild = File.GetLastWriteTime(asse.Location).ToString("dddd dd MMMM yyyy HH:mm:ss"),
                                LastAccess = File.GetLastAccessTime(asse.Location).ToString("dddd dd MMMM yyyy HH:mm:ss")
                            }
                        });

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });

            return app;
        }
    }
}

