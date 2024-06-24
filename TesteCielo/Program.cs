using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using TesteCielo.Models;
using TesteCielo.Services;

namespace TesteCielo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a opção: (1-Criar transacao de cartão de crédito)");
            Console.WriteLine("Digite a opção: (2-Cancelar transacao de cartão de crédito)");
            var opcao = Console.ReadLine();

            var cieloServiceCreate = new CieloSaleService();
            var cieloServiceConsult = new CieloCancelService();

            switch (opcao)
            {
                case "1":
                    var objResultCreditCard = GetObjectCreditCard();
                    var resultCreditCardCreate = cieloServiceCreate.CreateTransactionCreditCard(objResultCreditCard);

                    if (resultCreditCardCreate.First().Key)
                        Console.WriteLine("Transação de cartão de crédito feita com sucesso");
                    else
                        Console.WriteLine("Erro: " + resultCreditCardCreate.First().Value);
                    break; // Adicione o 'break' aqui

                case "2":
                    var objResultCreditCardConsult = GetCancelTransactionCreditCard();
                    var resultCreditCardConsult = cieloServiceConsult.CancelTransactionCreditCard(objResultCreditCardConsult);

                    if (resultCreditCardConsult.First().Key)
                        Console.WriteLine("Transação de cartão de crédito cancelada com sucesso");
                    else
                        Console.WriteLine("Erro: " + resultCreditCardConsult.First().Value);
                    break; // Adicione o 'break' aqui

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.ReadKey();
        }

        private static ResultCreditCardModel GetCancelTransactionCreditCard()
        {
            var objResult = new ResultCreditCardModel();
            objResult.MerchantOrderId = "P10";

            objResult.Payment = new ResultCreditCardPayment();

            Console.WriteLine("Digite o ID do pagamento:");
            objResult.Payment.PaymentId = Console.ReadLine();
            Console.WriteLine("ID: " + objResult.Payment.PaymentId);
            objResult.Payment.Amount = 100;
            objResult.Payment.Interest = 0; 
            objResult.Payment.ServiceTaxAmount = 0;
            objResult.Payment.Installments = 1;
            objResult.Payment.Capture = true;
            objResult.Payment.Authenticate = false;
            objResult.Payment.Recurrent = false;
            objResult.Payment.Tid = "0622054306109";
            objResult.Payment.SoftDescriptor = "123456789ABCD";
            objResult.Payment.Provider = "Simulado";
            objResult.Payment.IsQrCode = false;
            objResult.Payment.ReceivedDate = "2024-06-22 17:43:06";
            objResult.Payment.Status = 10;
            objResult.Payment.IsSplitted = false;
            objResult.Payment.ReturnMessage = "Operation Successful";
            objResult.Payment.ReturnCode = "6";
            objResult.Payment.Type = "CreditCard";
            objResult.Payment.Currency = "BRL";
            objResult.Payment.Country = "BRA";

            return objResult;
        }
                 

        private static CieloCreditCardModel GetObjectCreditCard()
        {
            var objResult = new CieloCreditCardModel();
            objResult.MerchantOrderId = "P10";

            Console.WriteLine("Nome do cartão de crédito");
            objResult.Customer = new CieloCreditCardCustomer();
            objResult.Customer.Name = Console.ReadLine();
            Console.WriteLine("Nome do cartão de crédito: " + objResult.Customer.Name);

            Console.WriteLine("Digite o CPF:");
            objResult.Customer.Identity = Console.ReadLine();
            Console.WriteLine("CPF: " + objResult.Customer.Identity);

            Console.WriteLine("Digite o tipo de identidade (CPF/RG):");
            objResult.Customer.IdentityType = Console.ReadLine();
            Console.WriteLine("Tipo de Identidade: " + objResult.Customer.IdentityType);

            Console.WriteLine("Digite o email:");
            objResult.Customer.Email = Console.ReadLine();
            Console.WriteLine("Email: " + objResult.Customer.Email);

            Console.WriteLine("Digite a data de nascimento (YYYY-MM-DD):");
            objResult.Customer.Birthdate = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: " + objResult.Customer.Birthdate);

            // Exibir todos os valores no final
            Console.WriteLine("\nResumo das informações do cliente:");
            Console.WriteLine("Nome do cartão de crédito: " + objResult.Customer.Name);
            Console.WriteLine("CPF: " + objResult.Customer.Identity);
            Console.WriteLine("Tipo de Identidade: " + objResult.Customer.IdentityType);
            Console.WriteLine("Email: " + objResult.Customer.Email);
            Console.WriteLine("Data de Nascimento: " + objResult.Customer.Birthdate);

            objResult.Payment = new CieloCreditCardPayment();
            objResult.Payment.ServiceTaxAmount = 0;
            objResult.Payment.Installments = 1;
            objResult.Payment.Interest = "ByMerchant";
            objResult.Payment.Capture = true;
            objResult.Payment.Authenticate = false;
            objResult.Payment.Recurrent = "false";
            objResult.Payment.SoftDescriptor = "123456789ABCD";

            objResult.Payment.CreditCard = new CieloCreditCard();
            objResult.Payment.CreditCard.CardNumber = "4024007153763191";
            objResult.Payment.CreditCard.Holder = "Teste Holder";
            objResult.Payment.CreditCard.ExpirationDate = "12/2026";
            objResult.Payment.CreditCard.SecurityCode = "123";
            objResult.Payment.CreditCard.SaveCard = "false";
            objResult.Payment.CreditCard.Brand = "Visa";

            objResult.Payment.CreditCard.CardOnFile = new CieloCreditCardCardOnFile();
            objResult.Payment.CreditCard.CardOnFile.Usage = "Used";
            objResult.Payment.CreditCard.CardOnFile.Reason = "Unscheduled";

            objResult.Payment.Type = "CreditCard";
            objResult.Payment.Amount = 100;

            return objResult;
        }       
    }
}
