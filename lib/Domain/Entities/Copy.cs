﻿namespace lib.Domain.Entities
{
    public class Copy : Entity
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public bool IsBorrowed { get; set; }

        public Book Book { get; set; }
        public List<BorrowTicket> BorrowTickets { get; set; } = new List<BorrowTicket>();
    }
}
