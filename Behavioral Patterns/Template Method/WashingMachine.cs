namespace TemplateMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WashingMachine
    {
        public WashingMachine()
            : this(new List<WashingMachineProgram>()
            {
                new Cotton(), new Syntethics(),
                new Sport(), new Brain()
            })
        {
        }

        public WashingMachine(List<WashingMachineProgram> programs)
        {
            this.Programs = programs;
        }

        public List<WashingMachineProgram> Programs { get; private set; }
    }
}
