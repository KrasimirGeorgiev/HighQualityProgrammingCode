namespace TemplateMethod
{
    using System;
    using System.Text.RegularExpressions;
    using HomeworkHelpers;

    public abstract class WashingMachineProgram
    {
        /// <summary>
        /// Washing with the power of Regex
        /// </summary>
        private static Regex multipleWhite = new Regex(@"\s{2,}");

        /// <summary>
        /// This is added only to print colored text for the homework, the real class
        ///  should neither print text on a console or need a text helper...
        /// </summary>
        protected static TextHelper text = new TextHelper();

        protected string loundry;

        private void FillWater()
        {
            text.PrintColorText("Filling with water\n", ConsoleColor.DarkBlue);
        }

        private void Spin()
        {
            text.PrintColorText("Centrifuging loundry\n", ConsoleColor.DarkRed);
            this.loundry = multipleWhite.Replace(this.loundry, " ");
            this.loundry = this.loundry.Trim();
        }

        protected abstract void HeatUp();

        protected abstract void Rinse();

        public string DoLoundry(string loundry)
        {
            this.loundry = loundry;

            text.PrintColorText("Initiating washing proragm...\n", ConsoleColor.DarkGreen);

            this.FillWater();
            this.HeatUp();
            this.Rinse();
            this.Spin();

            text.PrintColorText("Washing completed, enjoy the result\n", ConsoleColor.DarkGreen);

            string cleanLoundry = this.loundry;
            this.loundry = String.Empty;

            return cleanLoundry;
        }
    }
}