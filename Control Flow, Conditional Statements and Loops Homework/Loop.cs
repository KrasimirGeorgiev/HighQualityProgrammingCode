// Task 3. Refactor the following loop
namespace Control_Flow__Conditional_Statements_and_Loops_Homework
{
    using System;

    public class Loop
    {
        public static void FindTheDevil(int[] array) 
        {
            for (int i = 0; i < 100; i += 10)
            {
                Console.WriteLine(array[i]);

                if (array[i] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                    break;
                }              
            }

            // More code here
        }
    }
}
