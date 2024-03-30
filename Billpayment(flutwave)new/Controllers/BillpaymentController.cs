using Billpayment.Application.Common.Billpayment.BillpaymentCommand;
using Billpayment.Application.Common.Billpayment.BillpaymentQuery;
using Billpayment.Application.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Billpayment_flutwave_new.Controllers
{
    public class BillpaymentController : BaseController
    {
        [HttpPost("create-a-bill-payment")]
        public async Task<ActionResult<CreateBillPaymentResponse>> CreateABillPayment(CreateAbillPaymentCommand bc)
        {
            return await Mediator.Send(bc);
        }


        [HttpGet("get-all-biller-product")]
        public async Task<ActionResult<GetAbillerProductResponse>> GetABillerProduct([FromQuery] string id, string product_id)
        {
            return await Mediator.Send(new GetABillerProductQuery { id = id, product_id = product_id });
        }


        [HttpGet("get-all-bill-payments")]
        public async Task<ActionResult<GetAllBillPaymentsResponse>> GetAllBillPayments([FromQuery] string from, [FromQuery] string to)
        {
            return await Mediator.Send(new GetAllBillPaymentQuery { from = from, to = to });
        }

        [HttpGet("get-biller-details")]
        public async Task<ActionResult<GetBillerDetailsResponse>> GetBillerDetails([FromQuery] string power)
        {
            return await Mediator.Send(new GetBillerDetailsQuery { power = power });
        }

        [HttpGet("get-billers")]
        public async Task<ActionResult<GetBillersResponse>> GetBillers()
        {
            return await Mediator.Send(new GetBillersQuery());
        }

        [HttpGet("get-list-biller-products")]
        public async Task<ActionResult<ListBillerProductsResponse>> GetLIstOfBillerProducts([FromQuery]string id)
        {
            return await Mediator.Send(new GetListBillerProductsQuery { id = id });
        }

        [HttpGet("get-list-recurring-bill-payment")]
        public async Task<ActionResult<GetListRecurringBillPaymentsResponse>> GetListofReccuringBillsPayment()
        {
            return await Mediator.Send(new GetListRecurringBillPaymentQuery());
        }

        [HttpPut("validate-bill-service")]
        public async Task<ActionResult<ValidateABillServiceResponse>> ValidateAbillService([FromQuery]string code, [FromQuery]string customer)
        {
            return await Mediator.Send(new ValidateABillServiceQuery { code = code, customer = customer });
        }

        [HttpPost("initiate-bulk-bills-payment")]
        public async Task<ActionResult<InitiateBulkBillsPaymentResponse>> InitiateBulkBillsPayment(InitiateBulkBillsPaymentCommand bc)
        {
            return await Mediator.Send(bc);
        }

        [HttpPut("update-bill-order")]
        public async Task<ActionResult<UpdateAbillOrderResponse>> UpdateABillOrder(UpdateAbillOrderCommand bc)
        {
            return await Mediator.Send(bc);
        }



    }
    
}
