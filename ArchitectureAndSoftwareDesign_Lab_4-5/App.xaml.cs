using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DI;
using Domains;
using Mappers;
using UoW;
using UoW.Abstract;
using Services;
using Services.Abstract;
using System.Windows;

namespace UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterType<RoomsService>().As<IService<Room>>();
            builder.RegisterType<HotelsService>().As<IService<Hotel>>();
            builder.RegisterType<CustomersService>().As<IService<Customer>>();            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterModule<MappersModule>();

            var container = builder.Build();

            using var scope = container.BeginLifetimeScope();
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.Show();

                base.OnStartup(e);
            }
        }
    }
}
