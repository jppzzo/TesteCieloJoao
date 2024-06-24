using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System;
using TesteCielo.Models;

namespace TesteCielo.Services
{
    public class CieloCancelService
    {
        private readonly string _urlRequest = "https://apisandbox.cieloecommerce.cielo.com.br/1/sales/";
        private string _merchantId = "9a1388e3-68fe-4ad1-85e5-60b8d4766599";
        private string _merchantKey = "EYWONCYWECYTNWAOSDGFHVENUFYKZERAJOGWXZKU";

        public Dictionary<bool, string> CancelTransactionCreditCard(ResultCreditCardModel ResultCreditCardPayment)
        {
            var resultCancelTransactionCreditCard = new Dictionary<bool, string>();
            var urlCompleta = _urlRequest + ResultCreditCardPayment.Payment.PaymentId + "/void/";
            Console.WriteLine("urlCompleta : " + urlCompleta);

            var client = new RestClient(urlCompleta);
            
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);
            request.AddJsonBody(ResultCreditCardPayment);

            var response = client.Execute(request);

            Console.WriteLine("response.StatusCode : " + response.StatusCode);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
            {
                var objResponse = JsonConvert.DeserializeObject<ResultCreditCardModel>(response.Content);
                Console.WriteLine("response.Content : " + response.Content);

                resultCancelTransactionCreditCard.Add(true, "");
            }
            else
                resultCancelTransactionCreditCard.Add(false, response.Content);

            return resultCancelTransactionCreditCard;
        }
    }
}
