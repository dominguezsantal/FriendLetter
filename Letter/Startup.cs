using Microsoft.AspNetCore.Builder; //Library for
using Microsoft.AspNetCore.Hosting;//Library for
using Microsoft.AspNetCore.Http; //Library for
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectName
{
public class Startup
{
    public Startup(IWebHostEnvironment env)
    {
    var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddEnvironmentVariables();
    Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
    services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
    app.UseRouting();

    app.UseEndpoints(routes =>
    {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
    }
}
}