namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public int Id { get; set; }        
        public string FullName { get; set; }
        public string Cvv { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}