namespace TemplateMethod
{
    using System;

    public class Syntethics : WashingMachineProgram
    {
        protected override void HeatUp()
        {
            text.PrintColorText("Heating water up to 30°C\n", ConsoleColor.DarkRed);
        }

        protected override void Rinse()
        {
            text.PrintColorText("Washing synthetic clothes gently\n", ConsoleColor.DarkBlue);
            this.loundry = this.loundry.Replace("dirty", "sparky");
        }
    }
}