using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beis.Htg.VendorSme.Database
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddVoucherPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HtgVendorSmeDbContext>(options => options.UseNpgsql(configuration["HelpToGrowDbConnectionString"]));
            services.AddDataProtection().PersistKeysToDbContext<HtgVendorSmeDbContext>();
            return services;
        }
    }
}