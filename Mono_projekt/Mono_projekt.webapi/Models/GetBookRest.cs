using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono_projekt.webapi.Models
{
    public class GetBookRest
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }

        public GetBookRest(Book book)
        {
            Title = book.Title;
            AuthorName = book.AuthorName;
            
        }
    }
}