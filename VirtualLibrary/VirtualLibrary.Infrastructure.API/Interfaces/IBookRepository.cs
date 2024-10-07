﻿using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.API.Interfaces
{
    public interface IBookRepository : IRepository
    {

        public IEnumerable<Book> GetAllBooks();

        public IEnumerable<Book> GetBooksByName(string name);

        public IEnumerable<Book> GetBooksByAuthor(User author);

        public Book? GetBookByID(int ID);

        public bool CreateBook(Book book);

        public bool UpdateBook(Book book);

        public bool DeleteBook(Book book);

    }

}
