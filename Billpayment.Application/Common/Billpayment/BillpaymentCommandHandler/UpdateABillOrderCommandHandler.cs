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
    internal class UpdateABillOrderCommandHandler : IRequestHandler<UpdateAbillOrderCommand, UpdateAbillOrderResponse>
    {
        private readonly IBillpaymentService _vc;
        public UpdateABillOrderCommandHandler(IBillpaymentService vc)
        {
            _vc = vc;
        }
        public async Task<UpdateAbillOrderResponse> Handle(UpdateAbillOrderCommand request, CancellationToken cancellationToken)
        {
            var data = new UpdateABillOrderResource
            {
                amount = request.amount,
                reference = request.reference,
               
                
            };
            return await _vc.UpdateABillOrder(data,request.id);
        }
    }
}
