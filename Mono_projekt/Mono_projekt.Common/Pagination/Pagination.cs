using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Common.Pagination
{
    public class Pagination : IPagination
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
    }
}
