using Billpayment.Application.Common.Billpayment.BillpaymentQuery;
using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model.Resources;
using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentQueryHandler
{
    public class GetBillersQueryHandler : IRequestHandler<GetBillersQuery, GetBillersResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetBillersQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<GetBillersResponse> Handle(GetBillersQuery request, CancellationToken cancellationToken)
        {
            var data = new GetBillersResource
            {

            };
            return await _vc.GetBillers(data);
        }
    }
}
