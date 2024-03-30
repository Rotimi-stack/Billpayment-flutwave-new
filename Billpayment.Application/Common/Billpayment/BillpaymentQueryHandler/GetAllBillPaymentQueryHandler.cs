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
    public class GetAllBillPaymentQueryHandler : IRequestHandler<GetAllBillPaymentQuery, GetAllBillPaymentsResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetAllBillPaymentQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<GetAllBillPaymentsResponse> Handle(GetAllBillPaymentQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAllBillPaymentsResource
            {
               from=request.from,
               to=request.to
                
            };
            return await _vc.GetAllBillPayments(data);
        }
    }
}
