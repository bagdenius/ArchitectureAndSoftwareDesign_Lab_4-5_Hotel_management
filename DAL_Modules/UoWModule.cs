using Autofac;
using UoW;
using UoW.Abstract;

namespace DAL_Modules
{
    public class UoWModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}