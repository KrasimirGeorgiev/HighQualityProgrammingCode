namespace TemplateMethod.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HomeworkHelpers;

    public class TemplateTests
    {
        private static TextHelper helper = new TextHelper();

        private static string[] dirtyClothes =
        {
            "   dirty Ohhh so dirty,     this clothes       are     very dirty",
            " Theese clothes       are a    little dirty    ",
            "    Those are the most dirty clothes        I   have ever    seen ",
            "   This is possesed, its thoughts are very dirty "
        };

        private static void Main()
        {
            helper.SetupConsole();

            var WashPro = new WashingMachine();

            for (int i = 0; i < dirtyClothes.Length; i++)
            {
                string clothes = dirtyClothes[i];
                Console.WriteLine("Clothes before cleaning:");
                helper.PrintColorText(string.Format("{0}\n\n", clothes), ConsoleColor.DarkMagenta);

                clothes = WashPro.Programs[i].DoLoundry(clothes);

                Console.WriteLine("\nClothes after cleaning:");
                helper.PrintColorText(string.Format("{0}\n\n", clothes), ConsoleColor.DarkMagenta);
                Console.WriteLine("{0}", new string('-', Console.WindowWidth));
            }
        }
    }
}
