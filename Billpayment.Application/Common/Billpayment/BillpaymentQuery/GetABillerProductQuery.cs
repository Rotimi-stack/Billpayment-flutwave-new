using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentQuery
{
    public class GetABillerProductQuery:IRequest<GetAbillerProductResponse>
    {
        public string id { get; set; } = string.Empty;
        public string product_id { get; set; } = string.Empty;
    }
}
