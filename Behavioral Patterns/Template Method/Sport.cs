using System;

namespace TemplateMethod
{
    public class Sport : WashingMachineProgram
    {
        protected override void HeatUp()
        {
            text.PrintColorText("Heating water up to 35°C\n", ConsoleColor.DarkRed);
        }

        protected override void Rinse()
        {
            text.PrintColorText("Intensively washing sport clothes\n", ConsoleColor.DarkBlue);
            this.loundry = this.loundry.Replace("dirty", "sporty");
        }
    }
}