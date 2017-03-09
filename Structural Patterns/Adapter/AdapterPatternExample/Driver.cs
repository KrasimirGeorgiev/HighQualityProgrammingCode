using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPatternExample
{
    public class Driver
    {
        public EuropeanDash EuropeanDash
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public AmericanDash AmericanDash
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
