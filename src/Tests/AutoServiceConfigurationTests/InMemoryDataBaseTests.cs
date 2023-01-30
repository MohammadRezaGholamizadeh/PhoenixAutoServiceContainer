using AutoServiceConfigurationTests.TestRequirements.EFDataContexts;
using AutoServiceContainer;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Xunit;

namespace AutoServiceConfigurationTests
{
    public class InMemoryDataBaseTests
    {
        [Fact]
        public void Create_inMemoryDataBase()
        {
            var sqlliteConnection = new SqliteConnection();

            var dbContext =
                new InMemoryDataBase()
                .CreateInMemoryDataContext<EFDataContext>(
                    sqlliteConnection,
                    null);

            dbContext.Should().NotBeNull();
            dbContext.Should().BeOfType(typeof(EFDataContext));
        }
    }
}
