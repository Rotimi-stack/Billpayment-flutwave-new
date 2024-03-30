using Billpayment.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Billpayment.BillpaymentCommand
{
    public class CreateAbillPaymentCommand:IRequest<CreateBillPaymentResponse>
    {
        public string country { get; set; } = string.Empty;
        public string recurrence { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string biller_name { get; set; } = string.Empty;
        public string reference { get; set; } = string.Empty;
        public string customer { get; set; } = string.Empty;
        public int amount { get; set; }
    }
}
