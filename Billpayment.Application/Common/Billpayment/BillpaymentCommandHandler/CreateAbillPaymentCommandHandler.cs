using Billpayment.Application.Common.Billpayment.BillpaymentCommand;
using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model.Request;
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
    public class CreateAbillPaymentCommandHandler : IRequestHandler<CreateAbillPaymentCommand, CreateBillPaymentResponse>
    {
        private readonly IBillpaymentService _vc;
        public CreateAbillPaymentCommandHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<CreateBillPaymentResponse> Handle(CreateAbillPaymentCommand request, CancellationToken cancellationToken)
        {
            var data = new CreateBillPaymentResource
            {
                amount = request.amount,
                biller_name = request.biller_name,
                country = request.country,
                customer = request.customer,
                recurrence = request.recurrence,
                reference = request.reference,
                type = request.type
            };
            return await _vc.CreateABillPayment(data);
        }
    }
}
