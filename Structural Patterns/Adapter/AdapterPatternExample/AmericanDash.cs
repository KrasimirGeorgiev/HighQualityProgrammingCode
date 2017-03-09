using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPatternExample
{
    public class AmericanDash : Dash, ISpeed
    {

        private const double speedCoeficient = 1.66;

        public void ShowSpeed()
        {
            Console.WriteLine("Speed: {0}mph", this.GetSpeed(this.computer) * speedCoeficient);
        }
    }
}
