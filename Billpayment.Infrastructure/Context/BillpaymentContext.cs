using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Billpayment.Infrastructure.Context
{
    public class BillpaymentContext : DbContext, IBillpaymentInterface
    {
        public BillpaymentContext(DbContextOptions<BillpaymentContext> options) : base(options)
        {
        }

        protected BillpaymentContext()
        {
        }

        public DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get; set; }
    }
}
