using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentQuery
{
    public class ValidateABillServiceQuery:IRequest<ValidateABillServiceResponse>
    {
        public string code { get; set; } = string.Empty;
        public string customer { get; set; } = string.Empty;
    }
}
