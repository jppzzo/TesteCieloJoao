﻿using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System;
using TesteCielo.Models;

namespace TesteCielo.Services
{
    public class CieloSaleService
    {
        private readonly string _urlRequest = "https://apisandbox.cieloecommerce.cielo.com.br/1/sales";
        private string _merchantId = "9a1388e3-68fe-4ad1-85e5-60b8d4766599";
        private string _merchantKey = "EYWONCYWECYTNWAOSDGFHVENUFYKZERAJOGWXZKU";

        public Dictionary<bool, string> CreateTransactionCreditCard(CieloCreditCardModel cieloCreditCard)
        {
            var resultCreateTransactionCreditCard = new Dictionary<bool, string>();

            var client = new RestClient(_urlRequest);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);
            request.AddJsonBody(cieloCreditCard);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
            {
                var objResponse = JsonConvert.DeserializeObject<ResultCreditCardModel>(response.Content);
                Console.WriteLine("Resultado:" + response.Content);

                resultCreateTransactionCreditCard.Add(true, "");
            }
            else
                resultCreateTransactionCreditCard.Add(false, response.Content);

            return resultCreateTransactionCreditCard;
        }
    }
}
