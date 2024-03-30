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
    public class GetListRecurringBillPaymentQueryHandler : IRequestHandler<GetListRecurringBillPaymentQuery, GetListRecurringBillPaymentsResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetListRecurringBillPaymentQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<GetListRecurringBillPaymentsResponse> Handle(GetListRecurringBillPaymentQuery request, CancellationToken cancellationToken)
        {
            var data = new GetListRecurringBillPaymentsResource
            {

            };
            return await _vc.GetListofReccuringBillsPayment(data);
        }
    }
}
