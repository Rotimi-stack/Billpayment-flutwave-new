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
    public class GetBillerDetailsQueryHandler : IRequestHandler<GetBillerDetailsQuery, GetBillerDetailsResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetBillerDetailsQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<GetBillerDetailsResponse> Handle(GetBillerDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = new GetBillerDetailsResource
            {
               
            };
            return await _vc.GetBillerDetails(request.power);
        }
    }
}
