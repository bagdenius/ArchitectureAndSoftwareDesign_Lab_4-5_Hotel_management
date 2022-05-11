using Autofac;
using Database;
using Entities;
using Repositories;
using Repositories.Abstract;
using UoW;
using UoW.Abstract;

namespace DAL_Modules
{
    public class UoWModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().SingleInstance();
            builder.RegisterType<Repository<HotelEntity>>().As<IRepository<HotelEntity>>().SingleInstance();
        }
    }
}