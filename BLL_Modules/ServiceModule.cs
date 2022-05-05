using Autofac;
using Domains;
using Services;
using Services.Abstract;

namespace BLL_Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelsService>().As<IService<Hotel>>();
            builder.RegisterType<RoomsService>().As<IService<Room>>();
            builder.RegisterType<CustomersService>().As<IService<Customer>>();
        }
    }
}
