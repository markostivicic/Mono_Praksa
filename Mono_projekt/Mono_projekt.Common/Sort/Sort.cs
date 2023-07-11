using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Common.Sort
{
    public class Sort : ISort
    {
        public string SortBy { get; set; } = "Id";
        public string Order { get; set; } = "ASC";
    }
}
