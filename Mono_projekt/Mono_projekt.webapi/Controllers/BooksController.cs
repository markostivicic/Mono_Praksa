using Mono_projekt.webapi.DataStorage;
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
            Book book = BooksStorage.Create(createBookRest);
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
            List<GetBookRest> books = BooksStorage.MapBookToGetBookRest(BooksStorage.GetAllBooks());
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
            Book book = BooksStorage.GetById(id);
            List<Book> newlist = new List<Book> { book };
            List<GetBookRest> books = BooksStorage.MapBookToGetBookRest(newlist);
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
            Book book = BooksStorage.Update(id, updateBookRest);
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
                BooksStorage.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Not Found");
            }
        }
    }

}
