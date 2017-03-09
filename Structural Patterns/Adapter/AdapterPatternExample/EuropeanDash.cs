using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPatternExample
{
    public class EuropeanDash : Dash, ISpeed
    {
        private const double speedCoeficient = 0.984;

        public void ShowSpeed()
        {
            Console.WriteLine("Speed: {0}km/h",this.GetSpeed(this.computer) * speedCoeficient);
        }
    }
}
