namespace IteratorTests
{
    using System;
    using Iterator;
    using HomeworkHelpers;

    class Program
    {
        static TextHelper helper = new TextHelper();

        static void Main()
        {
            var myMatrix = new Matrix<double>(3, 3);

            helper.PrintColorText("Filling Matrix:\n\n", "cyan");

            for (int i = 0; i < myMatrix.Rows; i++)
            {
                for (int j = 0; j < myMatrix.Cols; j++)
                {
                    myMatrix[i, j] = (i + 1) * (j + 1);
                    helper.PrintColorText(myMatrix[i, j].ToString() + "\n", "green"); 
                }
            }

            Console.WriteLine();

            IIterator iterator = myMatrix.GetIterator();

            helper.PrintColorText("Iterationg Matrix in reverse:\n\n", "cyan");

            while (!iterator.IsDone())
            {
                helper.PrintColorText(iterator.CurrentItem().ToString() + "\n", "green"); 
                iterator.Next();
            }

            Console.WriteLine();
        }
    }
}
