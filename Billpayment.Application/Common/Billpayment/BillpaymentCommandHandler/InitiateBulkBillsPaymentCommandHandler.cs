using Billpayment.Application.Common.Billpayment.BillpaymentCommand;
using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model.Resources;
using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentCommandHandler
{
    public class InitiateBulkBillsPaymentCommandHandler : IRequestHandler<InitiateBulkBillsPaymentCommand, InitiateBulkBillsPaymentResponse>
    {
        private readonly IBillpaymentService _vc;
        public InitiateBulkBillsPaymentCommandHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async  Task<InitiateBulkBillsPaymentResponse> Handle(InitiateBulkBillsPaymentCommand request, CancellationToken cancellationToken)
        {
            var data = new InitiateBulkBillPaymentResource
            {
                bulk_reference = request.bulk_reference,
                callback_url = request.callback_url,
                bulk_data = new Model.Resources.BulkData
               {
                   amount=request.bulk_data.amount,
                   country=request.bulk_data.country,
                   customer=request.bulk_data.customer,
                   recurrence=request.bulk_data.recurrence,
                   reference=request.bulk_data.reference,
                   type=request.bulk_data.type,
               }
            };
            return await _vc.InitiateBulkBillsPayment(data);
        }
    }
}
