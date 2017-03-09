namespace TemplateMethod
{
    using System;

    public class Brain : WashingMachineProgram
    {
        protected override void HeatUp()
        {
            text.PrintColorText("Heating water up to boiling temperature\n", ConsoleColor.DarkRed);
        }

        protected override void Rinse()
        {
            text.PrintColorText(
                "Intensively washing \"Don't call us we'll call you\"\n"
                , ConsoleColor.DarkBlue);
            this.loundry = "Don't call us we'll call you";
        }
    }
}