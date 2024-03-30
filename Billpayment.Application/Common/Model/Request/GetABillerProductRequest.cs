using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Request
{
    public class GetABillerProductRequest
    {
        public string id { get; set; } = string.Empty;
        public string product_id { get; set; } = string.Empty;
    }
}
