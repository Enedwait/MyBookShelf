using Autofac;
using MyBookShelf.Shared.Constants;
using MyBookShelf.Shared.DataAccess.Factories;
using MyBookShelf.Shared.DataAccess.Repositories;

namespace MyBookShelf.WebForms.Infrastructure.DI
{
    public sealed class DependencyModule : Module
    {
        #region Load

        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings[Defaults.CONNECTION].ConnectionString;

            builder.RegisterInstance(new SqlConnectionFactory(connectionString))
                .As<IDbConnectionFactory>()
                .SingleInstance();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();
        }

        #endregion
    }
}