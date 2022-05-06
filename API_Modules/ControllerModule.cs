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
            builder.RegisterType<HotelsController>().As<IController<HotelModel>>();
            builder.RegisterType<RoomsController>().As<IController<RoomModel>>();
            builder.RegisterType<CustomersController>().As<IController<CustomerModel>>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MappingModule>();
        }
    }
}