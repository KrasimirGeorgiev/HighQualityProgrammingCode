using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPatternExample
{
    public interface IDemand
    {
        IReadOnlyCollection<string> GetCoolStuff();

        void AddCoolStuff(string coolStuff);
    }
}
