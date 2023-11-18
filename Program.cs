using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace App;

public class Program
{
    // Run `ng serve` manually from the `ClientApp` folder
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
        });
        //app.MapControllers();

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
            //spa.UseAngularCliServer("start");
            spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
        });

        app.Run();
    }
}
