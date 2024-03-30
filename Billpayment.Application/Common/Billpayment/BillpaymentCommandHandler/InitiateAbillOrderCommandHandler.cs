using Billpayment.Application.Common.Billpayment.BillpaymentCommand;
using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model.Resources;
using Billpayment.Application.Common.Response;
using MediatR;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentCommandHandler
{
    //public class InitiateAbillOrderCommandHandler : IRequestHandler<InitiateAbillOrderCommand, InitiateAbillOrderresponse>
    //{
    //    private readonly IBillpaymentService _vc;
    //    public InitiateAbillOrderCommandHandler(IBillpaymentService vc)
    //    {
    //        _vc = vc;
    //    }
    //    public Task<InitiateAbillOrderresponse> Handle(InitiateAbillOrderCommand request, CancellationToken cancellationToken)
    //    {
           
    //        var data = new InitiateAbillOrderResource
    //        {

    //            amount = request.amount,
    //            customer = new Model.Resources.Customer
    //            {
    //                email = request.customer.email,
    //                name = request.customer.name,
    //                phone_number = request.customer.phone_number,
    //            },
    //            reference = request.reference,
    //           fields=new List<string>
    //           {
                   
    //           }

    //        };
    //    }
    //}
}
