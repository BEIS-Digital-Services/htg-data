using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Beis.HelpToGrow.Persistence.Tests;

[TestFixture]
public class ServiceCollectionExtensionTests
{
    [Test]
    public void AddVoucherPersistence_expect_success()
    {
        var configSource = new Dictionary<string, string>
        {
            {"HelpToGrowDbConnectionString", "no connection string"}
        };
        var services = new ServiceCollection();
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(configSource)
            .Build();

        services.AddVoucherPersistence(config);
        var provider = services.BuildServiceProvider();

        var context = provider.GetRequiredService<HtgVendorSmeDbContext>();
        var dataProtectionProvider = provider.GetRequiredService<IDataProtectionProvider>();

        context.Should().NotBeNull();
        dataProtectionProvider.Should().NotBeNull();
    }
}