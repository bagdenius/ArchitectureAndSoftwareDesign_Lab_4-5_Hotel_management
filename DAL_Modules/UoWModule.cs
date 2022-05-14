using Autofac;
using Database;
using Entities;
using Repositories;
using Repositories.Abstract;
using UoW;
using UoW.Abstract;

namespace DAL_Modules
{
    public class UoWModule
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().SingleInstance();
            builder.RegisterType<Repository<HotelEntity>>().As<IRepository<HotelEntity>>().SingleInstance();
            builder.RegisterType<Repository<RoomEntity>>().As<IRepository<RoomEntity>>().SingleInstance();
            builder.RegisterType<Repository<CustomerEntity>>().As<IRepository<CustomerEntity>>().SingleInstance();
        }
    }
}