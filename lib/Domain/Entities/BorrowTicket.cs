namespace lib.Domain.Entities
{
    public class BorrowTicket : Entity
    {
        public int CopyId { get; set; }
        public string ClientName { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Tax { get; set; } = 0;

        public Copy Copy { get; set; }
    }
}
