using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Request
{
    public class InitiateBulkBillPaymentRequest
    {
        public string bulk_reference { get; set; }=string.Empty;
        public string callback_url { get; set; } = string.Empty;
        public BulkData? bulk_data { get; set; }
    }

    public class BulkData
    {
        public string country { get; set; } = string.Empty;
        public string customer { get; set; } = string.Empty;
        public string amount { get; set; } = string.Empty;
        public string recurrence { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string reference { get; set; } = string.Empty;

    }
}
