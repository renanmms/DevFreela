namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int id, string fullName, string cvv, string creditCardNumber, DateTime expiresAt)
        {
            Id = id;
            FullName = fullName;
            Cvv = cvv;
            CreditCardNumber = creditCardNumber;
            ExpiresAt = expiresAt;
        }

        public int Id { get; set; }        
        public string FullName { get; set; }
        public string Cvv { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}