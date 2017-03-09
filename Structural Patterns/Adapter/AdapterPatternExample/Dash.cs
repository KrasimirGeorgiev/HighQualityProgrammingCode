using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPatternExample
{
    public abstract class Dash
    {
        protected JapanCarComputer computer;

        public double GetSpeed(JapanCarComputer computer)
        {
            return computer.CurentSpeed();
        }
    }
}
