using Billpayment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Billpayment_flutwave_new.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<BillpaymentContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
