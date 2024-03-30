using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentQuery
{
    public class GetListBillerProductsQuery:IRequest<ListBillerProductsResponse>
    {
        public string id { get; set; } = string.Empty;
    }
}
