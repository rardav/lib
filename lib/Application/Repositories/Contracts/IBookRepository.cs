﻿using lib.Domain.Entities;

namespace lib.Application.Repositories.Contracts
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<Book?> GetBookWithCopiesAndTickets(string title);
        public Task InsertBook(Book book);
        Task UpdateBook(Book book);
    }
}
