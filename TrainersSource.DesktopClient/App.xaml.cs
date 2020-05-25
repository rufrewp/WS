using Microsoft.Extensions.DependencyInjection;
using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using TrainersSource.ApplicationServices.Ports.Cache;
using TrainersSource.ApplicationServices.Repositories;
using TrainersSource.DesktopClient.InfrastructureServices.ViewModels;
using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using TrainersSource.InfrastructureServices.Cache;
using TrainersSource.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TrainersSource.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<Trainers>, DomainObjectsMemoryCache<Trainers>>();
            services.AddSingleton<NetworkTrainersRepository>(
                x => new NetworkTrainersRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<Trainers>>())
            );
            services.AddSingleton<CachedReadOnlyTrainersRepository>(
                x => new CachedReadOnlyTrainersRepository(
                    x.GetRequiredService<NetworkTrainersRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<Trainers>>()
                )
            );
            services.AddSingleton<IReadOnlyTrainersRepository>(x => x.GetRequiredService<CachedReadOnlyTrainersRepository>());
            services.AddSingleton<IGetTrainersListUseCase, GetTrainersListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
