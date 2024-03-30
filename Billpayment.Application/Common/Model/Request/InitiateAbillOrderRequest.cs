using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Model.Request
{
    public class InitiateAbillOrderRequest
    {
        public string amount { get; set; }= string.Empty;
        public string reference { get; set; }= string.Empty;
        public Customer? customer { get; set; }
        public List<Fields>? fields { get; set; }
    }

    public class Customer
    {
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
    }

    public class Fields
    {
        public string id { get; set; } = string.Empty;
        public string quantity { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;

        public static implicit operator List<object>(Fields v)
        {
            throw new NotImplementedException();
        }
    }
}
