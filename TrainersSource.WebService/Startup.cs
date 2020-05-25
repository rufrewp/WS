using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using TrainersSource.ApplicationServices.Repositories;
using TrainersSource.DomainObjects.Ports;
using TrainersSource.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryTrainersRepository>(x => new InMemoryTrainersRepository(
                new List<Trainers> {
                    new Trainers() 
                    {
                       Id = 1, Surname = "Абызова", Name = "Надежда", Patronymic = "Викторовна",Gender = "женский",Birthday = "19.01.1973",Sport = "Большой спорт"},
                new Trainers { Id = 2, Surname = "Алешина", Name = "Лариса", Patronymic = "Владимировна",Gender = "женский",Birthday = "01.02.1960",Sport = "Большой спорт"},
                new Trainers { Id = 3, Surname = "Андрюхин", Name = "Алексей", Patronymic = "Михайлович",Gender = "мужской",Birthday = "21.11.1973",Sport = "Спортивный резерв"},
                new Trainers { Id = 4,Surname = "Ануров", Name = "Александр", Patronymic = "Львович",Gender = "мужской",Birthday = "10.11.1957",Sport = "Большой спорт"}

                    
            }));
            services.AddScoped<IReadOnlyTrainersRepository>(x => x.GetRequiredService<InMemoryTrainersRepository>());
            services.AddScoped<ITrainersRepository>(x => x.GetRequiredService<InMemoryTrainersRepository>());

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
