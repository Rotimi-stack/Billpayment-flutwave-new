using Billpayment.Application.Common.Billpayment.BillpaymentQuery;
using Billpayment.Application.Common.Interface;
using Billpayment.Application.Common.Model;
using Billpayment.Application.Common.Model.Request;
using Billpayment.Application.Common.Model.Resources;
using Billpayment.Application.Common.Response;
using Billpayment.Domain.Enum;
using Billpayment.Infrastructure.Context;
using Billpayment.Shared.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Billpayment.Infrastructure.Services
{
    public class BillpaymentService : IBillpaymentService
    {


        private readonly HttpClient _client;

        private readonly IConfiguration _config;
        private readonly ILogWritter _logger;
        private readonly BillpaymentContext _db;

        private static Logger log = LogManager.GetCurrentClassLogger();

        public BillpaymentService(IHttpClientFactory httpClientFactory, IConfiguration config, ILogWritter logger, BillpaymentContext db)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
            _logger = logger;
            _db = db;
        }

        public async Task<CreateBillPaymentResponse> CreateABillPayment(CreateBillPaymentResource vc)
        {
            var data = new CreateBillPaymentRequest
            {
                amount = vc.amount,
                biller_name = vc.biller_name,
                country = vc.country,
                customer = vc.customer,
                recurrence = vc.recurrence,
                reference = vc.reference,
                type = vc.type,
            };
            return await SendAsync<CreateBillPaymentRequest, CreateBillPaymentResponse>(
                data, "/v3/bills", BillpaymentHttpMethodType.Post);
        }

        public async Task<GetAbillerProductResponse> GetABillerProduct(string id, string product_id)
        {
           
            return await SendAsync<GetABillerProductQuery, GetAbillerProductResponse>(
              new GetABillerProductQuery(), $"/v3/billers/{id}/products/{product_id}", BillpaymentHttpMethodType.Get);
        }

        public async Task<GetAllBillPaymentsResponse> GetAllBillPayments(GetAllBillPaymentsResource vc)
        {
            var data = new GetAllBillPaymentQuery
            {
                from = vc.from,
                to = vc.to,
            };


            return await SendAsync<GetAllBillPaymentQuery, GetAllBillPaymentsResponse>(
               data, $"/v3/bills?from={vc.from}&to={vc.to}", BillpaymentHttpMethodType.Get);
        }

        public async Task<GetBillerDetailsResponse> GetBillerDetails(string power)
        {
           
            return await SendAsync<GetBillerDetailsQuery, GetBillerDetailsResponse>(
               new GetBillerDetailsQuery(), $"/v3/bill-categories?power={power}", BillpaymentHttpMethodType.Get);
        }

        public async Task<GetBillersResponse> GetBillers(GetBillersResource vc)
        {
            return await SendAsync<GetBillersQuery, GetBillersResponse>(
                new GetBillersQuery(), "/v3/billers", BillpaymentHttpMethodType.Get);
        }

        public async Task<ListBillerProductsResponse> GetLIstOfBillerProducts(string id)
        {
            
            return await SendAsync<GetListBillerProductsQuery, ListBillerProductsResponse>(
                new GetListBillerProductsQuery(), $"/v3/billers/{id}/products", BillpaymentHttpMethodType.Get);
        }

        public async Task<GetListRecurringBillPaymentsResponse> GetListofReccuringBillsPayment(GetListRecurringBillPaymentsResource vc)
        {
            return await SendAsync<GetListRecurringBillPaymentQuery, GetListRecurringBillPaymentsResponse>(
                new GetListRecurringBillPaymentQuery(), "", BillpaymentHttpMethodType.Get);
        }

        //public Task<CreateBillPaymentResponse> InitiateABillOrder(InitiateAbillOrderResource vc)
        //{
        //    var data = new InitiateAbillOrderResource
        //    {
        //        amount = vc.amount,
        //        customer= vc.customer,
        //        fields = vc.fields,
        //    }
        //}

        public async Task<InitiateBulkBillsPaymentResponse> InitiateBulkBillsPayment(InitiateBulkBillPaymentResource vc)
        {
            var data = new InitiateBulkBillPaymentRequest
            {
                bulk_data = new Application.Common.Model.Request.BulkData
                {
                   amount=vc.bulk_data.amount,
                   country=vc.bulk_data.country,
                   recurrence=vc.bulk_data.recurrence,
                   reference=vc.bulk_data.reference,
                   customer=vc.bulk_data.customer,
                   type=vc.bulk_data.type,
               },
                bulk_reference = vc.bulk_reference,
                callback_url = vc.bulk_reference,

            };
            return await SendAsync<InitiateBulkBillPaymentRequest, InitiateBulkBillsPaymentResponse>(
                data, "/v3/bulk-bills", BillpaymentHttpMethodType.Post);
        }

        public async Task<UpdateAbillOrderResponse> UpdateABillOrder(UpdateABillOrderResource vc, string id)
        {
            var data = new UpdateABillOrderRequest
            {
                amount = vc.amount,
                reference = vc.reference,
                
                
            };
            return await SendAsync<UpdateABillOrderRequest, UpdateAbillOrderResponse>(
                data, $"/v3/product-orders/{id}", BillpaymentHttpMethodType.Put);
        }

        public async Task<ValidateABillServiceResponse> ValidateAbillService(string code, string customer)
        {
           
            return await SendAsync<ValidateABillServiceQuery, ValidateABillServiceResponse>(
                new ValidateABillServiceQuery(), $"/v3/bill-items/AT099/validate?code={code}&customer={customer}", BillpaymentHttpMethodType.Get);
        }





        public async Task<U> SendAsync<T, U>(T payload, string relativePath, BillpaymentHttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddress").Value.ToString();
            var testkey = _config.GetSection("ApiKey").Value.ToString();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {testkey}");

            var message = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            string content;
            switch (httpMethod)
            {
                case BillpaymentHttpMethodType.Post:
                    var resp = await _client.PostAsync($"{baseaddress}{relativePath}", message);
                    content = await resp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    try

                    {


                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (resp.IsSuccessStatusCode)
                        {



                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (resp.StatusCode == HttpStatusCode.BadGateway || resp.StatusCode == HttpStatusCode.Unauthorized || resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.ServiceUnavailable || resp.StatusCode == HttpStatusCode.InternalServerError || resp.StatusCode == HttpStatusCode.NotFound || resp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }
                    return JsonConvert.DeserializeObject<U>(content);



                case BillpaymentHttpMethodType.Put:
                    var reesp = await _client.PutAsync($"{baseaddress}{relativePath}", message);
                    content = await reesp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    try
                    {
                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (reesp.IsSuccessStatusCode)
                        {
                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (reesp.StatusCode == HttpStatusCode.BadGateway || reesp.StatusCode == HttpStatusCode.Unauthorized || reesp.StatusCode == HttpStatusCode.BadRequest || reesp.StatusCode == HttpStatusCode.ServiceUnavailable || reesp.StatusCode == HttpStatusCode.InternalServerError || reesp.StatusCode == HttpStatusCode.NotFound || reesp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }

                    return JsonConvert.DeserializeObject<U>(content);


                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);


                    try
                    {
                        DateTime requestTime;
                        DateTime responseTime;
                        tblRequestandResponseLogs requestForDb = new tblRequestandResponseLogs();

                        if (ressp.IsSuccessStatusCode)
                        {
                            requestTime = DateTime.Now;
                            responseTime = DateTime.Now;
                            requestForDb = new tblRequestandResponseLogs() { RequestType = "VirtualCards", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseaddress };
                            _db.tblRequestAndResponse.Add(requestForDb);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            if (ressp.StatusCode == HttpStatusCode.BadGateway || ressp.StatusCode == HttpStatusCode.Unauthorized || ressp.StatusCode == HttpStatusCode.BadRequest || ressp.StatusCode == HttpStatusCode.ServiceUnavailable || ressp.StatusCode == HttpStatusCode.InternalServerError || ressp.StatusCode == HttpStatusCode.NotFound || ressp.StatusCode == HttpStatusCode.Forbidden)
                            {
                                responseTime = DateTime.Now;
                                requestForDb = new tblRequestandResponseLogs() { RequestType = "EnhancedKycVerification", RequestPayload = JsonConvert.SerializeObject(payload), Response = JsonConvert.SerializeObject(content), RequestTimestamp = responseTime, RequestUrl = baseaddress };
                                _db.tblRequestAndResponse.Add(requestForDb);
                                await _db.SaveChangesAsync();
                                return JsonConvert.DeserializeObject<U>(content);


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Something went wrong", ex);
                    }

                    return JsonConvert.DeserializeObject<U>(content);


            }

        }
    }
}
