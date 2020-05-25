using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrainersSource.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using TrainersSource.ApplicationServices.Ports.Gateways.Database;
using TrainersSource.ApplicationServices.Repositories;
using TrainersSource.DomainObjects.Ports;

namespace TrainersSource.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrainersContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "TrainersSource.db")}")
            );

            services.AddScoped<ITrainersDatabaseGateway, TrainersEFSqliteGateway>();

            services.AddScoped<DbTrainersRepository>();
            services.AddScoped<IReadOnlyTrainersRepository>(x => x.GetRequiredService<DbTrainersRepository>());
            services.AddScoped<ITrainersRepository>(x => x.GetRequiredService<DbTrainersRepository>());

            services.AddScoped<IGetTrainersListUseCase, GetTrainersListUseCase>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
