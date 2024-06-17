namespace DMS_API.Data.Models.Domain
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public string TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public Transaction Transaction { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
    }
}
