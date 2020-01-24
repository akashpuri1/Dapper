using Autofac;
using SampleProject.Repository;
using SampleProject.Services;
using Unity;

namespace SampleProject
{
    public class RepositoryHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<IUserRepository, UserRepository>();

            builder.RegisterType<UserServices>().As<IUserServices>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}