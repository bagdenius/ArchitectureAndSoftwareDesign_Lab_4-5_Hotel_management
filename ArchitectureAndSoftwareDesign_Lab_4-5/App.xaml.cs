using Autofac;
using System.Windows;
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

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.Show();
                base.OnStartup(e);
            }
        }
    }
}
