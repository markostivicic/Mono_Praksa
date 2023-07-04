using Mono_projekt.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Mono_projekt.webapi.Controllers
{
    public class BooksController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Create([FromBody] CreateBookRest createBookRest)
        {
            Book book = Library.Create(createBookRest);
            if (book != null)
            {
                return Request.CreateResponse<Book>(HttpStatusCode.OK, book);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Didnt Create");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<GetBookRest> books = Library.MapBookToGetBookRest(Library.GetAllBooks());
            if (books.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, books);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Books Not Found");
            }
        }
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            Book book = Library.GetById(id);
            List<Book> newlist = new List<Book> { book };
            List<GetBookRest> books = Library.MapBookToGetBookRest(newlist);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Not Found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, books.First());
            }
            

        }

        [HttpPut]
        public HttpResponseMessage Update(Guid id, [FromBody] UpdateBookRest updateBookRest)
        {
            if (updateBookRest == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Body cannot be emty");
            }
            Book book = Library.Update(id, updateBookRest);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Not Found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, book);
            }

        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Library.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Not Found");
            }
        }

        

    }

    public class Library
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

            if(updateBookRest.AuthorName != null)
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
