using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rost
{
    class ConsolePrinter : IPrinter
    {
        public void Print(List<string> printValue)
        {
            foreach (var el in printValue)
            {
                Console.WriteLine(el);
            }
        }
    }
}
