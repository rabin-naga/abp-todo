using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Todos
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApplication<TodosHttpApiHostModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      app.InitializeApplication();
      app.UseIdentityServer();
    }
  }
}
