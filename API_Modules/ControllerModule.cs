using Autofac;
using BLL_Modules;
using Controllers;
using Controllers.Abstract;
using Models;

namespace API_Modules
{
    public class ControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelsController>().As<IController<HotelModel>>().SingleInstance();
            builder.RegisterType<RoomsController>().As<IController<RoomModel>>().SingleInstance();
            builder.RegisterType<CustomersController>().As<IController<CustomerModel>>().SingleInstance();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MappingModule>();
        }
    }
}