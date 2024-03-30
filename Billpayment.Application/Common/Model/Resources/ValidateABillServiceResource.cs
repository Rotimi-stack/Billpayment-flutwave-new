using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Resources
{
    public class ValidateABillServiceResource
    {
        public string code { get; set; } = string.Empty;
        public string customer { get; set; } = string.Empty;
    }
}
