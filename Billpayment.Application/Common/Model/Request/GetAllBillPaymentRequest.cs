﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Request
{
    public class GetAllBillPaymentRequest
    {
        public string from { get; set; }
        public string to { get; set; }
    }
}
