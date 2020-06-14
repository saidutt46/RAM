using System;
using Autofac;
using RAM.Data.Interfaces;
using RAM.Data.Interfaces.AuthInterfaces;
using RAM.Data.Repositories.RepoInterfaces;
using RAM.Infrastructure.Auth;
using RAM.Infrastructure.Data.Repositories;
using RAM.Infrastructure.Interfaces;
using RAM.Infrastructure.Logging;
using Module = Autofac.Module;

namespace RAM.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
