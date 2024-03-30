using Azure.Core;
using Billpayment.Application.Common.Model.Resources;
using Billpayment.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Application.Common.Interface
{
    public interface IBillpaymentService
    {
        Task<CreateBillPaymentResponse> CreateABillPayment(CreateBillPaymentResource vc);
        Task<GetAllBillPaymentsResponse> GetAllBillPayments(GetAllBillPaymentsResource vc);
        Task<InitiateBulkBillsPaymentResponse> InitiateBulkBillsPayment(InitiateBulkBillPaymentResource vc);
        Task<GetListRecurringBillPaymentsResponse> GetListofReccuringBillsPayment(GetListRecurringBillPaymentsResource vc);
        Task<GetBillerDetailsResponse> GetBillerDetails(string power);
        Task<ValidateABillServiceResponse> ValidateAbillService(string code, string customer);
        Task<GetBillersResponse> GetBillers(GetBillersResource vc);
        Task<ListBillerProductsResponse> GetLIstOfBillerProducts(string id);
        Task<GetAbillerProductResponse> GetABillerProduct(string id, string product_id);
        //Task<CreateBillPaymentResponse> InitiateABillOrder(InitiateAbillOrderResource vc);
        Task<UpdateAbillOrderResponse> UpdateABillOrder(UpdateABillOrderResource vc, string id);

    }
}
