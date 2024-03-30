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
    public class GetListBillerProductsQueryHandler : IRequestHandler<GetListBillerProductsQuery, ListBillerProductsResponse>
    {
        private readonly IBillpaymentService _vc;
        public GetListBillerProductsQueryHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<ListBillerProductsResponse> Handle(GetListBillerProductsQuery request, CancellationToken cancellationToken)
        {
            var data = new GetListBillerProductResource
            {
              
            };
            return await _vc.GetLIstOfBillerProducts(request.id);
        }
    }
}
