namespace TemplateMethod
{
    using System;

    public class Cotton : WashingMachineProgram
    {
        protected override void HeatUp()
        {
            text.PrintColorText("Heating water up to 40°C\n", ConsoleColor.DarkRed);
        }

        protected override void Rinse()
        {
            text.PrintColorText("Washing cotton clothes carefully\n", ConsoleColor.DarkBlue);
            this.loundry = this.loundry.Replace("dirty", "shiny");
        }
    }
}