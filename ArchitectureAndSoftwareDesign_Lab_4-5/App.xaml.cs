using Autofac;
using BLL_Modules;
using System.Windows;
using DAL_Modules;
using API_Modules;

namespace UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterModule<ControllerModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<UoWModule>();
            builder.RegisterModule<MappingModule>();

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
