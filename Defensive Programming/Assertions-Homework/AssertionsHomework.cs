namespace Telerik.Homeworks.HQC.DefensiveProgramming.Assertions
{
    using System;
    using System.Diagnostics;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arrayToSort) where T : IComparable<T>
        {
            CheckIfOneElementOrLess(arrayToSort);

            for (int index = 0; index < arrayToSort.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arrayToSort, index, arrayToSort.Length - 1);
                Swap(ref arrayToSort[index], ref arrayToSort[minElementIndex]);
            }

            CheckIfSorted(arrayToSort);
        }

        public static int BinarySearch<T>(T[] searchedArray, T searchedValue) where T : IComparable<T>
        {
            CheckIfOneElementOrLess(searchedArray);
            CheckIfSorted(searchedArray);
            Debug.Assert(searchedValue != null, "The searched value is null");
     
            return BinarySearch(searchedArray, searchedValue, 0, searchedArray.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] searchedArray, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (searchedArray[i].CompareTo(searchedArray[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] searchedArray, T searchedValue, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (searchedValue.Equals(searchedArray[midIndex]))
                {
                    return midIndex;
                }

                if (searchedValue.CompareTo(searchedArray[midIndex]) > 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the left half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static void CheckIfOneElementOrLess<T>(T[] arrayToCheck)
        {
            bool hasMoreThanOneElements = arrayToCheck.Length > 1;
            Debug.Assert(hasMoreThanOneElements, "The array contains one element or less");
        }

        private static void CheckIfSorted<T>(T[] arrayToCheck) where T : IComparable<T>
        {
            T currentElement = arrayToCheck[0];
            bool isSorted = true;

            for (int i = 1; i < arrayToCheck.Length; i++)
            {
                if (currentElement.CompareTo(arrayToCheck[i]) > 0)
                {
                    isSorted = false;
                }

                currentElement = arrayToCheck[i];
            }

            Debug.Assert(isSorted, "The given array isn't sorted or isn't sorted correctly");
        }

        private static void Main()
        {
            int[] arrayForTests = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arrayForTests));
            SelectionSort(arrayForTests);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arrayForTests));

            //// SelectionSort(new int[0]); // Test sorting empty array
            //// SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arrayForTests, -1000));
            Console.WriteLine(BinarySearch(arrayForTests, 0));
            Console.WriteLine(BinarySearch(arrayForTests, 17));
            Console.WriteLine(BinarySearch(arrayForTests, 10));
            Console.WriteLine(BinarySearch(arrayForTests, 1000));
        }
    }
}