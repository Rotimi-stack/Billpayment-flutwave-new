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
    public class GetABillerProductQueryHandler : IRequestHandler<GetABillerProductQuery, GetAbillerProductResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetABillerProductQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<GetAbillerProductResponse> Handle(GetABillerProductQuery request, CancellationToken cancellationToken)
        {
            var data = new GetABillerProductsResource
            {
               
            };
            return await _vc.GetABillerProduct(request.id,request.product_id);
        }
    }
}
