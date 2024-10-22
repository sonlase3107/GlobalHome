using TodoApi.DomainLogic;
using TodoApi.Extentions;
using TodoApi.Infrastructure;
using TodoApi.Repository;

namespace TodoApi
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void OnStopped()
        {
            // Perform post-stopped activities here

        }
        private void OnStopping()
        {
            // Perform on-stopping activities here
            Console.WriteLine("LAS Stoping");
        }
        private void OnStarted()
        {
            // Perform post-startup activities here
            Console.WriteLine("LAS Start Application");
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<UserDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserDomainService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                appLifetime.StopApplication();
                // Don't terminate the process immediately, wait for the Main thread to exit gracefully.
                eventArgs.Cancel = true;
            };

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseMiddleware<CustomMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = "api";
            });
            app.UseEndpoints(endpoints => {
                
                endpoints.MapControllers();
                endpoints.MapGet("/hello", () => "Hello World");
            });
        }
    }
}
