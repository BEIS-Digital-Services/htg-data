using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Beis.Htg.VendorSme.Database.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Beis.Htg.VendorSme.Database.Tests;

/// <summary>
/// DbContext tests, to validate structure.
/// Currently only used as local integration test, until <see cref="vendor_api_call_status">vendor_api_call_status</see> is updated.
/// </summary>
[Ignore("Local Integration tests")]
[TestFixture]
public class DbContextSetTests
{
    private readonly MethodInfo? _setMethod =
        typeof(HtgVendorSmeDbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes);

    private readonly DbContextOptions<HtgVendorSmeDbContext> _dbContextOptions =
        new DbContextOptionsBuilder<HtgVendorSmeDbContext>()
            .UseInMemoryDatabase(databaseName: "htg")
            .Options;

    private static object[][] GetDbSets()
    {
        return typeof(HtgVendorSmeDbContext).GetProperties()
            .Where(propInfo => propInfo.PropertyType.IsGenericType
                               && typeof(DbSet<>).IsAssignableFrom(propInfo.PropertyType.GetGenericTypeDefinition()))
            .Select(propInfo => new object[] { propInfo.Name, propInfo.PropertyType.GetGenericArguments()[0] })
            .ToArray();
    }

    [Test, TestCaseSource(nameof(GetDbSets))]
    public async Task CheckEveryTableCanSelectFirstOrDefault(string setName, Type setType)
    {
        var dbContext = new HtgVendorSmeDbContext(_dbContextOptions);

        if (_setMethod != null)
        {
            var queryableSet = (IQueryable<object>?)_setMethod.MakeGenericMethod(setType).Invoke(dbContext, null);
            if (queryableSet != null)
            {
                Func<Task> act = async () =>
                {
                    await queryableSet.FirstOrDefaultAsync();
                };

                await act.Should().NotThrowAsync();
            }

            queryableSet.Should().NotBeNull();
        }

        _setMethod.Should().NotBeNull();
    }
}