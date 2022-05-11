using API_Modules;
using Autofac;
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
        }
    }
}
