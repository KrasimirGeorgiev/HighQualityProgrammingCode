using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPatternExample
{
    public class CoolStuffRepo : IDemand
    {
        private List<string> coolStuff;

        public IReadOnlyCollection<string> GetCoolStuff()
        {
            return this.coolStuff.AsReadOnly();
        }

        public void AddCoolStuff(string coolStuff)
        {
            throw new NotImplementedException();
        }
    }
}
