using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mono_projekt.webapi.Models
{
    public class CreateBookRest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}