using AutoServiceConfigurationTests.TestRequirements.EFDataContexts;
using AutoServiceContainer;
using System;
using System.Collections.Generic;

namespace AutoServiceConfigurationTests.TestRequirements.AutoServiceConfigurationImplementation
{
    public class UnitTestServiceCreator<T>
        : AutoServiceCreator<T> where T : class
    {
        public UnitTestServiceCreator()
        {
            Sut = CreateService<T>(dataBase: DataBaseType.SqlLiteDataBase);
            Context = GetContext<EFDataContext>();
        }
        public UnitTestServiceCreator(Dictionary<Type, object> mockedObjects)
        {
            MockedObjects = mockedObjects;
            Sut = CreateService<T>(dataBase: DataBaseType.SqlLiteDataBase);
            Context = GetContext<EFDataContext>();
        }

        public T Sut { get; set; }
        public EFDataContext Context { get; set; }
    }
}
