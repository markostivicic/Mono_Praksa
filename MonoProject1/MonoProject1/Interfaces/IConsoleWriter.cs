using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject1.Interfaces
{
    public interface IConsoleWriter
    {
        string Prefix { get; set; }
        void WriteLine(string line);
    }
}
