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
    public class ValidateABillServiceQueryHandler : IRequestHandler<ValidateABillServiceQuery, ValidateABillServiceResponse>
    {
        private readonly IBillpaymentService _vc;
        public ValidateABillServiceQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<ValidateABillServiceResponse> Handle(ValidateABillServiceQuery request, CancellationToken cancellationToken)
        {
            var data = new ValidateABillServiceResource
            {
               
            };
            return await _vc.ValidateAbillService(request.code,request.customer);

        }
    }
}
