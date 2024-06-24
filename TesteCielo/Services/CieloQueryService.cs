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
        //Digite sua ID
        private string _merchantId = "Digite sua ID";
        //Digite sua Key
        private string _merchantKey = "Digite sua Key";

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
