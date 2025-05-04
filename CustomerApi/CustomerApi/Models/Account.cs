
namespace CustomerApi.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedTimestamp { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public decimal Balance { get; set; }
    }
}
