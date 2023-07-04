using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono_projekt.webapi.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }

}