namespace TestsForStringExtensions
{
    using System;
    using StringExtensions;

    public class TestMethods
    {
        // Do not evaluate this it isn't a part of the homework
        private static void Main(string[] args)
        {
            string abc = "abc";

            string testMD5 = abc.ToMd5Hash();
            Console.WriteLine(testMD5);

            string startString = "starty",
                    endString = "endy",
                    inputString = "the starty is longer than endy so what";

            string testGetStringsBetween = inputString.GetStringBetween(startString, endString, 2);
            Console.WriteLine(testGetStringsBetween);

            Console.WriteLine(abc.CapitalizeFirstLetter());

            string abtz = "абц";
            Console.WriteLine(abtz.ConvertCyrillicToLatinLetters());

            Console.WriteLine((abtz + abc).ConvertCyrillicToLatinLetters());

            string testUserName = "@#%$^Chov3k4#eP14";
            Console.WriteLine(testUserName.ToValidUsername());

            Console.WriteLine((testUserName + " e palen bom-bok").ToValidLatinFileName());

            Console.WriteLine(abc.GetFirstCharacters(2));

            string testFileExtensions = "strange.file.txt";
            Console.WriteLine(testFileExtensions.GetFileExtension());

            Console.WriteLine("docx".ToContentType());

            byte[] testByteArray = abc.ToByteArray();

            foreach (var item in testByteArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
