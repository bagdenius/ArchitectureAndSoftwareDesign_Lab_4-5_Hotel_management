using API_Modules;
using Autofac;
using UI.ViewModels;
using UI.Views;

namespace UI.Main_module
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ControllerModule>();

            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterType<HotelsView>().SingleInstance();
            builder.RegisterType<RoomsView>().SingleInstance();
            builder.RegisterType<BookingView>().SingleInstance();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<HotelsViewModel>().SingleInstance();
            builder.RegisterType<RoomsViewModel>().SingleInstance();
            builder.RegisterType<BookingViewModel>().SingleInstance();
        }
    }
}
