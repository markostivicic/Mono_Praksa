using Mono_projekt.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono_projekt.webapi.DataStorage
{
    public class BooksStorage
    {
        private static ICollection<Book> _books = new List<Book>();
        public static Book Create(CreateBookRest createBookRest)
        {
            Guid id = Guid.NewGuid();
            Book book = new Book();
            book.Id = id;
            book.Title = createBookRest.Title;
            book.AuthorName = createBookRest.AuthorName;
            _books.Add(book);
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public static List<GetBookRest> MapBookToGetBookRest(List<Book> books)
        {
            List<GetBookRest> list = new List<GetBookRest>();
            foreach (Book book in books)
            {
                GetBookRest newbook = new GetBookRest(book);
                list.Add(newbook);
            }
            return list;
        }

        public static Book GetById(Guid id)
        {
            return _books.Where(a => a.Id == id).FirstOrDefault();
        }

        public static Book Update(Guid id, UpdateBookRest updateBookRest)
        {
            Book book = GetById(id);

            if (updateBookRest.AuthorName != null)
            {
                book.AuthorName = updateBookRest.AuthorName;

            }

            if (updateBookRest.Title != null)
            {
                book.Title = updateBookRest.Title;
            }

            return book;
        }

        public static void Delete(Guid id)
        {
            _books.Remove(_books.Single(a => a.Id == id));
        }
    }
}