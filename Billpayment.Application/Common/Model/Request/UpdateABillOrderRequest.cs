using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Request
{
    public class UpdateABillOrderRequest
    {
       public string amount { get; set; }=string.Empty;
       public string reference { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;

    }
}
