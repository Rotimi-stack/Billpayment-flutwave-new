using Billpayment.Application.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Billpayment.Application.Common.Interface
{
    public interface IBillpaymentInterface
    {
        DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get; set; }
    }
}
