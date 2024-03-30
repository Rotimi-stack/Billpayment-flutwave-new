using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Response
{
    public class Response
    {
    }

    public class CreateBillPaymentResponse 
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Data? data { get; set; }


    }

    public class GetAllBillPaymentsResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Dataa? data { get; set; }
    }

    public class Dataa
    {
        public Summary? summary { get; set; }
    }
    public class Summary
    {
        public string currency { get; set; } = string.Empty;
        public decimal sum_bills { get; set; } 
        public decimal sum_commission { get; set; } 
        public int sum_dstv { get; set; } 
        public int sum_airtime { get; set; }
        public int count_dstv { get; set; }
        public decimal count_airtime { get; set; }

    }

    public class Data
    {
        public string phone_number { get; set; } = string.Empty;
        public string amount { get; set; } = string.Empty;
        public string network { get; set; } = string.Empty;
        public string flw_ref { get; set; } = string.Empty;
        public string tx_ref { get; set; } = string.Empty;
        public string reference { get; set; } = string.Empty;
    }

    public class InitiateBulkBillsPaymentResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Datta? data { get; set; }
   


}
    public class Datta
    {
        public string batch_reference { get; set; } = string.Empty;
    }


    public class GetListRecurringBillPaymentsResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public datta data { get; set; }
    }
    
    public class datta
    {
        public int id { get; set;}
        public string unique_reference { get; set; } = string.Empty;
        public int amount { get; set; }
        public DateTime date_started { get; set; }
        public DateTime date_stopped { get; set; }
        public DateTime next_run { get; set; }
        public string recurring_type { get; set; } = string.Empty;

    }
    public class GetBillerDetailsResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public dats data { get; set; }

    }
    public class dats
    {
        public int id { get; set; }
        public string biller_code { get; set;} = string.Empty;
        public decimal default_commission { get; set; }
        public DateTime date_added { get; set;}
        public string country { get; set; } = string.Empty;
        public string is_airtime { get; set; } = string.Empty;
        public string biller_name { get; set; } = string.Empty;
        public string item_code { get; set; } = string.Empty;
        public string short_name { get; set; } = string.Empty;
        public int fee { get; set; }
        public bool commission_on_fee { get; set; }
        public string label_name { get; set; } = string.Empty;
    }



    public class ValidateABillServiceResponse
    {
      
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public BillService? data { get; set; }

    }

    public class BillService
    {
        public string response_code { get; set;} = string.Empty;
        public string address { get; set; } = string.Empty;
        public string response_message { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string biller_code { get; set; } = string.Empty;
        public string customer { get; set; } = string.Empty;
        public string product_code { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int fee { get; set; }
        public int maximum { get; set; }
        public int minimum { get; set; }
    }

    public class GetBillersResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public Bilers? data { get; set; }
    }

    public class Bilers
    {
        public string code { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
    }

    public class ListBillerProductsResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public BillerProducts? data { get; set; }
    }

    public class BillerProducts
    {
        public string biller_code { get; set; } = string.Empty;
        public string meta { get; set; } = string.Empty;
        public Products? products { get; set; }

    }

    public class Products
    {
        public string amount { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public string fee { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string description { get; set;} = string.Empty;

    }

    public class GetAbillerProductResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
    }


    public class AbillerProductResponse
    {
        public string exact { get; set; } = string.Empty;
    }

    public class Items
    {
        public string name { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;
        public bool required { get; set; }
        public string length { get; set; } = string.Empty;
        // public bool fixed { get; set; }
    }


    public class InitiateAbillOrderresponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public billorder? data { get; set; }

    }
    public class billorder
    {
        public string amount { get; set; } = string.Empty;
        public string fee { get; set; } = string.Empty;
        public string tx_ref { get; set; } = string.Empty;
        public string order_reference { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public string total_amount { get; set; } = string.Empty;
    }

    public class UpdateAbillOrderResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public billOrderresp? data { get; set; }
    }

    public class billOrderresp
    {
        public string amount { get; set; } = string.Empty;
        public string order_reference { get; set; } = string.Empty;
        public string total_amount { get; set; } = string.Empty;
        public Meta? meta { get; set; }
        public string fee { get; set; } = string.Empty;
        public string flw_ref { get; set; } = string.Empty;
        public string tx_ref { get; set; } = string.Empty;

    }

    public class Meta
    {
        public string rrr { get; set; } = string.Empty;
    }
}
