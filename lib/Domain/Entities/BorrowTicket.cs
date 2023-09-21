namespace lib.Domain.Entities
{
    public class BorrowTicket : Entity
    {
        public int CopyId { get; set; }
        public string ClientName { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalAmountDue { get; set; }

        public Copy Copy { get; set; }
    }
}
