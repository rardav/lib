﻿using lib.Application;
using lib.Application.Repositories;
using lib.Application.Repositories.Contracts;
using lib.Domain.Context;
using Microsoft.Extensions.DependencyInjection;

namespace lib
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IBookRepository, BookRepository>()
                .AddDbContext<LibraryContext>()
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
                context.Database.EnsureCreated();
            }

            //var service = serviceProvider.GetService<IBookRepository>();

            //var books = await service.GetBooks();

            ////foreach (var book in books)
            ////{
            ////    Console.WriteLine(book.Id + " " + book.Title + " " + book.Author + " " + book.Isbn);
            ////}
        
            MainMenu.StartApp();
        }
    }
}


