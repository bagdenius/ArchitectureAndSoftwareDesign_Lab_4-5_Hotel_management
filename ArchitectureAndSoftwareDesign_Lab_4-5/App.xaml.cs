using Autofac;
using System.Windows;
using UI.Views;
using UI.Main_module;

namespace UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();

                scope.Resolve<HotelsView>();
                scope.Resolve<RoomsView>();
                scope.Resolve<BookingView>();
                mainWindow.Show();
                base.OnStartup(e);
            }
        }
    }
}
