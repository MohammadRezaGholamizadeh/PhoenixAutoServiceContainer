using Autofac;
using AutoServiceConfigurationTests.TestRequirements.EFDataContexts;
using AutoServiceContainer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AutoServiceConfigurationTests.TestRequirements.AutoServiceConfigurationImplementation
{
    public class AutoServiceCreator<T> : AutoServiceConfiguration
        where T : class
    {
        public override void ServicesConfiguration(
            ContainerBuilder container,
            Dictionary<Type, object> mockedServiceParameters,
            DbContext context)
        {
            container.RegisterType<TestService>()
                .As<ServiceInterface>()
                .WithConstructorParameters(mockedServiceParameters)
                .WithDbContext(context as EFDataContext)
                .SingleInstance();
        }

        public override DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)
        {
            return new InMemoryDataBase()
                       .CreateInMemoryDataContext<EFDataContext>(
                        sqliteConnection, null);
        }

        public override DbContext SqlServerConfiguration()
        {
            return new EFDataContext(GetConnectionString());
        }
    }
}
