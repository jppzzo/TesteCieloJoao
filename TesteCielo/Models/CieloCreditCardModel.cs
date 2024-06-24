namespace TesteCielo.Models
{
    public class CieloCreditCardAddress
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class CieloCreditCardBilling
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

    public class CieloCreditCardCardOnFile
    {
        public string Usage { get; set; }
        public string Reason { get; set; }
    }

    public class CieloCreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string SaveCard { get; set; }
        public string Brand { get; set; }
        public CieloCreditCardCardOnFile CardOnFile { get; set; }
    }

    public class CieloCreditCardCustomer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public CieloCreditCardAddress Address { get; set; }
        public CieloCreditCardDeliveryAddress DeliveryAddress { get; set; }
        public CieloCreditCardBilling Billing { get; set; }
    }

    public class CieloCreditCardDeliveryAddress
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class CieloCreditCardPayment
    {
        public int ServiceTaxAmount { get; set; }
        public int Installments { get; set; }
        public string Interest { get; set; }
        public bool Capture { get; set; }
        public bool Authenticate { get; set; }
        public string Recurrent { get; set; }
        public string SoftDescriptor { get; set; }
        public CieloCreditCard CreditCard { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
    }


    public class CieloCreditCardModel
    {
        public string MerchantOrderId { get; set; }
        public CieloCreditCardCustomer Customer { get; set; }
        public CieloCreditCardPayment Payment { get; set; }
    }
}
